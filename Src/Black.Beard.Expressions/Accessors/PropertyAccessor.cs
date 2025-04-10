// Ignore Spelling: Accessor

using Bb.Converters;
using Bb.Expressions;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Bb.Accessors
{


    /// <summary>
    /// Property Accessor 
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class PropertyAccessor : AccessorItem
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyAccessor"/> class.
        /// </summary>
        /// <param name="componentType">The type of the component. Must not be null.</param>
        /// <param name="property">The property to be accessed. Must not be null.</param>
        /// <param name="strategy">The strategy used to determine member access.</param>
        /// <remarks>
        /// This constructor initializes the <see cref="PropertyAccessor"/> with the specified property and strategy.
        /// </remarks>
        internal PropertyAccessor(Type componentType, PropertyInfo property, MemberStrategys strategy)
            : base(componentType, MemberType.Property, strategy, property, property.PropertyType)
        {
            var m = property.GetMethod ?? property.SetMethod;
            this.IsStatic = m != null && (m.Attributes & MethodAttributes.Static) == MethodAttributes.Static;

            #region Get

            if (property.CanRead)
                this.GetValue = GetDirect(componentType, property);

            #endregion

            #region Set

            if (property.CanWrite)
            {

                if (strategy.HasFlag(MemberStrategys.ConvertIfDifferent))
                    SetValue = SetConvertIfDifferentDirect(componentType, property);
                else
                    SetValue = SetDirect(componentType, property);

            }

            #endregion

        }

        #region Generators

        /// <summary>
        /// Generates a delegate to set the value of the specified property directly.
        /// </summary>
        /// <param name="componentType">The type of the component containing the property. Must not be null.</param>
        /// <param name="property">The property to set. Must not be null.</param>
        /// <returns>
        /// A delegate of type <see cref="Action{T1, T2}"/> that sets the value of the property.
        /// </returns>
        /// <remarks>
        /// This method creates an expression tree to generate a delegate for setting the value of the specified property.
        /// </remarks>
        private Action<object, object?> SetDirect(Type componentType, PropertyInfo property)
        {

            var targetObjectParameter = Expression.Parameter(typeof(object), "i");
            var convertedObjectParameter = Expression.ConvertChecked(targetObjectParameter, componentType);
            var valueParameter = Expression.Parameter(typeof(object), "value");
            var convertedValueParameter = Expression.ConvertChecked(valueParameter, property.PropertyType);
            var propertyExpression = Expression.Property(this.IsStatic ? null : convertedObjectParameter, property);

            var e = Expression.Lambda<Action<object, object?>>
            (
                Expression.Assign
                (
                    propertyExpression,
                    convertedValueParameter
                ),
                targetObjectParameter,
                valueParameter
            );

            return e.Compile();

        }

        /// <summary>
        /// Generates a delegate to set the value of the specified property, converting the value if necessary.
        /// </summary>
        /// <param name="componentType">The type of the component containing the property. Must not be null.</param>
        /// <param name="property">The property to set. Must not be null.</param>
        /// <returns>
        /// A delegate of type <see cref="Action{T1, T2}"/> that sets the value of the property, converting the value if needed.
        /// </returns>
        /// <remarks>
        /// This method creates an expression tree to generate a delegate for setting the value of the specified property, with type conversion if required.
        /// </remarks>
        private Action<object, object?> SetConvertIfDifferentDirect(Type componentType, PropertyInfo property)
        {

            Delegate converterMethod = ConverterHelper.ConvertToObject;

            var targetObjectParameter = Expression.Parameter(typeof(object), "i");
            var convertedObjectParameter = Expression.ConvertChecked(targetObjectParameter, componentType);
            var valueParameter = Expression.Parameter(typeof(object), "value");
            var propertyExpression = Expression.Property(this.IsStatic ? null : convertedObjectParameter, property);
            var converter = Expression.Call(converterMethod.Method, valueParameter, property.PropertyType.AsConstant());

            var e = Expression.Lambda<Action<object, object?>>
            (
                Expression.Assign
                (
                    propertyExpression,
                    Expression.Convert(converter, property.PropertyType)
                ),
                targetObjectParameter,
                valueParameter
            );

            return e.Compile();

        }

        /// <summary>
        /// Generates a delegate to get the value of the specified property directly.
        /// </summary>
        /// <param name="componentType">The type of the component containing the property. Must not be null.</param>
        /// <param name="property">The property to retrieve. Must not be null.</param>
        /// <returns>
        /// A delegate of type <see cref="Func{T, TResult}"/> that retrieves the value of the property.
        /// </returns>
        /// <remarks>
        /// This method creates an expression tree to generate a delegate for retrieving the value of the specified property.
        /// </remarks>
        private Func<object, object> GetDirect(Type componentType, PropertyInfo property)
        {

            var sourceParameterExpr = Expression.Parameter(typeof(object), "i");

            var e = Expression.Lambda<Func<object, object>>
            (
                Expression.Convert
                (
                    Expression.Property
                    (
                        this.IsStatic ? null : Expression.Convert(sourceParameterExpr, componentType),
                        property
                    ),
                    typeof(object)
                ),
                sourceParameterExpr

            );

            return e.Compile();

        }

        #endregion Generators


    }

}
