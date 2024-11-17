using System;
using System.Linq.Expressions;
using Bb.Exceptions;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Bb.Converters;
using System.Text;

namespace Bb.Expressions
{

    public static partial class ExpressionHelper
    {

        /// <summary>
        /// Return the property name of the expression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression">expression that contains the property member</param>
        /// <returns>return the property name</returns>
        public static string GetPropertyName(this Expression expression)
        {
            return ExpressionMemberVisitor.GetPropertyName(expression);
        }

        /// <summary>
        /// Return the field name of the expression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression">expression that contains the property member</param>
        /// <returns>return the property name</returns>
        public static string GetFieldName(this Expression expression)
        {
            return ExpressionMemberVisitor.GetPropertyName(expression);
        }

        /// <summary>
        /// create a member expression from property
        /// </summary>
        /// <param name="self">declaring type expression</param>
        /// <param name="propertyName">property name</param>
        /// <returns></returns>
        /// <exception cref="MissingMemberException"></exception>
        public static MemberExpression Property(this Expression self, string propertyName)
        {
            var properties = self.Type.GetProperties();
            var property = properties.Where(c => c.Name == propertyName).FirstOrDefault();

            if (property is null)
                throw new MissingMemberException(propertyName);

            return Property(self, property);
        }

        /// <summary>
        /// create a member expression from field
        /// </summary>
        /// <param name="self">declaring type expression</param>
        /// <param name="fieldName">property name</param>
        /// <returns></returns>
        /// <exception cref="MissingMemberException"></exception>
        public static MemberExpression Field(this Expression self, string fieldName)
        {

            var field = self.Type.GetField(fieldName);

            if (field is null)
                throw new MissingMemberException(fieldName);

            return Field(self, field);

        }

        /// <summary>
        /// create a member expression from property
        /// </summary>
        /// <param name="self">declaring type expression</param>
        /// <param name="fieldName">property name</param>
        /// <param name="binding">filter for resolve property</param>
        /// <returns></returns>
        /// <exception cref="MissingMemberException"></exception>
        public static MemberExpression Field(this Expression self, string fieldName, BindingFlags binding)
        {

            var field = self.Type.GetField(fieldName, binding);

            if (field is null)
                throw new MissingMemberException(fieldName);

            return Field(self, field);

        }

        /// <summary>
        /// create a member expression from property
        /// </summary>
        /// <param name="self"></param>
        /// <param name="propertyName">property</param>
        /// <param name="binding">filter for resolve field</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public static MemberExpression Property(this Expression self, string propertyName, BindingFlags binding)
        {

            var property = self.Type.GetProperty(propertyName, binding);

            if (property is null)
                throw new MissingMemberException(propertyName);

            return Property(self, property);

        }

        /// <summary>
        /// create a member expression from property
        /// </summary>
        /// <param name="self"></param>
        /// <param name="property">property</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public static MemberExpression Property(this Expression self, PropertyInfo property)
        {
            if (property is null)
                throw new NullReferenceException(nameof(property));

            return Expression.Property(self, property);
        }

        /// <summary>
        /// create a member expression from property
        /// </summary>
        /// <param name="self"></param>
        /// <param name="field">property</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public static MemberExpression Field(this Expression self, FieldInfo field)
        {
            if (field is null)
                throw new NullReferenceException(nameof(field));

            return Expression.Field(self, field);
        }


    }


}
