using System.Linq.Expressions;

namespace Bb.Expressions
{


    public class ExpressionMemberVisitor : ExpressionVisitor
    {

        /// <summary>
        /// Return the property name of the expression
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string GetPropertyNam(Expression e)
        {
            var visitor = new ExpressionMemberVisitor();
            visitor.Visit(e);
            return visitor._propertyName;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            _propertyName = node.Member.Name;
            return base.VisitMember(node);
        }

        private string _propertyName;

    }


}
