// Ignore Spelling: accessor nlp

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ICSharpCode.Decompiler.CSharp.OutputVisitor;
using ICSharpCode.Decompiler.CSharp.Syntax;
using ICSharpCode.Decompiler.CSharp.Syntax.PatternMatching;

namespace Bb.Decompilers
{


    /// <summary>
    /// Base visitor for parsing C# syntax trees.
    /// </summary>
    public class AstVisitorBase : IAstVisitor
    {


        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="syntaxTree">item to parse</param>
        public virtual void VisitSyntaxTree(SyntaxTree syntaxTree)
        {
            // don't do node tracking as we visit all children directly
            foreach (AstNode node in syntaxTree.Children)
            {
                node.AcceptVisitor(this);
            }
        }


        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="accessor">item to parse</param>
        public virtual void VisitAccessor(Accessor accessor)
        {

            if (accessor.Role == PropertyDeclaration.GetterRole)
            {

            }
            else if (accessor.Role == PropertyDeclaration.SetterRole)
            {
                if (accessor.Keyword.Role == PropertyDeclaration.InitKeywordRole)
                {
                }
                else
                {
                }
            }
            else if (accessor.Role == CustomEventDeclaration.AddAccessorRole)
            {
            }
            else if (accessor.Role == CustomEventDeclaration.RemoveAccessorRole)
            {
            }

            var body = accessor.Body;
            if (!body.IsNull)
            {
                foreach (var node in body.Statements)
                {
                    node.AcceptVisitor(this);
                }
            }

        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="anonymousMethodExpression"></param>
        public virtual void VisitAnonymousMethodExpression(AnonymousMethodExpression anonymousMethodExpression)
        {
            if (anonymousMethodExpression.HasParameterList)
                WriteCommaSeparatedList(anonymousMethodExpression.Parameters);
            WriteBlock(anonymousMethodExpression.Body);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="anonymousTypeCreateExpression"></param>
        public virtual void VisitAnonymousTypeCreateExpression(AnonymousTypeCreateExpression anonymousTypeCreateExpression)
        {
            PrintInitializerElements(anonymousTypeCreateExpression.Initializers);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="arrayCreateExpression"></param>
        public virtual void VisitArrayCreateExpression(ArrayCreateExpression arrayCreateExpression)
        {
            arrayCreateExpression.Type.AcceptVisitor(this);
            if (arrayCreateExpression.Arguments.Count > 0)
            {
                WriteCommaSeparatedList(arrayCreateExpression.Arguments);
            }
            foreach (var specifier in arrayCreateExpression.AdditionalArraySpecifiers)
            {
                specifier.AcceptVisitor(this);
            }
            arrayCreateExpression.Initializer.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="arrayInitializerExpression"></param>
        public virtual void VisitArrayInitializerExpression(ArrayInitializerExpression arrayInitializerExpression)
        {
            // "new List<int> { { 1 } }" and "new List<int> { 1 }" are the same semantically.
            // We also use the same AST for both: we always use two nested ArrayInitializerExpressions
            // for collection initializers, even if the user did not write nested brackets.
            // The output visitor will output nested braces only if they are necessary,
            // or if the braces tokens exist in the AST.
            bool bracesAreOptional = arrayInitializerExpression.Elements.Count == 1
                && IsObjectOrCollectionInitializer(arrayInitializerExpression.Parent)
                && !CanBeConfusedWithObjectInitializer(arrayInitializerExpression.Elements.Single());
            if (bracesAreOptional && arrayInitializerExpression.LBraceToken.IsNull)
            {
                arrayInitializerExpression.Elements.Single().AcceptVisitor(this);
            }
            else
            {
                PrintInitializerElements(arrayInitializerExpression.Elements);
            }
        }

        /// <summary>
        /// return true if the expression can be confused with an object initializer.
        /// </summary>
        /// <param name="expr"></param>
        /// <returns></returns>
        protected bool CanBeConfusedWithObjectInitializer(Expression expr)
        {
            // "int a; new List<int> { a = 1 };" is an object initalizers and invalid, but
            // "int a; new List<int> { { a = 1 } };" is a valid collection initializer.
            AssignmentExpression ae = expr as AssignmentExpression;
            return ae != null && ae.Operator == AssignmentOperatorType.Assign;
        }

        /// <summary>
        /// return true if the node is an object or collection initializer.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected bool IsObjectOrCollectionInitializer(AstNode node)
        {
            if (!(node is ArrayInitializerExpression))
                return false;
            if (node.Parent is ObjectCreateExpression)
                return node.Role == ObjectCreateExpression.InitializerRole;
            if (node.Parent is NamedExpression)
                return node.Role == Roles.Expression;
            return false;
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="arraySpecifier"></param>
        public virtual void VisitArraySpecifier(ArraySpecifier arraySpecifier)
        {
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="asExpression"></param>
        public virtual void VisitAsExpression(AsExpression asExpression)
        {
            asExpression.Expression.AcceptVisitor(this);
            asExpression.Type.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="assignmentExpression">item to parse</param>
        public virtual void VisitAssignmentExpression(AssignmentExpression assignmentExpression)
        {
            assignmentExpression.Left.AcceptVisitor(this);
            assignmentExpression.Right.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="attribute">item to parse</param>
        public virtual void VisitAttribute(ICSharpCode.Decompiler.CSharp.Syntax.Attribute attribute)
        {
            attribute.Type.AcceptVisitor(this);
            if (attribute.Arguments.Count != 0 || attribute.HasArgumentList)
                WriteCommaSeparatedList(attribute.Arguments);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="attributeSection">item to parse</param>
        public virtual void VisitAttributeSection(AttributeSection attributeSection)
        {
            WriteCommaSeparatedList(attributeSection.Attributes);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="baseReferenceExpression">item to parse</param>
        public virtual void VisitBaseReferenceExpression(BaseReferenceExpression baseReferenceExpression)
        {
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="binaryOperatorExpression">item to parse</param>
        public virtual void VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression)
        {
            binaryOperatorExpression.Left.AcceptVisitor(this);
            binaryOperatorExpression.Right.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="blockStatement">item to parse</param>
        public virtual void VisitBlockStatement(BlockStatement blockStatement)
        {
            WriteBlock(blockStatement);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="breakStatement">item to parse</param>
        public virtual void VisitBreakStatement(BreakStatement breakStatement)
        {

        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="caseLabel">item to parse</param>
        public virtual void VisitCaseLabel(CaseLabel caseLabel)
        {
            caseLabel.Expression.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="castExpression">item to parse</param>
        public virtual void VisitCastExpression(CastExpression castExpression)
        {
            castExpression.Type.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="catchClause">item to parse</param>
        public virtual void VisitCatchClause(CatchClause catchClause)
        {

            if (!catchClause.Type.IsNull)
                catchClause.Type.AcceptVisitor(this);

            if (!catchClause.Condition.IsNull)
                catchClause.Condition.AcceptVisitor(this);

            WriteBlock(catchClause.Body);

        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="checkedExpression">item to parse</param>
        public virtual void VisitCheckedExpression(CheckedExpression checkedExpression)
        {
            checkedExpression.Expression.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="checkedStatement">item to parse</param>
        public virtual void VisitCheckedStatement(CheckedStatement checkedStatement)
        {
            checkedStatement.Body.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="comment">item to parse</param>
        public virtual void VisitComment(Comment comment)
        {

        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="composedType">item to parse</param>
        public virtual void VisitComposedType(ComposedType composedType)
        {

            if (composedType.Attributes.Any())
                foreach (var attr in composedType.Attributes)
                    attr.AcceptVisitor(this);

            composedType.BaseType.AcceptVisitor(this);

            foreach (var node in composedType.ArraySpecifiers)
                node.AcceptVisitor(this);

        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="conditionalExpression">item to parse</param>
        public virtual void VisitConditionalExpression(ConditionalExpression conditionalExpression)
        {
            conditionalExpression.Condition.AcceptVisitor(this);
            conditionalExpression.TrueExpression.AcceptVisitor(this);
            conditionalExpression.FalseExpression.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="constraint">item to parse</param>
        public virtual void VisitConstraint(Constraint constraint)
        {
            constraint.TypeParameter.AcceptVisitor(this);
            WriteCommaSeparatedList(constraint.BaseTypes);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="constructorDeclaration">item to parse</param>
        public virtual void VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration)
        {

            WriteAttributes(constructorDeclaration.Attributes);
            WriteModifiers(constructorDeclaration.ModifierTokens);
            TypeDeclaration type = constructorDeclaration.Parent as TypeDeclaration;
            //if (type != null && type.Name != constructorDeclaration.Name)
            //    WriteIdentifier((Identifier)type.NameToken.Clone());
            //else
            //    WriteIdentifier(constructorDeclaration.NameToken);
            if (!constructorDeclaration.Initializer.IsNull)
                constructorDeclaration.Initializer.AcceptVisitor(this);

            WriteMethodBody(constructorDeclaration.Body);

        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="constructorInitializer">item to parse</param>
        public virtual void VisitConstructorInitializer(ConstructorInitializer constructorInitializer)
        {
            WriteCommaSeparatedList(constructorInitializer.Arguments);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="continueStatement">item to parse</param>
        public virtual void VisitContinueStatement(ContinueStatement continueStatement)
        {
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="cSharpTokenNode">item to parse</param>
        public virtual void VisitCSharpTokenNode(CSharpTokenNode cSharpTokenNode)
        {

        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="customEventDeclaration">item to parse</param>
        public virtual void VisitCustomEventDeclaration(CustomEventDeclaration customEventDeclaration)
        {
            WriteAttributes(customEventDeclaration.Attributes);
            WriteModifiers(customEventDeclaration.ModifierTokens);
            customEventDeclaration.ReturnType.AcceptVisitor(this);
            // output add/remove in their original order
            foreach (AstNode node in customEventDeclaration.Children)
                if (node.Role == CustomEventDeclaration.AddAccessorRole || node.Role == CustomEventDeclaration.RemoveAccessorRole)
                    node.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="declarationExpression">item to parse</param>
        public virtual void VisitDeclarationExpression(DeclarationExpression declarationExpression)
        {
            declarationExpression.Type.AcceptVisitor(this);
            declarationExpression.Designation.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="defaultValueExpression">item to parse</param>
        public virtual void VisitDefaultValueExpression(DefaultValueExpression defaultValueExpression)
        {
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="delegateDeclaration">item to parse</param>
        public virtual void VisitDelegateDeclaration(DelegateDeclaration delegateDeclaration)
        {
            WriteAttributes(delegateDeclaration.Attributes);
            WriteModifiers(delegateDeclaration.ModifierTokens);
            delegateDeclaration.ReturnType.AcceptVisitor(this);
            WriteTypeParameters(delegateDeclaration.TypeParameters);
            WriteCommaSeparatedList(delegateDeclaration.Parameters);
            foreach (Constraint constraint in delegateDeclaration.Constraints)
                constraint.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="destructorDeclaration">item to parse</param>
        public virtual void VisitDestructorDeclaration(DestructorDeclaration destructorDeclaration)
        {
            WriteAttributes(destructorDeclaration.Attributes);
            WriteModifiers(destructorDeclaration.ModifierTokens);
            TypeDeclaration type = destructorDeclaration.Parent as TypeDeclaration;
            WriteMethodBody(destructorDeclaration.Body);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="directionExpression">item to parse</param>
        public virtual void VisitDirectionExpression(DirectionExpression directionExpression)
        {
            directionExpression.Expression.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="documentationReference">item to parse</param>
        public virtual void VisitDocumentationReference(DocumentationReference documentationReference)
        {

        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="doWhileStatement">item to parse</param>
        public virtual void VisitDoWhileStatement(DoWhileStatement doWhileStatement)
        {
            WriteEmbeddedStatement(doWhileStatement.EmbeddedStatement);
            doWhileStatement.Condition.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="emptyStatement">item to parse</param>
        public virtual void VisitEmptyStatement(EmptyStatement emptyStatement)
        {

        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="enumMemberDeclaration">item to parse</param>
        public virtual void VisitEnumMemberDeclaration(EnumMemberDeclaration enumMemberDeclaration)
        {
            WriteAttributes(enumMemberDeclaration.Attributes);
            WriteModifiers(enumMemberDeclaration.ModifierTokens);
            if (!enumMemberDeclaration.Initializer.IsNull)
                enumMemberDeclaration.Initializer.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="errorNode">item to parse</param>
        public virtual void VisitErrorNode(AstNode errorNode)
        {

        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="eventDeclaration">item to parse</param>
        public virtual void VisitEventDeclaration(EventDeclaration eventDeclaration)
        {
            WriteAttributes(eventDeclaration.Attributes);
            WriteModifiers(eventDeclaration.ModifierTokens);
            eventDeclaration.ReturnType.AcceptVisitor(this);
            WriteCommaSeparatedList(eventDeclaration.Variables);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="expressionStatement">item to parse</param>
        public virtual void VisitExpressionStatement(ExpressionStatement expressionStatement)
        {
            expressionStatement.Expression.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="externAliasDeclaration">item to parse</param>
        public virtual void VisitExternAliasDeclaration(ExternAliasDeclaration externAliasDeclaration)
        {

        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="fieldDeclaration">item to parse</param>
        public virtual void VisitFieldDeclaration(FieldDeclaration fieldDeclaration)
        {
            WriteAttributes(fieldDeclaration.Attributes);
            fieldDeclaration.ReturnType.AcceptVisitor(this);
            WriteCommaSeparatedList(fieldDeclaration.Variables);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="fixedFieldDeclaration">item to parse</param>
        public virtual void VisitFixedFieldDeclaration(FixedFieldDeclaration fixedFieldDeclaration)
        {
            WriteAttributes(fixedFieldDeclaration.Attributes);
            WriteModifiers(fixedFieldDeclaration.ModifierTokens);
            fixedFieldDeclaration.ReturnType.AcceptVisitor(this);
            WriteCommaSeparatedList(fixedFieldDeclaration.Variables);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="fixedStatement">item to parse</param>
        public virtual void VisitFixedStatement(FixedStatement fixedStatement)
        {
            fixedStatement.Type.AcceptVisitor(this);
            WriteCommaSeparatedList(fixedStatement.Variables);
            WriteEmbeddedStatement(fixedStatement.EmbeddedStatement);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="fixedVariableInitializer">item to parse</param>
        public virtual void VisitFixedVariableInitializer(FixedVariableInitializer fixedVariableInitializer)
        {
            if (!fixedVariableInitializer.CountExpression.IsNull)
                fixedVariableInitializer.CountExpression.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="foreachStatement">item to parse</param>
        public virtual void VisitForeachStatement(ForeachStatement foreachStatement)
        {
            foreachStatement.VariableType.AcceptVisitor(this);
            foreachStatement.VariableDesignation.AcceptVisitor(this);
            foreachStatement.InExpression.AcceptVisitor(this);
            WriteEmbeddedStatement(foreachStatement.EmbeddedStatement);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="forStatement">item to parse</param>
        public virtual void VisitForStatement(ForStatement forStatement)
        {
            WriteCommaSeparatedList(forStatement.Initializers);
            forStatement.Condition.AcceptVisitor(this);
            if (forStatement.Iterators.Any())
                WriteCommaSeparatedList(forStatement.Iterators);
            WriteEmbeddedStatement(forStatement.EmbeddedStatement);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="functionPointerType">item to parse</param>
        public virtual void VisitFunctionPointerType(FunctionPointerType functionPointerType)
        {
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="gotoCaseStatement">item to parse</param>
        public virtual void VisitGotoCaseStatement(GotoCaseStatement gotoCaseStatement)
        {
            gotoCaseStatement.LabelExpression.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="gotoDefaultStatement">item to parse</param>
        public virtual void VisitGotoDefaultStatement(GotoDefaultStatement gotoDefaultStatement)
        {
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="gotoStatement">item to parse</param>
        public virtual void VisitGotoStatement(GotoStatement gotoStatement)
        {
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="identifier">item to parse</param>
        public virtual void VisitIdentifier(Identifier identifier)
        {
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="identifierExpression">item to parse</param>
        public virtual void VisitIdentifierExpression(IdentifierExpression identifierExpression)
        {

            //WriteIdentifier(identifierExpression.IdentifierToken);
            //WriteTypeArguments(identifierExpression.TypeArguments);

        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="ifElseStatement">item to parse</param>
        public virtual void VisitIfElseStatement(IfElseStatement ifElseStatement)
        {
            ifElseStatement.Condition.AcceptVisitor(this);

            if (ifElseStatement.FalseStatement.IsNull)
                WriteEmbeddedStatement(ifElseStatement.TrueStatement);

            else
            {
                WriteEmbeddedStatement(ifElseStatement.TrueStatement);
                if (ifElseStatement.FalseStatement is IfElseStatement)
                    ifElseStatement.FalseStatement.AcceptVisitor(this);
                else
                    WriteEmbeddedStatement(ifElseStatement.FalseStatement);
            }
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="indexerDeclaration">item to parse</param>
        public virtual void VisitIndexerDeclaration(IndexerDeclaration indexerDeclaration)
        {

            WriteAttributes(indexerDeclaration.Attributes);
            WriteModifiers(indexerDeclaration.ModifierTokens);
            indexerDeclaration.ReturnType.AcceptVisitor(this);

            WriteCommaSeparatedList(indexerDeclaration.Parameters);

            if (indexerDeclaration.ExpressionBody.IsNull)
            {
                // output get/set in their original order
                foreach (AstNode node in indexerDeclaration.Children)
                    if (node.Role == IndexerDeclaration.GetterRole || node.Role == IndexerDeclaration.SetterRole)
                        node.AcceptVisitor(this);
            }
            else
                indexerDeclaration.ExpressionBody.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="indexerExpression">item to parse</param>
        public virtual void VisitIndexerExpression(IndexerExpression indexerExpression)
        {
            indexerExpression.Target.AcceptVisitor(this);
            WriteCommaSeparatedList(indexerExpression.Arguments);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="interpolatedStringExpression">item to parse</param>
        public virtual void VisitInterpolatedStringExpression(InterpolatedStringExpression interpolatedStringExpression)
        {
            foreach (var element in interpolatedStringExpression.Content)
                element.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="interpolatedStringText">item to parse</param>
        public virtual void VisitInterpolatedStringText(InterpolatedStringText interpolatedStringText)
        {

        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="interpolation">item to parse</param>
        public virtual void VisitInterpolation(Interpolation interpolation)
        {
            interpolation.Expression.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="invocationExpression">item to parse</param>
        public virtual void VisitInvocationExpression(InvocationExpression invocationExpression)
        {
            invocationExpression.Target.AcceptVisitor(this);
            WriteCommaSeparatedList(invocationExpression.Arguments);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="isExpression">item to parse</param>
        public virtual void VisitIsExpression(IsExpression isExpression)
        {
            isExpression.Expression.AcceptVisitor(this);
            isExpression.Type.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="labelStatement">item to parse</param>
        public virtual void VisitLabelStatement(LabelStatement labelStatement)
        {

        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="lambdaExpression">item to parse</param>
        public virtual void VisitLambdaExpression(LambdaExpression lambdaExpression)
        {
            if (LambdaNeedsParenthesis(lambdaExpression))
                WriteCommaSeparatedList(lambdaExpression.Parameters);
            else
                lambdaExpression.Parameters.Single().AcceptVisitor(this);

            if (lambdaExpression.Body is BlockStatement)
                WriteBlock((BlockStatement)lambdaExpression.Body);
            else
                lambdaExpression.Body.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="localFunctionDeclarationStatement">item to parse</param>
        public virtual void VisitLocalFunctionDeclarationStatement(LocalFunctionDeclarationStatement localFunctionDeclarationStatement)
        {
            localFunctionDeclarationStatement.Declaration.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="lockStatement">item to parse</param>
        public virtual void VisitLockStatement(LockStatement lockStatement)
        {
            lockStatement.Expression.AcceptVisitor(this);
            WriteEmbeddedStatement(lockStatement.EmbeddedStatement);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="memberReferenceExpression">item to parse</param>
        public virtual void VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression)
        {
            memberReferenceExpression.Target.AcceptVisitor(this);
            WriteTypeArguments(memberReferenceExpression.TypeArguments);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="memberType">item to parse</param>
        public virtual void VisitMemberType(MemberType memberType)
        {
            memberType.Target.AcceptVisitor(this);
            WriteTypeArguments(memberType.TypeArguments);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="methodDeclaration">item to parse</param>
        public virtual void VisitMethodDeclaration(MethodDeclaration methodDeclaration)
        {
            WriteAttributes(methodDeclaration.Attributes);
            WriteModifiers(methodDeclaration.ModifierTokens);
            methodDeclaration.ReturnType.AcceptVisitor(this);
            WriteTypeParameters(methodDeclaration.TypeParameters);
            foreach (Constraint constraint in methodDeclaration.Constraints)
            {
                constraint.AcceptVisitor(this);
            }
            WriteMethodBody(methodDeclaration.Body);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="namedArgumentExpression">item to parse</param>
        public virtual void VisitNamedArgumentExpression(NamedArgumentExpression namedArgumentExpression)
        {
            namedArgumentExpression.Expression.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="namedExpression">item to parse</param>
        public virtual void VisitNamedExpression(NamedExpression namedExpression)
        {
            namedExpression.Expression.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="namespaceDeclaration">item to parse</param>
        public virtual void VisitNamespaceDeclaration(NamespaceDeclaration namespaceDeclaration)
        {
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="nullNode">item to parse</param>
        public virtual void VisitNullNode(AstNode nullNode)
        {
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="nullReferenceExpression">item to parse</param>
        public virtual void VisitNullReferenceExpression(NullReferenceExpression nullReferenceExpression)
        {

        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="objectCreateExpression">item to parse</param>
        public virtual void VisitObjectCreateExpression(ObjectCreateExpression objectCreateExpression)
        {
            objectCreateExpression.Type.AcceptVisitor(this);
            bool useParenthesis = objectCreateExpression.Arguments.Any() || objectCreateExpression.Initializer.IsNull;
            // also use parenthesis if there is an '(' token
            if (!objectCreateExpression.LParToken.IsNull)
                useParenthesis = true;
            if (useParenthesis)
                WriteCommaSeparatedList(objectCreateExpression.Arguments);
            objectCreateExpression.Initializer.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="operatorDeclaration">item to parse</param>
        public virtual void VisitOperatorDeclaration(OperatorDeclaration operatorDeclaration)
        {
            WriteAttributes(operatorDeclaration.Attributes);
            WriteModifiers(operatorDeclaration.ModifierTokens);
            if (operatorDeclaration.OperatorType == OperatorType.Explicit)
            {
            }
            else if (operatorDeclaration.OperatorType == OperatorType.Implicit)
            {
            }
            else
            {
                operatorDeclaration.ReturnType.AcceptVisitor(this);
            }
            if (operatorDeclaration.OperatorType == OperatorType.Explicit
                || operatorDeclaration.OperatorType == OperatorType.Implicit)
            {
                operatorDeclaration.ReturnType.AcceptVisitor(this);
            }
            else
            {
            }
            WriteMethodBody(operatorDeclaration.Body);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="outVarDeclarationExpression">item to parse</param>
        public virtual void VisitOutVarDeclarationExpression(OutVarDeclarationExpression outVarDeclarationExpression)
        {
            outVarDeclarationExpression.Type.AcceptVisitor(this);
            outVarDeclarationExpression.Variable.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="parameterDeclaration">item to parse</param>
        public virtual void VisitParameterDeclaration(ParameterDeclaration parameterDeclaration)
        {
            WriteAttributes(parameterDeclaration.Attributes);
            parameterDeclaration.Type.AcceptVisitor(this);
            if (!parameterDeclaration.DefaultExpression.IsNull)
                parameterDeclaration.DefaultExpression.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="parenthesizedExpression">item to parse</param>
        public virtual void VisitParenthesizedExpression(ParenthesizedExpression parenthesizedExpression)
        {
            parenthesizedExpression.Expression.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="parenthesizedVariableDesignation">item to parse</param>
        public virtual void VisitParenthesizedVariableDesignation(ParenthesizedVariableDesignation parenthesizedVariableDesignation)
        {
            WriteCommaSeparatedList(parenthesizedVariableDesignation.VariableDesignations);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="placeholder">item to parse</param>
        /// <param name="pattern"></param>
        public virtual void VisitPatternPlaceholder(AstNode placeholder, Pattern pattern)
        {
            VisitNodeInPattern(pattern);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="pointerReferenceExpression">item to parse</param>
        public virtual void VisitPointerReferenceExpression(PointerReferenceExpression pointerReferenceExpression)
        {
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="preProcessorDirective">item to parse</param>
        public virtual void VisitPreProcessorDirective(PreProcessorDirective preProcessorDirective)
        {

        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="primitiveExpression">item to parse</param>
        public virtual void VisitPrimitiveExpression(PrimitiveExpression primitiveExpression)
        {

        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="primitiveType">item to parse</param>
        public virtual void VisitPrimitiveType(PrimitiveType primitiveType)
        {

        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="propertyDeclaration">item to parse</param>
        public virtual void VisitPropertyDeclaration(PropertyDeclaration propertyDeclaration)
        {
            WriteAttributes(propertyDeclaration.Attributes);
            WriteModifiers(propertyDeclaration.ModifierTokens);
            propertyDeclaration.ReturnType.AcceptVisitor(this);
            WritePrivateImplementationType(propertyDeclaration.PrivateImplementationType);
            if (propertyDeclaration.ExpressionBody.IsNull)
            {
                // output get/set in their original order
                foreach (AstNode node in propertyDeclaration.Children)
                {
                    if (node.Role == IndexerDeclaration.GetterRole || node.Role == IndexerDeclaration.SetterRole)
                        node.AcceptVisitor(this);
                }
                if (!propertyDeclaration.Initializer.IsNull)
                    propertyDeclaration.Initializer.AcceptVisitor(this);
            }
            else
                propertyDeclaration.ExpressionBody.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="queryContinuationClause">item to parse</param>
        public virtual void VisitQueryContinuationClause(QueryContinuationClause queryContinuationClause)
        {
            queryContinuationClause.PrecedingQuery.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="queryExpression">item to parse</param>
        public virtual void VisitQueryExpression(QueryExpression queryExpression)
        {
            foreach (var clause in queryExpression.Clauses)
                clause.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="queryFromClause">item to parse</param>
        public virtual void VisitQueryFromClause(QueryFromClause queryFromClause)
        {
            queryFromClause.Type.AcceptVisitor(this);
            queryFromClause.Expression.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="queryGroupClause">item to parse</param>
        public virtual void VisitQueryGroupClause(QueryGroupClause queryGroupClause)
        {
            queryGroupClause.Projection.AcceptVisitor(this);
            queryGroupClause.Key.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="queryJoinClause">item to parse</param>
        public virtual void VisitQueryJoinClause(QueryJoinClause queryJoinClause)
        {
            queryJoinClause.Type.AcceptVisitor(this);
            queryJoinClause.InExpression.AcceptVisitor(this);
            queryJoinClause.OnExpression.AcceptVisitor(this);
            queryJoinClause.EqualsExpression.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="queryLetClause">item to parse</param>
        public virtual void VisitQueryLetClause(QueryLetClause queryLetClause)
        {
            queryLetClause.Expression.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="queryOrderClause">item to parse</param>
        public virtual void VisitQueryOrderClause(QueryOrderClause queryOrderClause)
        {
            WriteCommaSeparatedList(queryOrderClause.Orderings);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="queryOrdering">item to parse</param>
        public virtual void VisitQueryOrdering(QueryOrdering queryOrdering)
        {
            queryOrdering.Expression.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="querySelectClause">item to parse</param>
        public virtual void VisitQuerySelectClause(QuerySelectClause querySelectClause)
        {
            querySelectClause.Expression.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="queryWhereClause">item to parse</param>
        public virtual void VisitQueryWhereClause(QueryWhereClause queryWhereClause)
        {
            queryWhereClause.Condition.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="returnStatement">item to parse</param>
        public virtual void VisitReturnStatement(ReturnStatement returnStatement)
        {

            if (!returnStatement.Expression.IsNull)
            {
                returnStatement.Expression.AcceptVisitor(this);
            }

        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="simpleType">item to parse</param>
        public virtual void VisitSimpleType(SimpleType simpleType)
        {
            WriteCommaSeparatedList(simpleType.TypeArguments);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="singleVariableDesignation">item to parse</param>
        public virtual void VisitSingleVariableDesignation(SingleVariableDesignation singleVariableDesignation)
        {
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="sizeOfExpression">item to parse</param>
        public virtual void VisitSizeOfExpression(SizeOfExpression sizeOfExpression)
        {
            sizeOfExpression.Type.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="stackAllocExpression">item to parse</param>
        public virtual void VisitStackAllocExpression(StackAllocExpression stackAllocExpression)
        {
            WriteCommaSeparatedList(new[] { stackAllocExpression.CountExpression });
            stackAllocExpression.Initializer.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="switchExpression">item to parse</param>
        public virtual void VisitSwitchExpression(SwitchExpression switchExpression)
        {
            switchExpression.Expression.AcceptVisitor(this);
            foreach (AstNode node in switchExpression.SwitchSections)
                node.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="switchExpressionSection">item to parse</param>
        public virtual void VisitSwitchExpressionSection(SwitchExpressionSection switchExpressionSection)
        {
            switchExpressionSection.Pattern.AcceptVisitor(this);
            switchExpressionSection.Body.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="switchSection">item to parse</param>
        public virtual void VisitSwitchSection(SwitchSection switchSection)
        {
            foreach (var label in switchSection.CaseLabels)
                label.AcceptVisitor(this);
            bool isBlock = switchSection.Statements.Count == 1 && switchSection.Statements.Single() is BlockStatement;
            foreach (var statement in switchSection.Statements)
                statement.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="switchStatement">item to parse</param>
        public virtual void VisitSwitchStatement(SwitchStatement switchStatement)
        {
            switchStatement.Expression.AcceptVisitor(this);
            foreach (var section in switchStatement.SwitchSections)
                section.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="thisReferenceExpression">item to parse</param>
        public virtual void VisitThisReferenceExpression(ThisReferenceExpression thisReferenceExpression)
        {

        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="throwExpression">item to parse</param>
        public virtual void VisitThrowExpression(ThrowExpression throwExpression)
        {
            throwExpression.Expression.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="throwStatement">item to parse</param>
        public virtual void VisitThrowStatement(ThrowStatement throwStatement)
        {
        
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="tryCatchStatement">item to parse</param>
        public virtual void VisitTryCatchStatement(TryCatchStatement tryCatchStatement)
        {
            WriteBlock(tryCatchStatement.TryBlock);
            foreach (var catchClause in tryCatchStatement.CatchClauses)
                catchClause.AcceptVisitor(this);
            if (!tryCatchStatement.FinallyBlock.IsNull)
                WriteBlock(tryCatchStatement.FinallyBlock);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="tupleExpression">item to parse</param>
        public virtual void VisitTupleExpression(TupleExpression tupleExpression)
        {
            Debug.Assert(tupleExpression.Elements.Count >= 2);
            WriteCommaSeparatedList(tupleExpression.Elements);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="tupleType">item to parse</param>
        public virtual void VisitTupleType(TupleAstType tupleType)
        {
            Debug.Assert(tupleType.Elements.Count >= 2);
            WriteCommaSeparatedList(tupleType.Elements);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="tupleTypeElement">item to parse</param>
        public virtual void VisitTupleTypeElement(TupleTypeElement tupleTypeElement)
        {
            tupleTypeElement.Type.AcceptVisitor(this);
            if (!tupleTypeElement.NameToken.IsNull)
                tupleTypeElement.NameToken.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="typeDeclaration">item to parse</param>
        public virtual void VisitTypeDeclaration(TypeDeclaration typeDeclaration)
        {
            WriteAttributes(typeDeclaration.Attributes);
            WriteModifiers(typeDeclaration.ModifierTokens);
            WriteTypeParameters(typeDeclaration.TypeParameters);
            if (typeDeclaration.BaseTypes.Any())
                WriteCommaSeparatedList(typeDeclaration.BaseTypes);
            foreach (Constraint constraint in typeDeclaration.Constraints)
                constraint.AcceptVisitor(this);

            foreach (var member in typeDeclaration.Members)
                member.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="typeOfExpression">item to parse</param>
        public virtual void VisitTypeOfExpression(TypeOfExpression typeOfExpression)
        {
            typeOfExpression.Type.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="typeParameterDeclaration">item to parse</param>
        public virtual void VisitTypeParameterDeclaration(TypeParameterDeclaration typeParameterDeclaration)
        {
            WriteAttributes(typeParameterDeclaration.Attributes);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="typeReferenceExpression">item to parse</param>
        public virtual void VisitTypeReferenceExpression(TypeReferenceExpression typeReferenceExpression)
        {
            typeReferenceExpression.Type.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="unaryOperatorExpression">item to parse</param>
        public virtual void VisitUnaryOperatorExpression(UnaryOperatorExpression unaryOperatorExpression)
        {
            unaryOperatorExpression.Expression.AcceptVisitor(this);            
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="uncheckedExpression">item to parse</param>
        public virtual void VisitUncheckedExpression(UncheckedExpression uncheckedExpression)
        {
            uncheckedExpression.Expression.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="uncheckedStatement">item to parse</param>
        public virtual void VisitUncheckedStatement(UncheckedStatement uncheckedStatement)
        {
            uncheckedStatement.Body.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="undocumentedExpression">item to parse</param>
        public virtual void VisitUndocumentedExpression(UndocumentedExpression undocumentedExpression)
        {
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="unsafeStatement">item to parse</param>
        public virtual void VisitUnsafeStatement(UnsafeStatement unsafeStatement)
        {
            unsafeStatement.Body.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="usingAliasDeclaration">item to parse</param>
        public virtual void VisitUsingAliasDeclaration(UsingAliasDeclaration usingAliasDeclaration)
        {
            usingAliasDeclaration.Import.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="usingDeclaration">item to parse</param>
        public virtual void VisitUsingDeclaration(UsingDeclaration usingDeclaration)
        {

        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="usingStatement">item to parse</param>
        public virtual void VisitUsingStatement(UsingStatement usingStatement)
        {

        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="variableDeclarationStatement">item to parse</param>
        public virtual void VisitVariableDeclarationStatement(VariableDeclarationStatement variableDeclarationStatement)
        {
            WriteModifiers(variableDeclarationStatement.GetChildrenByRole(VariableDeclarationStatement.ModifierRole));
            variableDeclarationStatement.Type.AcceptVisitor(this);
            WriteCommaSeparatedList(variableDeclarationStatement.Variables);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="variableInitializer">item to parse</param>
        public virtual void VisitVariableInitializer(VariableInitializer variableInitializer)
        {
            if (!variableInitializer.Initializer.IsNull)
                variableInitializer.Initializer.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="whileStatement">item to parse</param>
        public virtual void VisitWhileStatement(WhileStatement whileStatement)
        {
            whileStatement.Condition.AcceptVisitor(this);
            whileStatement.EmbeddedStatement.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="yieldBreakStatement">item to parse</param>
        public virtual void VisitYieldBreakStatement(YieldBreakStatement yieldBreakStatement)
        {
            
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="yieldReturnStatement">item to parse</param>
        public virtual void VisitYieldReturnStatement(YieldReturnStatement yieldReturnStatement)
        {
            yieldReturnStatement.Expression.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="identifier">item to parse</param>
        protected virtual void WriteIdentifier(string identifier)
        {
            AstType.Create(identifier).AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="attributes">item to parse</param>
        protected virtual void WriteAttributes(IEnumerable<AttributeSection> attributes)
        {
            foreach (AttributeSection attr in attributes)
                attr.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="modifierTokens">item to parse</param>
        protected virtual void WriteModifiers(IEnumerable<CSharpModifierToken> modifierTokens)
        {
            foreach (CSharpModifierToken modifier in modifierTokens)
                modifier.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="body">item to parse</param>
        protected virtual void WriteMethodBody(BlockStatement body)
        {
            if (!body.IsNull)
                WriteBlock(body);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="blockStatement">item to parse</param>
        protected virtual void WriteBlock(BlockStatement blockStatement)
        {
            foreach (var node in blockStatement.Statements)
                node.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="list">item to parse</param>
        protected virtual void WriteCommaSeparatedList(IEnumerable<AstNode> list)
        {
            foreach (AstNode node in list)
                node.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="typeParameters">item to parse</param>
        public virtual void WriteTypeParameters(IEnumerable<TypeParameterDeclaration> typeParameters)
        {
            WriteCommaSeparatedList(typeParameters);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="typeArguments">item to parse</param>
        protected virtual void WriteTypeArguments(IEnumerable<AstType> typeArguments)
        {
            if (typeArguments.Any())
                WriteCommaSeparatedList(typeArguments);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="elements">item to parse</param>
        protected virtual void PrintInitializerElements(AstNodeCollection<Expression> elements)
        {
            foreach (AstNode node in elements)
                node.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="embeddedStatement">item to parse</param>
        /// <param name="nlp"></param>
        protected virtual void WriteEmbeddedStatement(Statement embeddedStatement, NewLinePlacement nlp = NewLinePlacement.NewLine)
        {
            if (embeddedStatement.IsNull)
                return;
            BlockStatement block = embeddedStatement as BlockStatement;
            if (block != null)
                WriteBlock(block);
            else
                embeddedStatement.AcceptVisitor(this);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="lambdaExpression">item to parse</param>
        protected bool LambdaNeedsParenthesis(LambdaExpression lambdaExpression)
        {
            if (lambdaExpression.Parameters.Count != 1)
            {
                return true;
            }
            var p = lambdaExpression.Parameters.Single();
            return !(p.Type.IsNull && p.ParameterModifier == ParameterModifier.None);
        }

        void VisitNodeInPattern(INode childNode)
        {
            if (childNode is AstNode)
            {
                ((AstNode)childNode).AcceptVisitor(this);
            }
            else if (childNode is Choice)
            {
                VisitChoice((Choice)childNode);
            }
            else if (childNode is NamedNode)
            {
                VisitNamedNode((NamedNode)childNode);
            }
            else if (childNode is OptionalNode)
            {
                VisitNodeInPattern(((OptionalNode)childNode).ChildNode);
            }
            else if (childNode is Repeat)
            {
                VisitRepeat((Repeat)childNode);
            }
        }

        void VisitChoice(Choice choice)
        {
            foreach (INode alternative in choice)
                VisitNodeInPattern(alternative);
        }

        void VisitNamedNode(NamedNode namedNode)
        {
            if (!string.IsNullOrEmpty(namedNode.GroupName))
                WriteIdentifier(namedNode.GroupName);
            VisitNodeInPattern(namedNode.ChildNode);
        }

        void VisitRepeat(Repeat repeat)
        {
            if (repeat.MinCount != 0 || repeat.MaxCount != int.MaxValue)
            {
                WriteIdentifier(repeat.MinCount.ToString());
                WriteIdentifier(repeat.MaxCount.ToString());
            }
            VisitNodeInPattern(repeat.ChildNode);
        }

        /// <summary>
        /// Visits the children of the node.
        /// </summary>
        /// <param name="privateImplementationType"></param>
        protected virtual void WritePrivateImplementationType(AstType privateImplementationType)
        {
            if (!privateImplementationType.IsNull)
            {
                privateImplementationType.AcceptVisitor(this);
            }
        }

    }

}
