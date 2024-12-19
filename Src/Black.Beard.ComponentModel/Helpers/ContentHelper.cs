using System;
using System.Text.Json;

namespace Bb.Helpers
{
    internal static class ContentHelper
    {

        /// <summary>
        /// Serializes with indentation the specified object.
        /// </summary>
        /// <param name="self">The self object to serialize.</param>
        /// <param name="indented">if set to <c>true</c> [indented].</param>
        /// <returns></returns>
        public static string? Serialize(this object self, bool indented)
        {

            if (self != null)
            {
                string jsonString = JsonSerializer.Serialize(self, new JsonSerializerOptions() { WriteIndented = indented });
                return jsonString;
            }

            return default;

        }


        /// <summary>
        /// Deserializes the specified self payload.
        /// </summary>
        /// <param name="self">The payload.</param>
        /// <param name="sourceType">Target type.</param>
        /// <param name="options"><see cref="JsonSerializerOptions">options of serialization</param>
        /// <returns></returns>
        public static object? Deserialize(this string self, Type sourceType, JsonSerializerOptions? options = null)
        {

            if (self != null)
            {
                options ??= new JsonSerializerOptions { WriteIndented = true };
                var instance = JsonSerializer.Deserialize(self, sourceType, options);
                return instance;
            }

            return default;

        }


    }
}
