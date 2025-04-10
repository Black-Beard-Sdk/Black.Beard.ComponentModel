// Ignore Spelling: Accessor

using Bb.Converters;
using Bb.Expressions;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Bb.Accessors
{
    /// <summary>
    /// Field Accessor 
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class FieldAccessor : AccessorItem
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldAccessor"/> class.
        /// </summary>
        /// <param name="componentType">The type of the component. Must not be null.</param>
        /// <param name="field">The field to be accessed. Must not be null.</param>
        /// <param name="strategy">The strategy used to determine member access.</param>
        /// <remarks>
        /// This constructor initializes the <see cref="FieldAccessor"/> with the specified field and strategy.
        /// </remarks>
        internal FieldAccessor(Type componentType, FieldInfo field, MemberStrategy strategy)
            : base(componentType, MemberType.Property, strategy, field, field.FieldType)
        {
            this.IsStatic = field.IsStatic;
            
            #region Get

            this.GetValue = GetDirect(componentType, field);

            #endregion

            #region Set

            if (!field.IsInitOnly && !field.IsLiteral)
            {
                if (strategy.HasFlag(MemberStrategy.ConvertIfDifferent))
                    SetValue = SetConvertIfDifferentDirect(componentType, field);
                
                else 
                    SetValue = SetDirect(componentType, field);

            }

            #endregion

        }

        #region Generators

        /// <summary>
        /// Generates a delegate to set the value of the specified field directly.
        /// </summary>
        /// <param name="componentType">The type of the component containing the field. Must not be null.</param>
        /// <param name="field">The field to set. Must not be null.</param>
        /// <returns>
        /// A delegate of type <see cref="Action{T1, T2}"/> that sets the value of the field.
        /// </returns>
        /// <remarks>
        /// This method creates an expression tree to generate a delegate for setting the value of the specified field.
        /// </remarks>
        private Action<object, object?> SetDirect(Type componentType, FieldInfo field)
        {

            var targetObjectParameter = Expression.Parameter(typeof(object), "i");
            var convertedObjectParameter = Expression.ConvertChecked(targetObjectParameter, componentType);
            var valueParameter = Expression.Parameter(typeof(object), "value");
            var convertedValueParameter = Expression.ConvertChecked(valueParameter, field.FieldType);
            var propertyExpression = Expression.Field(this.IsStatic ? null : convertedObjectParameter, field);

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
        /// Generates a delegate to set the value of the specified field, converting the value if necessary.
        /// </summary>
        /// <param name="componentType">The type of the component containing the field. Must not be null.</param>
        /// <param name="field">The field to set. Must not be null.</param>
        /// <returns>
        /// A delegate of type <see cref="Action{T1, T2}"/> that sets the value of the field, converting the value if needed.
        /// </returns>
        /// <remarks>
        /// This method creates an expression tree to generate a delegate for setting the value of the specified field, with type conversion if required.
        /// </remarks>
        private Action<object, object?> SetConvertIfDifferentDirect(Type componentType, FieldInfo field)
        {

            Delegate converterMethod = ConverterHelper.ConvertToObject;

            var targetObjectParameter = Expression.Parameter(typeof(object), "i");
            var convertedObjectParameter = Expression.ConvertChecked(targetObjectParameter, componentType);
            var valueParameter = Expression.Parameter(typeof(object), "value");
            var propertyExpression = Expression.Field(this.IsStatic ? null : convertedObjectParameter, field);
            var converter = Expression.Call(converterMethod.Method, valueParameter, field.FieldType.AsConstant());

            var e = Expression.Lambda<Action<object, object?>>
            (
                Expression.Assign
                (
                    propertyExpression,
                    Expression.Convert(converter, field.FieldType)
                ),
                targetObjectParameter,
                valueParameter
            );

            return e.Compile();

        }

        /// <summary>
        /// Generates a delegate to get the value of the specified field directly.
        /// </summary>
        /// <param name="componentType">The type of the component containing the field. Must not be null.</param>
        /// <param name="field">The field to retrieve. Must not be null.</param>
        /// <returns>
        /// A delegate of type <see cref="Func{T, TResult}"/> that retrieves the value of the field.
        /// </returns>
        /// <remarks>
        /// This method creates an expression tree to generate a delegate for retrieving the value of the specified field.
        /// </remarks>
        private Func<object, object> GetDirect(Type componentType, FieldInfo field)
        {

            var sourceParameterExpr = Expression.Parameter(typeof(object), "i");

            var e = Expression.Lambda<Func<object, object>>
            (
                Expression.Convert
                (
                    Expression.Field
                    (
                        this.IsStatic ? null : Expression.Convert(sourceParameterExpr, componentType),
                        field
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
