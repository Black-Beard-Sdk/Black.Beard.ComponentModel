using System;
using System.Linq.Expressions;

namespace Bb.Expressions
{


    public static class ExpressionHelper
    {

        /// <summary>
        /// Return the property name of the expression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression">expression that contains the property member</param>
        /// <returns>return the property name</returns>
        public static string GetPropertyName(this Expression expression)
        {
            return ExpressionMemberVisitor.GetPropertyNam(expression);
        }

    }


}
