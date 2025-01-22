using System;
using System.Collections.Generic;
using ICSharpCode.Decompiler.CSharp.Syntax;
using ICSharpCode.Decompiler.CSharp.Syntax.PatternMatching;

namespace Bb.Decompilers
{


    public class InterceptorAstVisitor : AstVisitorBase
    {

        public InterceptorAstVisitor()
        {
            this._dicAction = new Dictionary<Type, Action<object>>();
            this._dicFilter = new Dictionary<Type, Func<object, bool>>();
        }


        private void TryToIntercept<T>(T item)
            where T : AstNode
        {

            if (this._dicFilter.TryGetValue(typeof(T), out Func<object, bool> filter))
                if (!filter(item))
                    return;

            if (this._dicAction.TryGetValue(typeof(T), out Action<object> action))
                action(item);
        }

        internal void Add<T>(Func<T, bool> filter, Action<T> action)
            where T : AstNode
        {

            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            if (action == null)
                throw new ArgumentNullException(nameof(action));


            var type = typeof(T);


            if (this._dicFilter.TryGetValue(type, out var filter1))
                throw new InvalidOperationException("Interceptor already has an action.");
            else
                this._dicFilter.Add(typeof(T), c => filter((T)c));


            if (this._dicAction.TryGetValue(type, out var action1))
                throw new InvalidOperationException("Interceptor already has an action.");
            else
                this._dicAction.Add(typeof(T), c => action((T)c));

        }

        internal void Add<T>(Action<T> action)
            where T : AstNode
        {

            if (action == null)
                throw new ArgumentNullException(nameof(action));

            var type = typeof(T);

            if (this._dicAction.TryGetValue(type, out var action1))
                throw new InvalidOperationException("Interceptor already has an action.");

            else
                this._dicAction.Add(typeof(T), c =>
                {
                    action((T)c);
                });

        }



        public override void VisitAccessor(Accessor accessor)
        {
            TryToIntercept(accessor);
            base.VisitAccessor(accessor);
        }

        public override void VisitAnonymousMethodExpression(AnonymousMethodExpression anonymousMethodExpression)
        {
            TryToIntercept(anonymousMethodExpression);
            base.VisitAnonymousMethodExpression(anonymousMethodExpression);
        }

        public override void VisitAnonymousTypeCreateExpression(AnonymousTypeCreateExpression anonymousTypeCreateExpression)
        {
            TryToIntercept(anonymousTypeCreateExpression); base.VisitAnonymousTypeCreateExpression(anonymousTypeCreateExpression);
        }

        public override void VisitArrayCreateExpression(ArrayCreateExpression arrayCreateExpression)
        {
            TryToIntercept(arrayCreateExpression);
            base.VisitArrayCreateExpression(arrayCreateExpression);
        }

        public override void VisitArrayInitializerExpression(ArrayInitializerExpression arrayInitializerExpression)
        {
            TryToIntercept(arrayInitializerExpression);
            base.VisitArrayInitializerExpression(arrayInitializerExpression);
        }

        public override void VisitArraySpecifier(ArraySpecifier arraySpecifier)
        {
            TryToIntercept(arraySpecifier);
            base.VisitArraySpecifier(arraySpecifier);
        }

        public override void VisitAsExpression(AsExpression asExpression)
        {
            TryToIntercept(asExpression); base.VisitAsExpression(asExpression);
        }

        public override void VisitAssignmentExpression(AssignmentExpression assignmentExpression)
        {
            TryToIntercept(assignmentExpression);
            base.VisitAssignmentExpression(assignmentExpression);
        }

        public override void VisitAttribute(ICSharpCode.Decompiler.CSharp.Syntax.Attribute attribute)
        {
            TryToIntercept(attribute);
            base.VisitAttribute(attribute);
        }

        public override void VisitAttributeSection(AttributeSection attributeSection)
        {
            TryToIntercept(attributeSection);
            base.VisitAttributeSection(attributeSection);
        }

