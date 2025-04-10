using System.Linq.Expressions;

namespace Bb.Expressions
{

    /// <summary>
    /// A visitor for extracting the property name from an expression.
    /// </summary>
    public class ExpressionMemberVisitor : ExpressionVisitor
    {

        /// <summary>
        /// Retrieves the property name from the specified expression.
        /// </summary>
        /// <param name="e">The expression to extract the property name from.</param>
        /// <returns>The name of the property represented by the expression.</returns>
        /// <remarks>
        /// This method visits the provided expression and extracts the name of the property it represents.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// Expression&lt;Func&lt;MyClass, object&gt;&gt; expression = x => x.MyProperty;
        /// string propertyName = ExpressionMemberVisitor.GetPropertyName(expression.Body);
        /// Console.WriteLine(propertyName); // Output: "MyProperty"
        /// </code>
        /// </example>
        public static string? GetPropertyName(Expression e)
        {
            var visitor = new ExpressionMemberVisitor();
            visitor.Visit(e);
            return visitor._propertyName;
        }

        /// <summary>
        /// Visits a <see cref="MemberExpression"/> and extracts the property name.
        /// </summary>
        /// <param name="node">The member expression to visit.</param>
        /// <returns>The visited expression.</returns>
        /// <remarks>
        /// This method sets the property name to the name of the member represented by the expression.
        /// </remarks>
        protected override Expression VisitMember(MemberExpression node)
        {
            _propertyName = node.Member.Name;
            return base.VisitMember(node);
        }

        private string? _propertyName;

    }

}
