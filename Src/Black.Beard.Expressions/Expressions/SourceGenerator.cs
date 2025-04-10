// Ignore Spelling: usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Bb.Expressions
{

    /// <summary>
    /// Text source generator for converting expression trees into source code.
    /// </summary>
    public class SourceGenerator : System.Linq.Expressions.ExpressionVisitor
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceGenerator"/> class with the specified namespaces.
        /// </summary>
        /// <param name="usings">The namespaces to include in the generated source code.</param>
        private SourceGenerator(string[] usings)
        {
            this._usings = new HashSet<string>(usings);
            this._usings.Add("System");
            this._usings.Add("Diagnostics");

            foreach (var item in this._usings)
            {
                Append($"using {item}");
                CutLine();
            }
        }

        /// <summary>
        /// Generates source code from the specified expression tree.
        /// </summary>
        /// <param name="e">The expression tree to convert into source code.</param>
        /// <param name="usings">The namespaces to include in the generated source code.</param>
        /// <returns>A <see cref="StringBuilder"/> containing the generated source code.</returns>
        /// <example>
        /// <code lang="C#">
        /// Expression&lt;Func&lt;int, int&gt;&gt; expression = x => x + 1;
        /// StringBuilder code = SourceGenerator.GetCode(expression, "System");
        /// Console.WriteLine(code.ToString());
        /// </code>
        /// </example>
        public static StringBuilder GetCode(Expression e, params string[] usings)
        {
            SourceGenerator s = new SourceGenerator(usings);
            s.IncrementIndentation();
            s.Visit(e);
            s.DecrementIndentation();
            return s.sb;
        }

        /// <summary>
        /// Visits a <see cref="LambdaExpression"/> and generates its source code.
        /// </summary>
        /// <typeparam name="T">The delegate type of the lambda expression.</typeparam>
        /// <param name="node">The lambda expression to visit.</param>
        /// <returns>The visited expression.</returns>
        /// <remarks>
        /// Generates the method signature and body for the lambda expression.
        /// </remarks>
        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            CutLine();
            Append(node.ReturnType);
            AppendSpace();

            Append("MyMethod(");

            bool t = false;
            foreach (var item in node.Parameters)
            {
                if (t)
                    Append(Comma);
                Append(item.Type);
                Append(" ");
                Visit(item);
                t = true;
            }
            Append(")");
            CutLine();

            if (!(node.Body is BlockExpression))
            {
                Append("{");
                CutLine();
                IncrementIndentation();
            }

            Visit(node.Body);

            if (!(node.Body is BlockExpression))
            {
                DecrementIndentation();
                Append("}");
                CutLine();
            }

            return node;
        }

        /// <summary>
        /// Visits a <see cref="BlockExpression"/> and generates its source code.
        /// </summary>
        /// <param name="node">The block expression to visit.</param>
        /// <returns>The visited expression.</returns>
        /// <remarks>
        /// Generates the code for a block of expressions enclosed in curly braces.
        /// </remarks>
        protected override Expression VisitBlock(BlockExpression node)
        {

            Append("{");
            CutLine();
            IncrementIndentation();

            foreach (var item in node.Expressions)
            {
                CutLine();
                Visit(item);
            }

            DecrementIndentation();
            CutLine();
            Append("}");
            CutLine();

            return node;
        }

        /// <summary>
        /// Visits a <see cref="BinaryExpression"/> and generates its source code.
        /// </summary>
        /// <param name="node">The binary expression to visit.</param>
        /// <returns>The visited expression.</returns>
        /// <remarks>
        /// Generates the code for binary operations such as addition, subtraction, and comparison.
        /// </remarks>
        protected override Expression VisitBinary(BinaryExpression node)
        {

            Visit(node.Left);

            switch (node.NodeType)
            {

                case ExpressionType.NotEqual:
                    Append(" != ");
                    break;
                case ExpressionType.Divide:
                    Append(" / ");
                    break;
                case ExpressionType.DivideAssign:
                    Append(" /= ");
                    break;
                case ExpressionType.Add:
                    Append(" + ");
                    break;
                case ExpressionType.AddAssign:
                    Append(" += ");
                    break;
                case ExpressionType.And:
                    Append(" & ");
                    break;
                case ExpressionType.AndAlso:
                    Append(" && ");
                    break;
                case ExpressionType.AndAssign:
                    Append(" &= ");
                    break;
                case ExpressionType.Assign:
                    Append(" = ");
                    break;
                case ExpressionType.Equal:
                    Append(" == ");
                    break;
                case ExpressionType.GreaterThan:
                    Append(" > ");
                    break;
                case ExpressionType.GreaterThanOrEqual:
                    Append(" >= ");
                    break;
                case ExpressionType.ExclusiveOr:
                    Append(" || ");
                    break;
                case ExpressionType.ExclusiveOrAssign:
                    break;
                case ExpressionType.LessThan:
                    Append(" < ");
                    break;
                case ExpressionType.LessThanOrEqual:
                    Append(" >= ");
                    break;
                case ExpressionType.LeftShift:
                    Append(" << ");
                    break;
                case ExpressionType.Coalesce:
                    Append(" ?? ");
                    break;
                case ExpressionType.Or:
                    break;
                case ExpressionType.OrAssign:
                    Append(" |= ");
                    break;
                case ExpressionType.OrElse:
                    break;
                case ExpressionType.Power:
                    Append(" ^ ");
                    break;
                case ExpressionType.PowerAssign:
                    Append(" ^= ");
                    break;
                case ExpressionType.PreDecrementAssign:
                    Append(" --");
                    break;
                case ExpressionType.PreIncrementAssign:
                    Append(" ++");
                    break;
                case ExpressionType.Subtract:
                    Append(" - ");
                    break;
                case ExpressionType.SubtractAssign:
                    Append(" -= ");
                    break;
                case ExpressionType.Multiply:
                    Append(" * ");
                    break;
                case ExpressionType.MultiplyAssign:
                    Append(" *= ");
                    break;
                case ExpressionType.Modulo:
                    Append(" % ");
                    break;
                case ExpressionType.ModuloAssign:
                    Append(" %= ");
                    break;
                case ExpressionType.RightShift:
                    Append(" >> ");
                    break;
                case ExpressionType.TypeIs:
                    Append(" is ");
                    break;
                case ExpressionType.TypeAs:
                    Append(" as ");
                    break;

                case ExpressionType.RightShiftAssign:
                case ExpressionType.LeftShiftAssign:
                case ExpressionType.PostDecrementAssign:
                case ExpressionType.PostIncrementAssign:
                case ExpressionType.SubtractAssignChecked:
                case ExpressionType.SubtractChecked:
                case ExpressionType.AddAssignChecked:
                case ExpressionType.AddChecked:
                case ExpressionType.MultiplyChecked:
                case ExpressionType.MultiplyAssignChecked:

                    break;

                case ExpressionType.ConvertChecked:
                case ExpressionType.DebugInfo:
                case ExpressionType.ArrayIndex:
                case ExpressionType.ArrayLength:
                case ExpressionType.Default:
                case ExpressionType.Dynamic:
                case ExpressionType.Extension:
                case ExpressionType.Goto:
                case ExpressionType.Index:
                case ExpressionType.Invoke:
                case ExpressionType.Label:
                case ExpressionType.Lambda:
                case ExpressionType.ListInit:
                case ExpressionType.MemberAccess:
                case ExpressionType.MemberInit:

                    break;

                default:

                    break;
            }

            Visit(node.Right);

            return node;
        }

        /// <summary>
        /// Visits a <see cref="NewExpression"/> and generates its source code.
        /// </summary>
        /// <param name="node">The new expression to visit.</param>
        /// <returns>The visited expression.</returns>
        /// <remarks>
        /// Generates the code for creating a new object instance.
        /// </remarks>
        protected override Expression VisitNew(NewExpression node)
        {
            Append("new ");
            Append(node.Type);
            Append("(");
            bool t = false;
            foreach (var item in node.Arguments)
            {
                if (t)
                    Append(Comma);
                Visit(item);
                t = true;
            }
            Append(")");
            return node;
        }

        /// <summary>
        /// Visits a <see cref="ParameterExpression"/> and generates its source code.
        /// </summary>
        /// <param name="node">The parameter expression to visit.</param>
        /// <returns>The visited expression.</returns>
        /// <remarks>
        /// Generates the code for a parameter in the expression tree.
        /// </remarks>
        protected override Expression VisitParameter(ParameterExpression node)
        {
            Append(node.Name ?? node.ToString());
            return node;
        }

        /// <summary>
        /// Visits a <see cref="ConditionalExpression"/> and generates its source code.
        /// </summary>
        /// <param name="node">The conditional expression to visit.</param>
        /// <returns>The visited expression.</returns>
        /// <remarks>
        /// Generates the code for an if-else conditional statement.
        /// </remarks>
        protected override Expression VisitConditional(ConditionalExpression node)
        {

            Append("if (");
            Visit(node.Test);
            Append(")");

            CutLine();

            if (!(node.IfTrue is BlockExpression))
            {
                Append("{");
                CutLine();
                IncrementIndentation();
            }

            Visit(node.IfTrue);

            if (!(node.IfTrue is BlockExpression))
            {
                DecrementIndentation();
                CutLine();
                Append("}");
                CutLine();
            }
            Append("else");

            if (!(node.IfFalse is BlockExpression))
            {
                IncrementIndentation();
            }

            CutLine();

            Visit(node.IfFalse);


            if (!(node.IfFalse is BlockExpression))
            {
                DecrementIndentation();
                CutLine();
            }

            return node;
        }

        /// <summary>
        /// Visits a <see cref="MethodCallExpression"/> and generates its source code.
        /// </summary>
        /// <param name="node">The method call expression to visit.</param>
        /// <returns>The visited expression.</returns>
        /// <remarks>
        /// Generates the code for a method call.
        /// </remarks>
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {

            if (node.Object == null && node.Method.DeclaringType != null)
                Append(node.Method.DeclaringType.Name);
            else
                Visit(node.Object);

            Append(".");
            Append(node.Method.Name);

            Append("(");
            bool t = false;
            foreach (var item in node.Arguments)
            {
                if (t)
                    Append(Comma);
                Visit(item);
                t = true;
            }
            Append(")");

            return node;

        }

        /// <summary>
        /// Visits a <see cref="ConstantExpression"/> and generates its source code.
        /// </summary>
        /// <param name="node">The constant expression to visit.</param>
        /// <returns>The visited expression.</returns>
        /// <remarks>
        /// Generates the code for a constant value in the expression tree.
        /// </remarks>
        protected override Expression VisitConstant(ConstantExpression node)
        {

            if (node.Value is string)
                Append($"{Quote}{node.Value}{Quote}");

            else if (node.Value is char)
                Append($"'{node.Value}'");

            else
            {
                if (node.Value == null)
                    Append("null");
                else
                    Append(node.Value.ToString());
            }
            return node;

        }

        /// <summary>
        /// Visits a <see cref="LoopExpression"/> and generates its source code.
        /// </summary>
        /// <param name="node">The loop expression to visit.</param>
        /// <returns>The visited expression.</returns>
        /// <remarks>
        /// Generates the code for a loop structure.
        /// </remarks>
        protected override Expression VisitLoop(LoopExpression node)
        {

            if (node == null)
                throw new ArgumentNullException(nameof(node));

            if (node.BreakLabel == null)
                throw new InvalidOperationException(nameof(node.BreakLabel));

            if (node.ContinueLabel == null)
                throw new InvalidOperationException(nameof(node.ContinueLabel));

            Append("Loop");
            CutLine();

            if (!(node.Body is BlockExpression))
            {
                Append("{");
                IncrementIndentation();
            }

            AppendLabel(node.ContinueLabel);

            Visit(node.Body);

            if (!(node.Body is BlockExpression))
            {
                DecrementIndentation();
                CutLine();
                Append("}");
            }

            CutLine();

            Append("Goto ");
            Append(node.ContinueLabel.Name);

            AppendLabel(node.BreakLabel);

            return node;
        }

        /// <summary>
        /// Visits a <see cref="MemberExpression"/> and generates its source code.
        /// </summary>
        /// <param name="node">The member expression to visit.</param>
        /// <returns>The visited expression.</returns>
        /// <remarks>
        /// Generates the code for accessing a member of an object.
        /// </remarks>
        protected override Expression VisitMember(MemberExpression node)
        {

            Visit(node.Expression);
            Append(".");
            Append(node.Member.Name);

            return node;
        }

        /// <summary>
        /// Visits a <see cref="IndexExpression"/> and generates its source code.
        /// </summary>
        /// <param name="node">The index expression to visit.</param>
        /// <returns>The visited expression.</returns>
        /// <remarks>
        /// Generates the code for accessing an indexed property or array element.
        /// </remarks>
        protected override Expression VisitIndex(IndexExpression node)
        {
            Visit(node.Object);
            Append("[");

            bool t = false;
            foreach (var item in node.Arguments)
            {
                if (t)
                    Append(Comma);
                Visit(item);
                t = true;
            }

            Append("]");

            return node;
        }

        /// <summary>
        /// Visits a <see cref="GotoExpression"/> and generates its source code.
        /// </summary>
        /// <param name="node">The goto expression to visit.</param>
        /// <returns>The visited expression.</returns>
        /// <remarks>
        /// Generates the code for a goto statement.
        /// </remarks>
        protected override Expression VisitGoto(GotoExpression node)
        {
            Append("Goto ");
            Append(node.Target.Name);
            return node;
        }

        /// <summary>
        /// Visits a <see cref="TypeBinaryExpression"/> and generates its source code.
        /// </summary>
        /// <param name="node">The type binary expression to visit.</param>
        /// <returns>The visited expression.</returns>
        /// <remarks>
        /// Generates the code for type checking operations.
        /// </remarks>
        protected override Expression VisitTypeBinary(TypeBinaryExpression node)
        {
            Visit(node.Expression);
            Append(" is ");
            Append(node.Type);
            return node;
        }

        /// <summary>
        /// Visits a <see cref="UnaryExpression"/> and generates its source code.
        /// </summary>
        /// <param name="node">The unary expression to visit.</param>
        /// <returns>The visited expression.</returns>
        /// <remarks>
        /// Generates the code for unary operations such as increment, decrement, and negation.
        /// </remarks>
        protected override Expression VisitUnary(UnaryExpression node)
        {
            switch (node.NodeType)
            {

                case ExpressionType.Increment:
                    Visit(node.Operand);
                    Append("++ ");
                    break;
                case ExpressionType.Decrement:
                    Visit(node.Operand);
                    Append("-- ");
                    break;

                case ExpressionType.Convert:
                    Append("((");
                    Append(node.Type);
                    Append(")");
                    Visit(node.Operand);
                    Append(")");
                    break;

                case ExpressionType.Not:
                    Append("!");
                    Visit(node.Operand);
                    break;

                case ExpressionType.IsTrue:
                    Visit(node.Operand);
                    Append(" == true");
                    break;

                case ExpressionType.IsFalse:
                    Visit(node.Operand);
                    Append(" == false");
                    break;

                case ExpressionType.Negate:
                case ExpressionType.NegateChecked:
                case ExpressionType.UnaryPlus:

                    break;

                default:
                    break;

            }

            return node;
        }

        /// <summary>
        /// Visits a <see cref="DebugInfoExpression"/> and generates its source code.
        /// </summary>
        /// <param name="node">Item to parse</param>
        /// <returns></returns>
        protected override Expression VisitDebugInfo(DebugInfoExpression node)
        {

            return base.VisitDebugInfo(node);
        }

        /// <summary>
        /// Visits a <see cref="DefaultExpression"/> and generates its source code.
        /// </summary>
        /// <param name="node">Item to parse</param>
        /// <returns></returns>
        protected override Expression VisitDefault(DefaultExpression node)
        {
            Append("default(");
            Append(node.Type);
            Append(")");

            return base.VisitDefault(node);
        }

        /// <summary>
        /// Visits a <see cref="DynamicExpression"/> and generates its source code.
        /// </summary>
        /// <param name="node">Item to parse</param>
        /// <returns></returns>
        protected override Expression VisitDynamic(DynamicExpression node)
        {

            return base.VisitDynamic(node);
        }

        /// <summary>
        /// Visits a <see cref="ElementInit"/> and generates its source code.
        /// </summary>
        /// <param name="node">Item to parse</param>
        /// <returns></returns>
        protected override ElementInit VisitElementInit(ElementInit node)
        {

            return base.VisitElementInit(node);
        }

        /// <summary>
        /// Visits an <see cref="Expression"/> that is not explicitly handled by other visit methods.
        /// </summary>
        /// <param name="node">Item to parse</param>
        /// <returns></returns>
        protected override Expression VisitExtension(Expression node)
        {

            return base.VisitExtension(node);
        }

        /// <summary>
        /// Visits a <see cref="InvocationExpression"/> and generates its source code.
        /// </summary>
        /// <param name="node">Item to parse</param>
        /// <returns></returns>
        protected override Expression VisitInvocation(InvocationExpression node)
        {

            return base.VisitInvocation(node);
        }

        /// <summary>
        /// Visits a <see cref="LabelExpression"/> and generates its source code.
        /// </summary>
        /// <param name="node">Item to parse</param>
        /// <returns></returns>
        protected override Expression VisitLabel(LabelExpression node)
        {

            return base.VisitLabel(node);
        }

        /// <summary>
        /// Visits a <see cref="ListInitExpression"/> and generates its source code.
        /// </summary>
        /// <param name="node">Item to parse</param>
        /// <returns></returns>
        protected override Expression VisitListInit(ListInitExpression node)
        {

            return base.VisitListInit(node);
        }

        /// <summary>
        /// Visits a <see cref="LoopExpression"/> and generates its source code.
        /// </summary>
        /// <param name="node">Item to parse</param>
        /// <returns></returns>
        protected override MemberAssignment VisitMemberAssignment(MemberAssignment node)
        {

            return base.VisitMemberAssignment(node);
        }

        /// <summary>
        /// Visits a <see cref="MemberBinding"/> and generates its source code.
        /// </summary>
        /// <param name="node">Item to parse</param>
        /// <returns></returns>
        protected override MemberBinding VisitMemberBinding(MemberBinding node)
        {

            return base.VisitMemberBinding(node);
        }

        /// <summary>
        /// Visits a <see cref="MemberInitExpression"/> and generates its source code.
        /// </summary>
        /// <param name="node">Item to parse</param>
        /// <returns></returns>
        protected override Expression VisitMemberInit(MemberInitExpression node)
        {

            return base.VisitMemberInit(node);
        }

        /// <summary>
        /// Visits a <see cref="MemberListBinding"/> and generates its source code.
        /// </summary>
        /// <param name="node">Item to parse</param>
        /// <returns></returns>
        protected override MemberListBinding VisitMemberListBinding(MemberListBinding node)
        {

            return base.VisitMemberListBinding(node);
        }

        /// <summary>
        /// Visits a <see cref="MemberMemberBinding"/> and generates its source code.
        /// </summary>
        /// <param name="node">Item to parse</param>
        /// <returns></returns>
        protected override MemberMemberBinding VisitMemberMemberBinding(MemberMemberBinding node)
        {

            return base.VisitMemberMemberBinding(node);
        }

        /// <summary>
        /// Visits a <see cref="NewArrayExpression"/> and generates its source code.
        /// </summary>
        /// <param name="node">Item to parse</param>
        /// <returns></returns>
        protected override Expression VisitNewArray(NewArrayExpression node)
        {

            Append("new ");
            Append(node.Type.Name);
            Append("{ ");
            string comma = string.Empty;
            foreach (var item in node.Expressions)
            {
                Append(comma);
                Visit(item);
                comma = Comma;
            }
            Append(" }");

            return node;
        }

        /// <summary>
        /// Visits a <see cref="RuntimeVariablesExpression"/> and generates its source code.
        /// </summary>
        /// <param name="node">Item to parse</param>
        /// <returns></returns>
        protected override Expression VisitRuntimeVariables(RuntimeVariablesExpression node)
        {

            return base.VisitRuntimeVariables(node);
        }

        /// <summary>
        /// Visits a <see cref="SwitchExpression"/> and generates its source code.
        /// </summary>
        /// <param name="node">Item to parse</param>
        /// <returns></returns>
        protected override Expression VisitSwitch(SwitchExpression node)
        {

            return base.VisitSwitch(node);
        }

        /// <summary>
        /// Visits a <see cref="SwitchCase"/> and generates its source code.
        /// </summary>
        /// <param name="node">Item to parse</param>
        /// <returns></returns>
        protected override SwitchCase VisitSwitchCase(SwitchCase node)
        {

            return base.VisitSwitchCase(node);
        }

        /// <summary>
        /// Visits a <see cref="TryExpression"/> and generates its source code.
        /// </summary>
        /// <param name="node">Item to parse</param>
        /// <returns></returns>
        protected override Expression VisitTry(TryExpression node)
        {

            return base.VisitTry(node);
        }

        /// <summary>
        /// Visits a <see cref="CatchBlock"/> and generates its source code.
        /// </summary>
        /// <param name="node">Item to parse</param>
        /// <returns></returns>
        protected override CatchBlock VisitCatchBlock(CatchBlock node)
        {

            return base.VisitCatchBlock(node);
        }

        #region Write

        /// <summary>
        /// Appends a space character to the generated source code.
        /// </summary>
        /// <remarks>
        /// This method is used to add a single space for formatting purposes in the generated source code.
        /// </remarks>
        private void AppendSpace()
        {
            sb.Append(" ");
        }

        /// <summary>
        /// Appends the string representation of a <see cref="Type"/> to the generated source code.
        /// </summary>
        /// <param name="type">The type to append.</param>
        /// <remarks>
        /// The method ensures that the type is properly formatted and shortened based on the included namespaces.
        /// </remarks>
        private void Append(Type type)
        {

            var t = type.FullName;
            if (this._usings != null && !string.IsNullOrEmpty(t))
            {
                var item = this._usings.FirstOrDefault(c => t.StartsWith(c));
                if (item != null)
                    t = t.Substring(item.Length + 1);
            }
            sb.Append(t);
        }

        /// <summary>
        /// Appends a string to the generated source code.
        /// </summary>
        /// <param name="txt">The text to append. Can be null.</param>
        /// <remarks>
        /// This method directly appends the provided string to the internal <see cref="StringBuilder"/>.
        /// </remarks>
        private void Append(string? txt)
        {
            sb.Append(txt);
        }

        /// <summary>
        /// Appends a new line to the generated source code and adjusts the indentation.
        /// </summary>
        /// <remarks>
        /// This method ensures that each new line in the generated source code is properly indented based on the current indentation level.
        /// </remarks>
        private void CutLine()
        {
            sb.AppendLine();
            for (int i = 0; i < _indentation; i++)
            {
                sb.Append('\t');
            }
        }

        /// <summary>
        /// Appends a label to the generated source code.
        /// </summary>
        /// <param name="label">The label to append. Must not be null.</param>
        /// <remarks>
        /// This method appends a label, such as those used in loops or goto statements, to the generated source code.
        /// </remarks>
        private void AppendLabel(LabelTarget label)
        {

            if (label == null)
                throw new ArgumentNullException(nameof(label));

            sb.AppendLine("");
            Append(label.Name);
            sb.Append(" : ");
            CutLine();
        }

        #endregion Write

        /// <summary>
        /// Increments the current indentation level for the generated source code.
        /// </summary>
        /// <remarks>
        /// This method increases the indentation level, which is used to format the generated source code with proper alignment.
        /// </remarks>
        private void IncrementIndentation()
        {
            _indentation++;
        }

        /// <summary>
        /// Decrements the current indentation level for the generated source code.
        /// </summary>
        /// <remarks>
        /// This method decreases the indentation level, ensuring proper alignment in the generated source code.
        /// </remarks>
        private void DecrementIndentation()
        {
            _indentation--;
        }

        /// <summary>
        /// Represents the current indentation level for the generated source code.
        /// </summary>
        /// <remarks>
        /// This field is used internally to track the number of indentation levels for formatting purposes.
        /// </remarks>
        private int _indentation;

        /// <summary>
        /// A <see cref="StringBuilder"/> used to construct the generated source code.
        /// </summary>
        /// <remarks>
        /// This field is initialized with a default capacity of 10 KB.
        /// </remarks>
        private readonly StringBuilder sb = new StringBuilder(10 * 1024);

        /// <summary>
        /// A set of namespaces to include in the generated source code.
        /// </summary>
        /// <remarks>
        /// This field ensures that type names are properly shortened based on the included namespaces.
        /// </remarks>
        private readonly HashSet<string> _usings;


        /// <summary>
        /// The character used to represent a double quote in the generated source code.
        /// </summary>
        public const char Quote = '"';

        /// <summary>
        /// The string used to represent a comma and space in the generated source code.
        /// </summary>
        public const string Comma = ", ";

    }

}