        public override void VisitBaseReferenceExpression(BaseReferenceExpression baseReferenceExpression)
        {
            TryToIntercept(baseReferenceExpression);
            base.VisitBaseReferenceExpression(baseReferenceExpression);
        }

        public override void VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression)
        {
            TryToIntercept(binaryOperatorExpression);
            base.VisitBinaryOperatorExpression(binaryOperatorExpression);
        }

        public override void VisitBlockStatement(BlockStatement blockStatement)
        {
            TryToIntercept(blockStatement);
            base.VisitBlockStatement(blockStatement);
        }

        public override void VisitBreakStatement(BreakStatement breakStatement)
        {
            TryToIntercept(breakStatement);
            base.VisitBreakStatement(breakStatement);
        }

        public override void VisitCaseLabel(CaseLabel caseLabel)
        {
            TryToIntercept(caseLabel);
            base.VisitCaseLabel(caseLabel);
        }

        public override void VisitCastExpression(CastExpression castExpression)
        {
            TryToIntercept(castExpression);
            base.VisitCastExpression(castExpression);
        }

        public override void VisitCatchClause(CatchClause catchClause)
        {
            TryToIntercept(catchClause);
            base.VisitCatchClause(catchClause);
        }

        public override void VisitCheckedExpression(CheckedExpression checkedExpression)
        {
            TryToIntercept(checkedExpression);
            base.VisitCheckedExpression(checkedExpression);
        }

        public override void VisitCheckedStatement(CheckedStatement checkedStatement)
        {
            TryToIntercept(checkedStatement);
            base.VisitCheckedStatement(checkedStatement);
        }

        public override void VisitComment(Comment comment)
        {
            TryToIntercept(comment);
            base.VisitComment(comment);
        }


        public override void VisitComposedType(ComposedType composedType)
        {
            TryToIntercept(composedType);
            base.VisitComposedType(composedType);
        }


        public override void VisitConditionalExpression(ConditionalExpression conditionalExpression)
        {
            TryToIntercept(conditionalExpression);
            base.VisitConditionalExpression(conditionalExpression);
        }

        public override void VisitConstraint(Constraint constraint)
        {
            TryToIntercept(constraint);
            base.VisitConstraint(constraint);
        }

