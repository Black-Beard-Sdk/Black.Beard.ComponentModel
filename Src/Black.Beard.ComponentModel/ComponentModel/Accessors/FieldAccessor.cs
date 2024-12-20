using Bb.Expressions;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Bb.ComponentModel.Accessors
{
    /// <summary>
    /// Field Accessor 
    /// Field Accessor 
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class FieldAccessor : AccessorItem
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyAccessor"/> class.
        /// </summary>
        /// <param name="componentType">Type of the component.</param>
        /// <param name="field">The property.</param>
        internal FieldAccessor(Type componentType, FieldInfo field, AccessorStrategyEnum strategy)
            : base(MemberTypeEnum.Property, strategy)
        {

            this.Member = field;
            this.Name = field.Name;
            this.DeclaringType = field.DeclaringType;
            //var m = field.GetMethod ?? field.SetMethod;
            this.IsStatic = field.IsStatic;
            this.Type = field.FieldType;

            #region Get

            this.GetValue = GetDirect(componentType, field);

            #endregion

            #region Set

            if (!field.IsInitOnly)
            {
                if (strategy.HasFlag(AccessorStrategyEnum.ConvertIfDifferent))
                    SetValue = SetConvertIfDifferentDirect(componentType, field);
                else
                    SetValue = SetDirect(componentType, field);
            }

            #endregion

        }

        #region Generators

        private Action<object, object> SetDirect(Type componentType, FieldInfo field)
        {

            var targetObjectParameter = Expression.Parameter(typeof(object), "i");
            var convertedObjectParameter = Expression.ConvertChecked(targetObjectParameter, componentType);
            var valueParameter = Expression.Parameter(typeof(object), "value");
            var convertedValueParameter = Expression.ConvertChecked(valueParameter, field.FieldType);
            var propertyExpression = Expression.Field(this.IsStatic ? null : convertedObjectParameter, field);

            var e = Expression.Lambda<Action<object, object>>
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

        private Action<object, object> SetConvertIfDifferentDirect(Type componentType, FieldInfo field)
        {

            Delegate converterMethod = ConverterHelper.ConvertTo;

            var targetObjectParameter = Expression.Parameter(typeof(object), "i");
            var convertedObjectParameter = Expression.ConvertChecked(targetObjectParameter, componentType);
            var valueParameter = Expression.Parameter(typeof(object), "value");
            var propertyExpression = Expression.Field(this.IsStatic ? null : convertedObjectParameter, field);
            var converter = Expression.Call(converterMethod.Method, valueParameter, field.FieldType.AsConstant());

            var e = Expression.Lambda<Action<object, object>>
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



        ///// <summary>
        ///// Gets the specified component type.
        ///// </summary>
        ///// <param name="componentType">Type of the component.</param>
        ///// <param name="name">The name.</param>
        ///// <returns></returns>
        //public static PropertyAccessor GetField(Type componentType, string name, AccessorStrategyEnum strategy = AccessorStrategyEnum.Direct)
        //{
        //    AccessorList list = null;
        //    PropertyAccessor accessor = null;

        //    list = GetPropertiesImpl(componentType, strategy);

        //    if (list.ContainsKey(name))
        //        accessor = list[name] as PropertyAccessor;

        //    //else
        //    //    lock (list._lock)
        //    //    {
        //    //        if (list.ContainsKey(name))
        //    //            accessor = list[name] as PropertyAccessor;
        //    //        else
        //    //        {
        //    //            var property = componentType.GetProperty(name);
        //    //            if (property != null)
        //    //                list.Add((accessor = new PropertyAccessor(componentType, property, strategy)));

        //    //        }
        //    //    }

        //    return accessor;

        //}

        ///// <summary>
        ///// Gets the specified component type.
        ///// </summary>
        ///// <param name="componentType">Type of the component.</param>
        ///// <param name="withSubType">if set to <c>true</c> [with sub type].</param>
        ///// <returns></returns>
        //public static AccessorList GetProperties(Type componentType, AccessorStrategyEnum strategy = AccessorStrategyEnum.Direct)
        //{
        //    AccessorList list = GetPropertiesImpl(componentType, strategy);
        //    return list;
        //}


    }

}
