using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;

namespace Bb.TypeDescriptors
{



    public interface IDynamicDescriptorInstance
    {

        object GetProperty(string name);

        void SetProperty(string name, object value);

    }



    public class DynamicDescriptorInstanceJsonConverter : JsonConverterFactory
    {

        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(IDynamicDescriptorInstance).IsAssignableFrom(typeToConvert);
        }

        public override JsonConverter CreateConverter(Type type, JsonSerializerOptions options)
        {

            JsonConverter converter = (JsonConverter)Activator.CreateInstance
            (
                typeof(CustomJsonConverter<>).MakeGenericType(type),
                BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                args: null,
                culture: null
            )!;

            return converter;
        }

        public class CustomJsonConverter<T> : JsonConverter<T>
            where T : IDynamicDescriptorInstance, new()
        {


            public CustomJsonConverter()
            {

            }

            public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
            {

                var properties = TypeDescriptor.GetProperties(value)
                    .OfType<PropertyDescriptor>()
                    .Where(c => Include(c))
                    .OrderBy(c => c.Name)
                    .ToList();

                writer.WriteStartObject();

                foreach (var item in properties)
                {
                    var propertyValue = item.GetValue(value);
                    if (propertyValue != null)
                    {
                        writer.WritePropertyName(item.Name);
                        JsonSerializer.Serialize(writer, propertyValue, options);
                    }
                }

                writer.WriteEndObject();

            }

            private bool Include(PropertyDescriptor c)
            {

                if (c.IsReadOnly)
                    return false;

                if (c.Attributes.OfType<JsonIgnoreAttribute>().Any())
                    return false;

                return true;
            }

            public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {

                if (reader.TokenType != JsonTokenType.StartObject)
                    throw new JsonException();

                var instance = new T();

                var properties = TypeDescriptor.GetProperties(instance)
                    .OfType<PropertyDescriptor>()
                    .ToDictionary(c => c.Name);

                while (reader.Read())
                {

                    if (reader.TokenType == JsonTokenType.EndObject)
                        return instance;

                    if (reader.TokenType != JsonTokenType.PropertyName)
                        throw new JsonException();

                    // Get the property name.
                    string? propertyName = reader.GetString();


                    if (properties.TryGetValue(propertyName, out PropertyDescriptor? property)) // Get the value.
                    {
                        var value = JsonSerializer.Deserialize(ref reader, property.PropertyType, options);
                        property.SetValue(instance, value);
                    }
                    else
                    {

                        reader.Read();

                        switch (reader.TokenType)
                        {
                            case JsonTokenType.None:
                                break;
                            case JsonTokenType.StartObject:
                                break;
                            case JsonTokenType.EndObject:
                                break;
                            case JsonTokenType.StartArray:
                                break;
                            case JsonTokenType.EndArray:
                                break;
                            case JsonTokenType.PropertyName:
                                break;
                            case JsonTokenType.Comment:
                                break;
                            case JsonTokenType.String:
                                break;
                            case JsonTokenType.Number:
                                break;
                            case JsonTokenType.True:
                                break;
                            case JsonTokenType.False:
                                break;
                            case JsonTokenType.Null:
                                break;
                            default:
                                break;
                        }
                    }

                }

                throw new JsonException();


            }

        }

    }

}