        public override void VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration)
        {
            TryToIntercept(constructorDeclaration);
            base.VisitConstructorDeclaration(constructorDeclaration);
        }

        public override void VisitConstructorInitializer(ConstructorInitializer constructorInitializer)
        {
            TryToIntercept(constructorInitializer);
            base.VisitConstructorInitializer(constructorInitializer);
        }

        public override void VisitContinueStatement(ContinueStatement continueStatement)
        {
            TryToIntercept(continueStatement);
            base.VisitContinueStatement(continueStatement);
        }

        public override void VisitCSharpTokenNode(CSharpTokenNode cSharpTokenNode)
        {
            TryToIntercept(cSharpTokenNode);
            base.VisitCSharpTokenNode(cSharpTokenNode);
        }

        public override void VisitCustomEventDeclaration(CustomEventDeclaration customEventDeclaration)
        {
            TryToIntercept(customEventDeclaration);
            base.VisitCustomEventDeclaration(customEventDeclaration);
        }

        public override void VisitDeclarationExpression(DeclarationExpression declarationExpression)
        {
            TryToIntercept(declarationExpression);
            base.VisitDeclarationExpression(declarationExpression);
        }

        public override void VisitDefaultValueExpression(DefaultValueExpression defaultValueExpression)
        {
            TryToIntercept(defaultValueExpression);
            base.VisitDefaultValueExpression(defaultValueExpression);
        }

        public override void VisitDelegateDeclaration(DelegateDeclaration delegateDeclaration)
        {
            TryToIntercept(delegateDeclaration);
            base.VisitDelegateDeclaration(delegateDeclaration);
        }

        public override void VisitDestructorDeclaration(DestructorDeclaration destructorDeclaration)
        {
            TryToIntercept(destructorDeclaration);
            base.VisitDestructorDeclaration(destructorDeclaration);
        }

        public override void VisitDirectionExpression(DirectionExpression directionExpression)
        {
            TryToIntercept(directionExpression);
            base.VisitDirectionExpression(directionExpression);
        }

        public override void VisitDocumentationReference(DocumentationReference documentationReference)
        {
            TryToIntercept(documentationReference);
            base.VisitDocumentationReference(documentationReference);
        }

        public override void VisitDoWhileStatement(DoWhileStatement doWhileStatement)
        {
            TryToIntercept(doWhileStatement);
            base.VisitDoWhileStatement(doWhileStatement);
        }

        public override void VisitEmptyStatement(EmptyStatement emptyStatement)
        {
            TryToIntercept(emptyStatement);
            base.VisitEmptyStatement(emptyStatement);
        }

        public override void VisitEnumMemberDeclaration(EnumMemberDeclaration enumMemberDeclaration)
        {
            TryToIntercept(enumMemberDeclaration);
            base.VisitEnumMemberDeclaration(enumMemberDeclaration);
        }

        public override void VisitErrorNode(AstNode errorNode)
        {
            TryToIntercept(errorNode);
            base.VisitErrorNode(errorNode);
        }

        public override void VisitEventDeclaration(EventDeclaration eventDeclaration)
        {
            TryToIntercept(eventDeclaration);
            base.VisitEventDeclaration(eventDeclaration);
        }

        public override void VisitExpressionStatement(ExpressionStatement expressionStatement)
        {
            TryToIntercept(expressionStatement);
            base.VisitExpressionStatement(expressionStatement);
        }

        public override void VisitExternAliasDeclaration(ExternAliasDeclaration externAliasDeclaration)
        {
            TryToIntercept(externAliasDeclaration);
            base.VisitExternAliasDeclaration(externAliasDeclaration);
        }

        public override void VisitFieldDeclaration(FieldDeclaration fieldDeclaration)
        {
            TryToIntercept(fieldDeclaration);
            base.VisitFieldDeclaration(fieldDeclaration);
        }

        public override void VisitFixedFieldDeclaration(FixedFieldDeclaration fixedFieldDeclaration)
        {
            TryToIntercept(fixedFieldDeclaration); base.VisitFixedFieldDeclaration(fixedFieldDeclaration);
        }

        public override void VisitFixedStatement(FixedStatement fixedStatement)
        {
            TryToIntercept(fixedStatement); base.VisitFixedStatement(fixedStatement);
        }

        public override void VisitFixedVariableInitializer(FixedVariableInitializer fixedVariableInitializer)
        {
            TryToIntercept(fixedVariableInitializer);
            base.VisitFixedVariableInitializer(fixedVariableInitializer);
        }

        public override void VisitForeachStatement(ForeachStatement foreachStatement)
        {
            TryToIntercept(foreachStatement);
            base.VisitForeachStatement(foreachStatement);
        }

        public override void VisitForStatement(ForStatement forStatement)
        {
            TryToIntercept(forStatement);
            base.VisitForStatement(forStatement);
        }

        public override void VisitFunctionPointerType(FunctionPointerType functionPointerType)
        {
            TryToIntercept(functionPointerType);
            base.VisitFunctionPointerType(functionPointerType);
        }

        public override void VisitGotoCaseStatement(GotoCaseStatement gotoCaseStatement)
        {
            TryToIntercept(gotoCaseStatement);
            base.VisitGotoCaseStatement(gotoCaseStatement);
        }

        public override void VisitGotoDefaultStatement(GotoDefaultStatement gotoDefaultStatement)
        {
            TryToIntercept(gotoDefaultStatement);
            base.VisitGotoDefaultStatement(gotoDefaultStatement);
        }

        public override void VisitGotoStatement(GotoStatement gotoStatement)
        {
            TryToIntercept(gotoStatement);
            base.VisitGotoStatement(gotoStatement);
        }

        public override void VisitIdentifier(Identifier identifier)
        {
            TryToIntercept(identifier);
            base.VisitIdentifier(identifier);
        }

        public override void VisitIdentifierExpression(IdentifierExpression identifierExpression)
        {
            TryToIntercept(identifierExpression);
            base.VisitIdentifierExpression(identifierExpression);
        }

        public override void VisitIfElseStatement(IfElseStatement ifElseStatement)
        {
            TryToIntercept(ifElseStatement);
            base.VisitIfElseStatement(ifElseStatement);
        }

        public override void VisitIndexerDeclaration(IndexerDeclaration indexerDeclaration)
        {
            TryToIntercept(indexerDeclaration);
            base.VisitIndexerDeclaration(indexerDeclaration);
        }

        public override void VisitIndexerExpression(IndexerExpression indexerExpression)
        {
            TryToIntercept(indexerExpression);
            base.VisitIndexerExpression(indexerExpression);
        }

        public override void VisitInterpolatedStringExpression(InterpolatedStringExpression interpolatedStringExpression)
        {
            TryToIntercept(interpolatedStringExpression);
            base.VisitInterpolatedStringExpression(interpolatedStringExpression);
        }

        public override void VisitInterpolatedStringText(InterpolatedStringText interpolatedStringText)
        {
            TryToIntercept(interpolatedStringText);
            base.VisitInterpolatedStringText(interpolatedStringText);
        }

        public override void VisitInterpolation(Interpolation interpolation)
        {
            TryToIntercept(interpolation);
            base.VisitInterpolation(interpolation);
        }

        public override void VisitInvocationExpression(InvocationExpression invocationExpression)
        {
            TryToIntercept(invocationExpression);
            base.VisitInvocationExpression(invocationExpression);
        }

        public override void VisitIsExpression(IsExpression isExpression)
        {
            TryToIntercept(isExpression);
            base.VisitIsExpression(isExpression);
        }

        public override void VisitLabelStatement(LabelStatement labelStatement)
        {
            TryToIntercept(labelStatement);
            base.VisitLabelStatement(labelStatement);
        }

        public override void VisitLambdaExpression(LambdaExpression lambdaExpression)
        {
            TryToIntercept(lambdaExpression);
            base.VisitLambdaExpression(lambdaExpression);
        }

        public override void VisitLocalFunctionDeclarationStatement(LocalFunctionDeclarationStatement localFunctionDeclarationStatement)
        {
            TryToIntercept(localFunctionDeclarationStatement);
            base.VisitLocalFunctionDeclarationStatement(localFunctionDeclarationStatement);
        }

        public override void VisitLockStatement(LockStatement lockStatement)
        {
            TryToIntercept(lockStatement);
            base.VisitLockStatement(lockStatement);
        }

        public override void VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression)
        {
            TryToIntercept(memberReferenceExpression);
            base.VisitMemberReferenceExpression(memberReferenceExpression);
        }

        public override void VisitMemberType(MemberType memberType)
        {
            TryToIntercept(memberType);
            base.VisitMemberType(memberType);
        }

        public override void VisitMethodDeclaration(MethodDeclaration methodDeclaration)
        {
            TryToIntercept(methodDeclaration);
            base.VisitMethodDeclaration(methodDeclaration);
        }

        public override void VisitNamedArgumentExpression(NamedArgumentExpression namedArgumentExpression)
        {
            TryToIntercept(namedArgumentExpression);
            base.VisitNamedArgumentExpression(namedArgumentExpression);
        }

        public override void VisitNamedExpression(NamedExpression namedExpression)
        {
            TryToIntercept(namedExpression);
            base.VisitNamedExpression(namedExpression);
        }

        public override void VisitNamespaceDeclaration(NamespaceDeclaration namespaceDeclaration)
        {
            TryToIntercept(namespaceDeclaration);
            base.VisitNamespaceDeclaration(namespaceDeclaration);
        }

        public override void VisitNullNode(AstNode nullNode)
        {
            TryToIntercept(nullNode);
            base.VisitNullNode(nullNode);
        }

        public override void VisitNullReferenceExpression(NullReferenceExpression nullReferenceExpression)
        {
            TryToIntercept(nullReferenceExpression);
            base.VisitNullReferenceExpression(nullReferenceExpression);
        }

        public override void VisitObjectCreateExpression(ObjectCreateExpression objectCreateExpression)
        {
            TryToIntercept(objectCreateExpression);
            base.VisitObjectCreateExpression(objectCreateExpression);
        }

        public override void VisitOperatorDeclaration(OperatorDeclaration operatorDeclaration)
        {
            TryToIntercept(operatorDeclaration);
            base.VisitOperatorDeclaration(operatorDeclaration);
        }

        public override void VisitOutVarDeclarationExpression(OutVarDeclarationExpression outVarDeclarationExpression)
        {
            TryToIntercept(outVarDeclarationExpression);
            base.VisitOutVarDeclarationExpression(outVarDeclarationExpression);
        }

        public override void VisitParameterDeclaration(ParameterDeclaration parameterDeclaration)
        {
            TryToIntercept(parameterDeclaration); base.VisitParameterDeclaration(parameterDeclaration);
        }

        public override void VisitParenthesizedExpression(ParenthesizedExpression parenthesizedExpression)
        {
            TryToIntercept(parenthesizedExpression);
            base.VisitParenthesizedExpression(parenthesizedExpression);
        }

        public override void VisitParenthesizedVariableDesignation(ParenthesizedVariableDesignation parenthesizedVariableDesignation)
        {
            TryToIntercept(parenthesizedVariableDesignation);
            base.VisitParenthesizedVariableDesignation(parenthesizedVariableDesignation);
        }

        public override void VisitPatternPlaceholder(AstNode placeholder, Pattern pattern)
        {
            TryToIntercept(placeholder);
            base.VisitPatternPlaceholder(placeholder, pattern);
        }

        public override void VisitPointerReferenceExpression(PointerReferenceExpression pointerReferenceExpression)
        {
            TryToIntercept(pointerReferenceExpression);
            base.VisitPointerReferenceExpression(pointerReferenceExpression);
        }

        public override void VisitPreProcessorDirective(PreProcessorDirective preProcessorDirective)
        {
            TryToIntercept(preProcessorDirective);
            base.VisitPreProcessorDirective(preProcessorDirective);
        }

        public override void VisitPrimitiveExpression(PrimitiveExpression primitiveExpression)
        {
            TryToIntercept(primitiveExpression);
            base.VisitPrimitiveExpression(primitiveExpression);
        }

        public override void VisitPrimitiveType(PrimitiveType primitiveType)
        {
            TryToIntercept(primitiveType);
            base.VisitPrimitiveType(primitiveType);
        }

        public override void VisitPropertyDeclaration(PropertyDeclaration propertyDeclaration)
        {
            TryToIntercept(propertyDeclaration);
            base.VisitPropertyDeclaration(propertyDeclaration);
        }

        public override void VisitQueryContinuationClause(QueryContinuationClause queryContinuationClause)
        {
            TryToIntercept(queryContinuationClause);
            base.VisitQueryContinuationClause(queryContinuationClause);
        }

        public override void VisitQueryExpression(QueryExpression queryExpression)
        {
            TryToIntercept(queryExpression);
            base.VisitQueryExpression(queryExpression);
        }

        public override void VisitQueryFromClause(QueryFromClause queryFromClause)
        {
            TryToIntercept(queryFromClause);
            base.VisitQueryFromClause(queryFromClause);
        }

        public override void VisitQueryGroupClause(QueryGroupClause queryGroupClause)
        {
            TryToIntercept(queryGroupClause);
            base.VisitQueryGroupClause(queryGroupClause);
        }

        public override void VisitQueryJoinClause(QueryJoinClause queryJoinClause)
        {
            TryToIntercept(queryJoinClause);
            base.VisitQueryJoinClause(queryJoinClause);
        }

        public override void VisitQueryLetClause(QueryLetClause queryLetClause)
        {
            TryToIntercept(queryLetClause);
            base.VisitQueryLetClause(queryLetClause);
        }

        public override void VisitQueryOrderClause(QueryOrderClause queryOrderClause)
        {
            TryToIntercept(queryOrderClause);
            base.VisitQueryOrderClause(queryOrderClause);
        }

        public override void VisitQueryOrdering(QueryOrdering queryOrdering)
        {
            TryToIntercept(queryOrdering);
            base.VisitQueryOrdering(queryOrdering);
        }

        public override void VisitQuerySelectClause(QuerySelectClause querySelectClause)
        {
            TryToIntercept(querySelectClause);
            base.VisitQuerySelectClause(querySelectClause);
        }

        public override void VisitQueryWhereClause(QueryWhereClause queryWhereClause)
        {
            TryToIntercept(queryWhereClause);
            base.VisitQueryWhereClause(queryWhereClause);
        }

        public override void VisitReturnStatement(ReturnStatement returnStatement)
        {
            TryToIntercept(returnStatement);
            base.VisitReturnStatement(returnStatement);
        }

        public override void VisitSimpleType(SimpleType simpleType)
        {
            TryToIntercept(simpleType);
            base.VisitSimpleType(simpleType);
        }

        public override void VisitSingleVariableDesignation(SingleVariableDesignation singleVariableDesignation)
        {
            TryToIntercept(singleVariableDesignation);
            base.VisitSingleVariableDesignation(singleVariableDesignation);
        }

        public override void VisitSizeOfExpression(SizeOfExpression sizeOfExpression)
        {
            TryToIntercept(sizeOfExpression);
            base.VisitSizeOfExpression(sizeOfExpression);
        }

        public override void VisitStackAllocExpression(StackAllocExpression stackAllocExpression)
        {
            TryToIntercept(stackAllocExpression);
            base.VisitStackAllocExpression(stackAllocExpression);
        }

        public override void VisitSwitchExpression(SwitchExpression switchExpression)
        {
            TryToIntercept(switchExpression);
            base.VisitSwitchExpression(switchExpression);
        }

        public override void VisitSwitchExpressionSection(SwitchExpressionSection switchExpressionSection)
        {
            TryToIntercept(switchExpressionSection);
            base.VisitSwitchExpressionSection(switchExpressionSection);
        }

        public override void VisitSwitchSection(SwitchSection switchSection)
        {
            TryToIntercept(switchSection);
            base.VisitSwitchSection(switchSection);
        }

        public override void VisitSwitchStatement(SwitchStatement switchStatement)
        {
            TryToIntercept(switchStatement);
            base.VisitSwitchStatement(switchStatement);
        }

        public override void VisitSyntaxTree(SyntaxTree syntaxTree)
        {
            TryToIntercept(syntaxTree);
            base.VisitSyntaxTree(syntaxTree);
        }

        public override void VisitThisReferenceExpression(ThisReferenceExpression thisReferenceExpression)
        {
            TryToIntercept(thisReferenceExpression);
            base.VisitThisReferenceExpression(thisReferenceExpression);
        }

        public override void VisitThrowExpression(ThrowExpression throwExpression)
        {
            TryToIntercept(throwExpression);
            base.VisitThrowExpression(throwExpression);
        }

        public override void VisitThrowStatement(ThrowStatement throwStatement)
        {
            TryToIntercept(throwStatement);
            base.VisitThrowStatement(throwStatement);
        }

        public override void VisitTryCatchStatement(TryCatchStatement tryCatchStatement)
        {
            TryToIntercept(tryCatchStatement);
            base.VisitTryCatchStatement(tryCatchStatement);
        }

        public override void VisitTupleExpression(TupleExpression tupleExpression)
        {
            TryToIntercept(tupleExpression);
            base.VisitTupleExpression(tupleExpression);
        }

        public override void VisitTupleType(TupleAstType tupleType)
        {
            TryToIntercept(tupleType);
            base.VisitTupleType(tupleType);
        }

        public override void VisitTupleTypeElement(TupleTypeElement tupleTypeElement)
        {
            TryToIntercept(tupleTypeElement);
            base.VisitTupleTypeElement(tupleTypeElement);
        }

        public override void VisitTypeDeclaration(TypeDeclaration typeDeclaration)
        {
            TryToIntercept(typeDeclaration);
            base.VisitTypeDeclaration(typeDeclaration);
        }

        public override void VisitTypeOfExpression(TypeOfExpression typeOfExpression)
        {
            TryToIntercept(typeOfExpression);
            base.VisitTypeOfExpression(typeOfExpression);
        }

        public override void VisitTypeParameterDeclaration(TypeParameterDeclaration typeParameterDeclaration)
        {
            TryToIntercept(typeParameterDeclaration);
            base.VisitTypeParameterDeclaration(typeParameterDeclaration);
        }

        public override void VisitTypeReferenceExpression(TypeReferenceExpression typeReferenceExpression)
        {
            TryToIntercept(typeReferenceExpression);
            base.VisitTypeReferenceExpression(typeReferenceExpression);
        }

        public override void VisitUnaryOperatorExpression(UnaryOperatorExpression unaryOperatorExpression)
        {
            TryToIntercept(unaryOperatorExpression);
            base.VisitUnaryOperatorExpression(unaryOperatorExpression);
        }

        public override void VisitUncheckedExpression(UncheckedExpression uncheckedExpression)
        {
            TryToIntercept(uncheckedExpression);
            base.VisitUncheckedExpression(uncheckedExpression);
        }

        public override void VisitUncheckedStatement(UncheckedStatement uncheckedStatement)
        {
            TryToIntercept(uncheckedStatement);
            base.VisitUncheckedStatement(uncheckedStatement);
        }

        public override void VisitUndocumentedExpression(UndocumentedExpression undocumentedExpression)
        {
            TryToIntercept(undocumentedExpression);
            base.VisitUndocumentedExpression(undocumentedExpression);
        }

        public override void VisitUnsafeStatement(UnsafeStatement unsafeStatement)
        {
            TryToIntercept(unsafeStatement);
            base.VisitUnsafeStatement(unsafeStatement);
        }

        public override void VisitUsingAliasDeclaration(UsingAliasDeclaration usingAliasDeclaration)
        {
            TryToIntercept(usingAliasDeclaration);
            base.VisitUsingAliasDeclaration(usingAliasDeclaration);
        }

        public override void VisitUsingDeclaration(UsingDeclaration usingDeclaration)
        {
            TryToIntercept(usingDeclaration);
            base.VisitUsingDeclaration(usingDeclaration);
        }

        public override void VisitUsingStatement(UsingStatement usingStatement)
        {
            TryToIntercept(usingStatement);
            base.VisitUsingStatement(usingStatement);
        }

        public override void VisitVariableDeclarationStatement(VariableDeclarationStatement variableDeclarationStatement)
        {
            TryToIntercept(variableDeclarationStatement);
            base.VisitVariableDeclarationStatement(variableDeclarationStatement);
        }

        public override void VisitVariableInitializer(VariableInitializer variableInitializer)
        {
            TryToIntercept(variableInitializer);
            base.VisitVariableInitializer(variableInitializer);
        }

        public override void VisitWhileStatement(WhileStatement whileStatement)
        {
            TryToIntercept(whileStatement);
            base.VisitWhileStatement(whileStatement);
        }

        public override void VisitYieldBreakStatement(YieldBreakStatement yieldBreakStatement)
        {
            TryToIntercept(yieldBreakStatement);
            base.VisitYieldBreakStatement(yieldBreakStatement);
        }

        public override void VisitYieldReturnStatement(YieldReturnStatement yieldReturnStatement)
        {
            TryToIntercept(yieldReturnStatement);
            base.VisitYieldReturnStatement(yieldReturnStatement);
        }


        private readonly Dictionary<Type, Action<object>> _dicAction;
        private readonly Dictionary<Type, Func<object, bool>> _dicFilter;
    }


}
