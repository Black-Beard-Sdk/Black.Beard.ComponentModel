using ICSharpCode.Decompiler.CSharp.Syntax;
using ICSharpCode.Decompiler.CSharp.Syntax.PatternMatching;
using System;
using ICSharpCode.Decompiler.TypeSystem;
using ICSharpCode.Decompiler.Semantics;
using ICSharpCode.Decompiler.Metadata;
using ICSharpCode.Decompiler.CSharp;
using System.Reflection;

namespace Bb.Decompilers
{

    public enum SemanticEnum
    {
        Undefined,
        TypeReference,
        TypeOf,
        TypeIs,
        Tuple,
        Throw,
        SizeOf,
        OutVar,
        Operator,
        Namespace,
        NamedArgument,
        Invocation,
        InterpolatedString,
        InitializedObject,
        ForEach,
        Error,
        Conversion,
        ByReference,
        ArrayAccess,
        Member,
        Local,
        Constant,
        This,
        LocalVariable
    }

    public static partial class InterceptorAstVisitorExtension
    {

        /// <summary>
        /// Try to cast in IdentifierExpression
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IdentifierExpression? AsIdentifier(this Expression self)
        {
            if (self is IdentifierExpression id)
                return id;
            return null;
        }

        /// <summary>
        /// Try to resolve the semantic of the object
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static SemanticEnum ResolveSemantic(this IAnnotatable self)
        {

            var semantic = self.Annotation(typeof(ResolveResult));
            switch (semantic)
            {


                case TypeResolveResult a1:
                    return SemanticEnum.TypeReference;

                case ILVariableResolveResult a23:
                    return SemanticEnum.LocalVariable;

                case TypeOfResolveResult a22:
                    return SemanticEnum.TypeOf;

                case TypeIsResolveResult a21:
                    return SemanticEnum.TypeIs;

                case TupleResolveResult a20:
                    return SemanticEnum.Tuple;

                case ThrowResolveResult a19:
                    return SemanticEnum.Throw;

                case ThisResolveResult a18:
                    return SemanticEnum.This;

                case SizeOfResolveResult a17:
                    return SemanticEnum.SizeOf;

                case OutVarResolveResult a16:
                    return SemanticEnum.OutVar;

                case OperatorResolveResult a15:
                    return SemanticEnum.Operator;

                case NamespaceResolveResult a14:
                    return SemanticEnum.Namespace;

                case NamedArgumentResolveResult a13:
                    return SemanticEnum.NamedArgument;

                case InvocationResolveResult a11:
                    return SemanticEnum.Invocation;

                case InterpolatedStringResolveResult a10:
                    return SemanticEnum.InterpolatedString;

                case InitializedObjectResolveResult a9:
                    return SemanticEnum.InitializedObject;

                case ForEachResolveResult a8:
                    return SemanticEnum.ForEach;

                case ErrorResolveResult a7:
                    return SemanticEnum.Error;

                case ConversionResolveResult a6:
                    return SemanticEnum.Conversion;

                case ByReferenceResolveResult a4:
                    return SemanticEnum.ByReference;

                case ArrayAccessResolveResult a3:
                    return SemanticEnum.ArrayAccess;

                case MemberResolveResult a23:
                    return SemanticEnum.Member;

                case LocalResolveResult a2:
                    return SemanticEnum.Local;

                case ConstantResolveResult a5:
                    return SemanticEnum.Constant;

                case UnknownMemberResolveResult a23:
                case null:
                default:
                    return SemanticEnum.Undefined;

            }


            throw new NotImplementedException(semantic.GetType().Name);

        }

        /// <summary>
        /// Try to resolve the semantic of the object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static T ResolveSemantic<T>(this IAnnotatable self) where T : ResolveResult
        {
            foreach (var item in self.Annotations)
                if (item is T t)
                    return t;
            //var semantic = self.Annotation(typeof(T)) as T;
            //return semantic;
            return default;
        }

        /// <summary>
        /// Return true if the type of the object is the same as the type
        /// </summary>
        /// <param name="self"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool Match(this ObjectCreateExpression self, Type type)
        {

            var typeReference = self.Type.ResolveSemantic<TypeResolveResult>();
            var typeDefinition = typeReference?.Type;
            if (typeDefinition?.FullName == type.FullName)
            {

                return true;

            }
            else
            {


            }

            return false;
        }

        /// <summary>
        /// Return true if the type of the object is the same as the type
        /// </summary>
        /// <param name="self"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool Match(this ITypeDefinition self, Type type)
        {

            if (self.FullName == type.FullName)
                return true;

            return false;
        }

        /// <summary>
        /// Return true if the type of the object is the same as the type
        /// </summary>
        /// <param name="self"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public static bool Match(this IMethod self, MethodBase method)
        {

            if (self.Name == method.Name)
            {

                var ps1 = self.Parameters;
                var ps2 = method.GetParameters();

                if (ps1.Count != ps2.Length)
                    return false;

                for (var i = 0; i < self.Parameters.Count; i++)
                {
                    IParameter p1 = self.Parameters[i];
                    var p2 = method.GetParameters()[i];
                    if (!p1.Type.Match(p2.ParameterType))
                        return false;
                }
                
                return true;

            }

            return false;

        }


        /// <summary>
        /// Return true if the type of the object is the same as the type
        /// </summary>
        /// <param name="self"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool Match(this IType self, Type type)
        {

            if (self.FullName == type.FullName)
                return true;

            return false;

        }

        /// <summary>
        /// return true if the file reference the assembly of the specified type
        /// </summary>
        /// <param name="self"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool Reference(this PEFile self, Type type)
        {
            var assembly = type.Assembly.GetName().Name;
            foreach (var item in self.AssemblyReferences)
                if (item.Name == assembly)
                    return true;
            return false;
        }


        /// <summary>
        /// parse a syntax tree.
        /// </summary>
        /// <param name="self">syntax to parse</param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static InterceptorAstVisitor Search(this SyntaxTree self, Action<InterceptorAstVisitor> action)
        {

            if (action == null)
                throw new ArgumentNullException(nameof(action));

            var visitor = new InterceptorAstVisitor();
            action(visitor);
            self.AcceptVisitor(visitor);
            return visitor;
        }

        /// <summary>
        /// Intercept Accessor
        /// </summary>
        /// <param name="self"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static InterceptorAstVisitor OnAccessor(this InterceptorAstVisitor self, Action<Accessor> action)
        {
            self.Add(action);
            return self;
        }

        /// <summary>
        /// Intercept AnonymousMethodExpression
        /// </summary>
        /// <param name="self"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static InterceptorAstVisitor OnAnonymousMethodExpression(this InterceptorAstVisitor self, Action<AnonymousMethodExpression> action)
        {
            self.Add(action);
            return self;
        }

        /// <summary>
        /// Intercept AnonymousTypeCreateExpression
        /// </summary>
        /// <param name="self"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static InterceptorAstVisitor OnAnonymousTypeCreateExpression(this InterceptorAstVisitor self, Action<AnonymousTypeCreateExpression> action)
        {
            self.Add(action);
            return self;
        }

        /// <summary>
        /// Intercept ArrayCreateExpression
        /// </summary>
        /// <param name="self"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static InterceptorAstVisitor OnArrayCreateExpression(this InterceptorAstVisitor self, Action<ArrayCreateExpression> action)
        {
            self.Add(action);
            return self;
        }

        /// <summary>
        /// Intercept ArrayInitializerExpression
        /// </summary>
        /// <param name="self"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static InterceptorAstVisitor OnArrayInitializerExpression(this InterceptorAstVisitor self, Action<ArrayInitializerExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnArraySpecifier(this InterceptorAstVisitor self, Action<ArraySpecifier> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnAsExpression(this InterceptorAstVisitor self, Action<AsExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnAssignmentExpression(this InterceptorAstVisitor self, Action<AssignmentExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnAttribute(this InterceptorAstVisitor self, Action<ICSharpCode.Decompiler.CSharp.Syntax.Attribute> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnAttributeSection(this InterceptorAstVisitor self, Action<AttributeSection> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnBaseReferenceExpression(this InterceptorAstVisitor self, Action<BaseReferenceExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnBinaryOperatorExpression(this InterceptorAstVisitor self, Action<BinaryOperatorExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnBlockStatement(this InterceptorAstVisitor self, Action<BlockStatement> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnBreakStatement(this InterceptorAstVisitor self, Action<BreakStatement> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnCaseLabel(this InterceptorAstVisitor self, Action<CaseLabel> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnCastExpression(this InterceptorAstVisitor self, Action<CastExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnCatchClause(this InterceptorAstVisitor self, Action<CatchClause> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnCheckedExpression(this InterceptorAstVisitor self, Action<CheckedExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnCheckedStatement(this InterceptorAstVisitor self, Action<CheckedStatement> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnComment(this InterceptorAstVisitor self, Action<Comment> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnComposedType(this InterceptorAstVisitor self, Action<ComposedType> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnConditionalExpression(this InterceptorAstVisitor self, Action<ConditionalExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnConstraint(this InterceptorAstVisitor self, Action<Constraint> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnConstructorDeclaration(this InterceptorAstVisitor self, Action<ConstructorDeclaration> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnConstructorInitializer(this InterceptorAstVisitor self, Action<ConstructorInitializer> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnContinueStatement(this InterceptorAstVisitor self, Action<ContinueStatement> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnCSharpTokenNode(this InterceptorAstVisitor self, Action<CSharpTokenNode> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnCustomEventDeclaration(this InterceptorAstVisitor self, Action<CustomEventDeclaration> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnDeclarationExpression(this InterceptorAstVisitor self, Action<DeclarationExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnDefaultValueExpression(this InterceptorAstVisitor self, Action<DefaultValueExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnDelegateDeclaration(this InterceptorAstVisitor self, Action<DelegateDeclaration> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnDestructorDeclaration(this InterceptorAstVisitor self, Action<DestructorDeclaration> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnDirectionExpression(this InterceptorAstVisitor self, Action<DirectionExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnDocumentationReference(this InterceptorAstVisitor self, Action<DocumentationReference> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnDoWhileStatement(this InterceptorAstVisitor self, Action<DoWhileStatement> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnEmptyStatement(this InterceptorAstVisitor self, Action<EmptyStatement> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnEnumMemberDeclaration(this InterceptorAstVisitor self, Action<EnumMemberDeclaration> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnErrorNode(this InterceptorAstVisitor self, Action<AstNode> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnEventDeclaration(this InterceptorAstVisitor self, Action<EventDeclaration> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnExpressionStatement(this InterceptorAstVisitor self, Action<ExpressionStatement> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnExternAliasDeclaration(this InterceptorAstVisitor self, Action<ExternAliasDeclaration> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnFieldDeclaration(this InterceptorAstVisitor self, Action<FieldDeclaration> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnFixedFieldDeclaration(this InterceptorAstVisitor self, Action<FixedFieldDeclaration> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnFixedStatement(this InterceptorAstVisitor self, Action<FixedStatement> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnFixedVariableInitializer(this InterceptorAstVisitor self, Action<FixedVariableInitializer> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnForeachStatement(this InterceptorAstVisitor self, Action<ForeachStatement> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnForStatement(this InterceptorAstVisitor self, Action<ForStatement> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnFunctionPointerType(this InterceptorAstVisitor self, Action<FunctionPointerType> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnGotoCaseStatement(this InterceptorAstVisitor self, Action<GotoCaseStatement> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnGotoDefaultStatement(this InterceptorAstVisitor self, Action<GotoDefaultStatement> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnGotoStatement(this InterceptorAstVisitor self, Action<GotoStatement> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnIdentifier(this InterceptorAstVisitor self, Action<Identifier> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnIdentifierExpression(this InterceptorAstVisitor self, Action<IdentifierExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnIfElseStatement(this InterceptorAstVisitor self, Action<IfElseStatement> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnIndexerDeclaration(this InterceptorAstVisitor self, Action<IndexerDeclaration> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnIndexerExpression(this InterceptorAstVisitor self, Action<IndexerExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnInterpolatedStringExpression(this InterceptorAstVisitor self, Action<InterpolatedStringExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnInterpolatedStringText(this InterceptorAstVisitor self, Action<InterpolatedStringText> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnInterpolation(this InterceptorAstVisitor self, Action<Interpolation> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnInvocationExpression(this InterceptorAstVisitor self, Action<InvocationExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnIsExpression(this InterceptorAstVisitor self, Action<IsExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnLabelStatement(this InterceptorAstVisitor self, Action<LabelStatement> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnLambdaExpression(this InterceptorAstVisitor self, Action<LambdaExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnLocalFunctionDeclarationStatement(this InterceptorAstVisitor self, Action<LocalFunctionDeclarationStatement> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnLockStatement(this InterceptorAstVisitor self, Action<LockStatement> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnMemberReferenceExpression(this InterceptorAstVisitor self, Action<MemberReferenceExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnMemberType(this InterceptorAstVisitor self, Action<MemberType> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnMethodDeclaration(this InterceptorAstVisitor self, Action<MethodDeclaration> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnNamedArgumentExpression(this InterceptorAstVisitor self, Action<NamedArgumentExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnNamedExpression(this InterceptorAstVisitor self, Action<NamedExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnNamespaceDeclaration(this InterceptorAstVisitor self, Action<NamespaceDeclaration> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnNullNode(this InterceptorAstVisitor self, Action<AstNode> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnNullReferenceExpression(this InterceptorAstVisitor self, Action<NullReferenceExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnObjectCreateExpression(this InterceptorAstVisitor self, Action<ObjectCreateExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnOperatorDeclaration(this InterceptorAstVisitor self, Action<OperatorDeclaration> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnOutVarDeclarationExpression(this InterceptorAstVisitor self, Action<OutVarDeclarationExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnParameterDeclaration(this InterceptorAstVisitor self, Action<ParameterDeclaration> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnParenthesizedExpression(this InterceptorAstVisitor self, Action<ParenthesizedExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnParenthesizedVariableDesignation(this InterceptorAstVisitor self, Action<ParenthesizedVariableDesignation> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnPatternPlaceholder(this InterceptorAstVisitor self, Action<AstNode> action, Pattern pattern)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnPointerReferenceExpression(this InterceptorAstVisitor self, Action<PointerReferenceExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnPreProcessorDirective(this InterceptorAstVisitor self, Action<PreProcessorDirective> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnPrimitiveExpression(this InterceptorAstVisitor self, Action<PrimitiveExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnPrimitiveType(this InterceptorAstVisitor self, Action<PrimitiveType> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnPropertyDeclaration(this InterceptorAstVisitor self, Action<PropertyDeclaration> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnQueryContinuationClause(this InterceptorAstVisitor self, Action<QueryContinuationClause> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnQueryExpression(this InterceptorAstVisitor self, Action<QueryExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnQueryFromClause(this InterceptorAstVisitor self, Action<QueryFromClause> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnQueryGroupClause(this InterceptorAstVisitor self, Action<QueryGroupClause> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnQueryJoinClause(this InterceptorAstVisitor self, Action<QueryJoinClause> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnQueryLetClause(this InterceptorAstVisitor self, Action<QueryLetClause> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnQueryOrderClause(this InterceptorAstVisitor self, Action<QueryOrderClause> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnQueryOrdering(this InterceptorAstVisitor self, Action<QueryOrdering> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnQuerySelectClause(this InterceptorAstVisitor self, Action<QuerySelectClause> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnQueryWhereClause(this InterceptorAstVisitor self, Action<QueryWhereClause> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnReturnStatement(this InterceptorAstVisitor self, Action<ReturnStatement> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnSimpleType(this InterceptorAstVisitor self, Action<SimpleType> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnSingleVariableDesignation(this InterceptorAstVisitor self, Action<SingleVariableDesignation> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnSizeOfExpression(this InterceptorAstVisitor self, Action<SizeOfExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnStackAllocExpression(this InterceptorAstVisitor self, Action<StackAllocExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnSwitchExpression(this InterceptorAstVisitor self, Action<SwitchExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnSwitchExpressionSection(this InterceptorAstVisitor self, Action<SwitchExpressionSection> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnSwitchSection(this InterceptorAstVisitor self, Action<SwitchSection> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnSwitchStatement(this InterceptorAstVisitor self, Action<SwitchStatement> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnSyntaxTree(this InterceptorAstVisitor self, Action<SyntaxTree> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnThisReferenceExpression(this InterceptorAstVisitor self, Action<ThisReferenceExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnThrowExpression(this InterceptorAstVisitor self, Action<ThrowExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnThrowStatement(this InterceptorAstVisitor self, Action<ThrowStatement> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnTryCatchStatement(this InterceptorAstVisitor self, Action<TryCatchStatement> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnTupleExpression(this InterceptorAstVisitor self, Action<TupleExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnTupleType(this InterceptorAstVisitor self, Action<TupleAstType> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnTupleTypeElement(this InterceptorAstVisitor self, Action<TupleTypeElement> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnTypeDeclaration(this InterceptorAstVisitor self, Action<TypeDeclaration> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnTypeOfExpression(this InterceptorAstVisitor self, Action<TypeOfExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnTypeParameterDeclaration(this InterceptorAstVisitor self, Action<TypeParameterDeclaration> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnTypeReferenceExpression(this InterceptorAstVisitor self, Action<TypeReferenceExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnUnaryOperatorExpression(this InterceptorAstVisitor self, Action<UnaryOperatorExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnUncheckedExpression(this InterceptorAstVisitor self, Action<UncheckedExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnUncheckedStatement(this InterceptorAstVisitor self, Action<UncheckedStatement> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnUndocumentedExpression(this InterceptorAstVisitor self, Action<UndocumentedExpression> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnUnsafeStatement(this InterceptorAstVisitor self, Action<UnsafeStatement> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnUsingAliasDeclaration(this InterceptorAstVisitor self, Action<UsingAliasDeclaration> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnUsingDeclaration(this InterceptorAstVisitor self, Action<UsingDeclaration> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnUsingStatement(this InterceptorAstVisitor self, Action<UsingStatement> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnVariableDeclarationStatement(this InterceptorAstVisitor self, Action<VariableDeclarationStatement> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnVariableInitializer(this InterceptorAstVisitor self, Action<VariableInitializer> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnWhileStatement(this InterceptorAstVisitor self, Action<WhileStatement> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnYieldBreakStatement(this InterceptorAstVisitor self, Action<YieldBreakStatement> action)
        {
            self.Add(action);
            return self;
        }

        public static InterceptorAstVisitor OnYieldReturnStatement(this InterceptorAstVisitor self, Action<YieldReturnStatement> action)
        {
            self.Add(action);
            return self;
        }
    }



    public static partial class InterceptorAstVisitorExtension
    {

        public static InterceptorAstVisitor OnAccessor(this InterceptorAstVisitor self, Func<Accessor, bool> filter, Action<Accessor> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnAnonymousMethodExpression(this InterceptorAstVisitor self, Func<AnonymousMethodExpression, bool> filter, Action<AnonymousMethodExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnAnonymousTypeCreateExpression(this InterceptorAstVisitor self, Func<AnonymousTypeCreateExpression, bool> filter, Action<AnonymousTypeCreateExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnArrayCreateExpression(this InterceptorAstVisitor self, Func<ArrayCreateExpression, bool> filter, Action<ArrayCreateExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnArrayInitializerExpression(this InterceptorAstVisitor self, Func<ArrayInitializerExpression, bool> filter, Action<ArrayInitializerExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnArraySpecifier(this InterceptorAstVisitor self, Func<ArraySpecifier, bool> filter, Action<ArraySpecifier> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnAsExpression(this InterceptorAstVisitor self, Func<AsExpression, bool> filter, Action<AsExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnAssignmentExpression(this InterceptorAstVisitor self, Func<AssignmentExpression, bool> filter, Action<AssignmentExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnAttribute(this InterceptorAstVisitor self, Func<ICSharpCode.Decompiler.CSharp.Syntax.Attribute, bool> filter, Action<ICSharpCode.Decompiler.CSharp.Syntax.Attribute> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnAttributeSection(this InterceptorAstVisitor self, Func<AttributeSection, bool> filter, Action<AttributeSection> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnBaseReferenceExpression(this InterceptorAstVisitor self, Func<BaseReferenceExpression, bool> filter, Action<BaseReferenceExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnBinaryOperatorExpression(this InterceptorAstVisitor self, Func<BinaryOperatorExpression, bool> filter, Action<BinaryOperatorExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnBlockStatement(this InterceptorAstVisitor self, Func<BlockStatement, bool> filter, Action<BlockStatement> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnBreakStatement(this InterceptorAstVisitor self, Func<BreakStatement, bool> filter, Action<BreakStatement> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnCaseLabel(this InterceptorAstVisitor self, Func<CaseLabel, bool> filter, Action<CaseLabel> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnCastExpression(this InterceptorAstVisitor self, Func<CastExpression, bool> filter, Action<CastExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnCatchClause(this InterceptorAstVisitor self, Func<CatchClause, bool> filter, Action<CatchClause> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnCheckedExpression(this InterceptorAstVisitor self, Func<CheckedExpression, bool> filter, Action<CheckedExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnCheckedStatement(this InterceptorAstVisitor self, Func<CheckedStatement, bool> filter, Action<CheckedStatement> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnComment(this InterceptorAstVisitor self, Func<Comment, bool> filter, Action<Comment> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnComposedType(this InterceptorAstVisitor self, Func<ComposedType, bool> filter, Action<ComposedType> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnConditionalExpression(this InterceptorAstVisitor self, Func<ConditionalExpression, bool> filter, Action<ConditionalExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnConstraint(this InterceptorAstVisitor self, Func<Constraint, bool> filter, Action<Constraint> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnConstructorDeclaration(this InterceptorAstVisitor self, Func<ConstructorDeclaration, bool> filter, Action<ConstructorDeclaration> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnConstructorInitializer(this InterceptorAstVisitor self, Func<ConstructorInitializer, bool> filter, Action<ConstructorInitializer> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnContinueStatement(this InterceptorAstVisitor self, Func<ContinueStatement, bool> filter, Action<ContinueStatement> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnCSharpTokenNode(this InterceptorAstVisitor self, Func<CSharpTokenNode, bool> filter, Action<CSharpTokenNode> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnCustomEventDeclaration(this InterceptorAstVisitor self, Func<CustomEventDeclaration, bool> filter, Action<CustomEventDeclaration> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnDeclarationExpression(this InterceptorAstVisitor self, Func<DeclarationExpression, bool> filter, Action<DeclarationExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnDefaultValueExpression(this InterceptorAstVisitor self, Func<DefaultValueExpression, bool> filter, Action<DefaultValueExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnDelegateDeclaration(this InterceptorAstVisitor self, Func<DelegateDeclaration, bool> filter, Action<DelegateDeclaration> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnDestructorDeclaration(this InterceptorAstVisitor self, Func<DestructorDeclaration, bool> filter, Action<DestructorDeclaration> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnDirectionExpression(this InterceptorAstVisitor self, Func<DirectionExpression, bool> filter, Action<DirectionExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnDocumentationReference(this InterceptorAstVisitor self, Func<DocumentationReference, bool> filter, Action<DocumentationReference> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnDoWhileStatement(this InterceptorAstVisitor self, Func<DoWhileStatement, bool> filter, Action<DoWhileStatement> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnEmptyStatement(this InterceptorAstVisitor self, Func<EmptyStatement, bool> filter, Action<EmptyStatement> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnEnumMemberDeclaration(this InterceptorAstVisitor self, Func<EnumMemberDeclaration, bool> filter, Action<EnumMemberDeclaration> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnErrorNode(this InterceptorAstVisitor self, Func<AstNode, bool> filter, Action<AstNode> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnEventDeclaration(this InterceptorAstVisitor self, Func<EventDeclaration, bool> filter, Action<EventDeclaration> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnExpressionStatement(this InterceptorAstVisitor self, Func<ExpressionStatement, bool> filter, Action<ExpressionStatement> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnExternAliasDeclaration(this InterceptorAstVisitor self, Func<ExternAliasDeclaration, bool> filter, Action<ExternAliasDeclaration> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnFieldDeclaration(this InterceptorAstVisitor self, Func<FieldDeclaration, bool> filter, Action<FieldDeclaration> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnFixedFieldDeclaration(this InterceptorAstVisitor self, Func<FixedFieldDeclaration, bool> filter, Action<FixedFieldDeclaration> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnFixedStatement(this InterceptorAstVisitor self, Func<FixedStatement, bool> filter, Action<FixedStatement> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnFixedVariableInitializer(this InterceptorAstVisitor self, Func<FixedVariableInitializer, bool> filter, Action<FixedVariableInitializer> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnForeachStatement(this InterceptorAstVisitor self, Func<ForeachStatement, bool> filter, Action<ForeachStatement> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnForStatement(this InterceptorAstVisitor self, Func<ForStatement, bool> filter, Action<ForStatement> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnFunctionPointerType(this InterceptorAstVisitor self, Func<FunctionPointerType, bool> filter, Action<FunctionPointerType> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnGotoCaseStatement(this InterceptorAstVisitor self, Func<GotoCaseStatement, bool> filter, Action<GotoCaseStatement> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnGotoDefaultStatement(this InterceptorAstVisitor self, Func<GotoDefaultStatement, bool> filter, Action<GotoDefaultStatement> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnGotoStatement(this InterceptorAstVisitor self, Func<GotoStatement, bool> filter, Action<GotoStatement> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnIdentifier(this InterceptorAstVisitor self, Func<Identifier, bool> filter, Action<Identifier> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnIdentifierExpression(this InterceptorAstVisitor self, Func<IdentifierExpression, bool> filter, Action<IdentifierExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnIfElseStatement(this InterceptorAstVisitor self, Func<IfElseStatement, bool> filter, Action<IfElseStatement> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnIndexerDeclaration(this InterceptorAstVisitor self, Func<IndexerDeclaration, bool> filter, Action<IndexerDeclaration> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnIndexerExpression(this InterceptorAstVisitor self, Func<IndexerExpression, bool> filter, Action<IndexerExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnInterpolatedStringExpression(this InterceptorAstVisitor self, Func<InterpolatedStringExpression, bool> filter, Action<InterpolatedStringExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnInterpolatedStringText(this InterceptorAstVisitor self, Func<InterpolatedStringText, bool> filter, Action<InterpolatedStringText> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnInterpolation(this InterceptorAstVisitor self, Func<Interpolation, bool> filter, Action<Interpolation> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnInvocationExpression(this InterceptorAstVisitor self, Func<InvocationExpression, bool> filter, Action<InvocationExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnIsExpression(this InterceptorAstVisitor self, Func<IsExpression, bool> filter, Action<IsExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnLabelStatement(this InterceptorAstVisitor self, Func<LabelStatement, bool> filter, Action<LabelStatement> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnLambdaExpression(this InterceptorAstVisitor self, Func<LambdaExpression, bool> filter, Action<LambdaExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnLocalFunctionDeclarationStatement(this InterceptorAstVisitor self, Func<LocalFunctionDeclarationStatement, bool> filter, Action<LocalFunctionDeclarationStatement> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnLockStatement(this InterceptorAstVisitor self, Func<LockStatement, bool> filter, Action<LockStatement> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnMemberReferenceExpression(this InterceptorAstVisitor self, Func<MemberReferenceExpression, bool> filter, Action<MemberReferenceExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnMemberType(this InterceptorAstVisitor self, Func<MemberType, bool> filter, Action<MemberType> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnMethodDeclaration(this InterceptorAstVisitor self, Func<MethodDeclaration, bool> filter, Action<MethodDeclaration> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnNamedArgumentExpression(this InterceptorAstVisitor self, Func<NamedArgumentExpression, bool> filter, Action<NamedArgumentExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnNamedExpression(this InterceptorAstVisitor self, Func<NamedExpression, bool> filter, Action<NamedExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnNamespaceDeclaration(this InterceptorAstVisitor self, Func<NamespaceDeclaration, bool> filter, Action<NamespaceDeclaration> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnNullNode(this InterceptorAstVisitor self, Func<AstNode, bool> filter, Action<AstNode> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnNullReferenceExpression(this InterceptorAstVisitor self, Func<NullReferenceExpression, bool> filter, Action<NullReferenceExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnObjectCreateExpression(this InterceptorAstVisitor self, Func<ObjectCreateExpression, bool> filter, Action<ObjectCreateExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnOperatorDeclaration(this InterceptorAstVisitor self, Func<OperatorDeclaration, bool> filter, Action<OperatorDeclaration> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnOutVarDeclarationExpression(this InterceptorAstVisitor self, Func<OutVarDeclarationExpression, bool> filter, Action<OutVarDeclarationExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnParameterDeclaration(this InterceptorAstVisitor self, Func<ParameterDeclaration, bool> filter, Action<ParameterDeclaration> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnParenthesizedExpression(this InterceptorAstVisitor self, Func<ParenthesizedExpression, bool> filter, Action<ParenthesizedExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnParenthesizedVariableDesignation(this InterceptorAstVisitor self, Func<ParenthesizedVariableDesignation, bool> filter, Action<ParenthesizedVariableDesignation> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnPatternPlaceholder(this InterceptorAstVisitor self, Func<AstNode, bool> filter, Action<AstNode> action, Pattern pattern)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnPointerReferenceExpression(this InterceptorAstVisitor self, Func<PointerReferenceExpression, bool> filter, Action<PointerReferenceExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnPreProcessorDirective(this InterceptorAstVisitor self, Func<PreProcessorDirective, bool> filter, Action<PreProcessorDirective> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnPrimitiveExpression(this InterceptorAstVisitor self, Func<PrimitiveExpression, bool> filter, Action<PrimitiveExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnPrimitiveType(this InterceptorAstVisitor self, Func<PrimitiveType, bool> filter, Action<PrimitiveType> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnPropertyDeclaration(this InterceptorAstVisitor self, Func<PropertyDeclaration, bool> filter, Action<PropertyDeclaration> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnQueryContinuationClause(this InterceptorAstVisitor self, Func<QueryContinuationClause, bool> filter, Action<QueryContinuationClause> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnQueryExpression(this InterceptorAstVisitor self, Func<QueryExpression, bool> filter, Action<QueryExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnQueryFromClause(this InterceptorAstVisitor self, Func<QueryFromClause, bool> filter, Action<QueryFromClause> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnQueryGroupClause(this InterceptorAstVisitor self, Func<QueryGroupClause, bool> filter, Action<QueryGroupClause> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnQueryJoinClause(this InterceptorAstVisitor self, Func<QueryJoinClause, bool> filter, Action<QueryJoinClause> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnQueryLetClause(this InterceptorAstVisitor self, Func<QueryLetClause, bool> filter, Action<QueryLetClause> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnQueryOrderClause(this InterceptorAstVisitor self, Func<QueryOrderClause, bool> filter, Action<QueryOrderClause> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnQueryOrdering(this InterceptorAstVisitor self, Func<QueryOrdering, bool> filter, Action<QueryOrdering> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnQuerySelectClause(this InterceptorAstVisitor self, Func<QuerySelectClause, bool> filter, Action<QuerySelectClause> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnQueryWhereClause(this InterceptorAstVisitor self, Func<QueryWhereClause, bool> filter, Action<QueryWhereClause> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnReturnStatement(this InterceptorAstVisitor self, Func<ReturnStatement, bool> filter, Action<ReturnStatement> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnSimpleType(this InterceptorAstVisitor self, Func<SimpleType, bool> filter, Action<SimpleType> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnSingleVariableDesignation(this InterceptorAstVisitor self, Func<SingleVariableDesignation, bool> filter, Action<SingleVariableDesignation> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnSizeOfExpression(this InterceptorAstVisitor self, Func<SizeOfExpression, bool> filter, Action<SizeOfExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnStackAllocExpression(this InterceptorAstVisitor self, Func<StackAllocExpression, bool> filter, Action<StackAllocExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnSwitchExpression(this InterceptorAstVisitor self, Func<SwitchExpression, bool> filter, Action<SwitchExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnSwitchExpressionSection(this InterceptorAstVisitor self, Func<SwitchExpressionSection, bool> filter, Action<SwitchExpressionSection> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnSwitchSection(this InterceptorAstVisitor self, Func<SwitchSection, bool> filter, Action<SwitchSection> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnSwitchStatement(this InterceptorAstVisitor self, Func<SwitchStatement, bool> filter, Action<SwitchStatement> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnSyntaxTree(this InterceptorAstVisitor self, Func<SyntaxTree, bool> filter, Action<SyntaxTree> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnThisReferenceExpression(this InterceptorAstVisitor self, Func<ThisReferenceExpression, bool> filter, Action<ThisReferenceExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnThrowExpression(this InterceptorAstVisitor self, Func<ThrowExpression, bool> filter, Action<ThrowExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnThrowStatement(this InterceptorAstVisitor self, Func<ThrowStatement, bool> filter, Action<ThrowStatement> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnTryCatchStatement(this InterceptorAstVisitor self, Func<TryCatchStatement, bool> filter, Action<TryCatchStatement> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnTupleExpression(this InterceptorAstVisitor self, Func<TupleExpression, bool> filter, Action<TupleExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnTupleType(this InterceptorAstVisitor self, Func<TupleAstType, bool> filter, Action<TupleAstType> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnTupleTypeElement(this InterceptorAstVisitor self, Func<TupleTypeElement, bool> filter, Action<TupleTypeElement> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnTypeDeclaration(this InterceptorAstVisitor self, Func<TypeDeclaration, bool> filter, Action<TypeDeclaration> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnTypeOfExpression(this InterceptorAstVisitor self, Func<TypeOfExpression, bool> filter, Action<TypeOfExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnTypeParameterDeclaration(this InterceptorAstVisitor self, Func<TypeParameterDeclaration, bool> filter, Action<TypeParameterDeclaration> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnTypeReferenceExpression(this InterceptorAstVisitor self, Func<TypeReferenceExpression, bool> filter, Action<TypeReferenceExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnUnaryOperatorExpression(this InterceptorAstVisitor self, Func<UnaryOperatorExpression, bool> filter, Action<UnaryOperatorExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnUncheckedExpression(this InterceptorAstVisitor self, Func<UncheckedExpression, bool> filter, Action<UncheckedExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnUncheckedStatement(this InterceptorAstVisitor self, Func<UncheckedStatement, bool> filter, Action<UncheckedStatement> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnUndocumentedExpression(this InterceptorAstVisitor self, Func<UndocumentedExpression, bool> filter, Action<UndocumentedExpression> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnUnsafeStatement(this InterceptorAstVisitor self, Func<UnsafeStatement, bool> filter, Action<UnsafeStatement> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnUsingAliasDeclaration(this InterceptorAstVisitor self, Func<UsingAliasDeclaration, bool> filter, Action<UsingAliasDeclaration> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnUsingDeclaration(this InterceptorAstVisitor self, Func<UsingDeclaration, bool> filter, Action<UsingDeclaration> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnUsingStatement(this InterceptorAstVisitor self, Func<UsingStatement, bool> filter, Action<UsingStatement> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnVariableDeclarationStatement(this InterceptorAstVisitor self, Func<VariableDeclarationStatement, bool> filter, Action<VariableDeclarationStatement> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnVariableInitializer(this InterceptorAstVisitor self, Func<VariableInitializer, bool> filter, Action<VariableInitializer> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnWhileStatement(this InterceptorAstVisitor self, Func<WhileStatement, bool> filter, Action<WhileStatement> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnYieldBreakStatement(this InterceptorAstVisitor self, Func<YieldBreakStatement, bool> filter, Action<YieldBreakStatement> action)
        {
            self.Add(filter, action);
            return self;
        }

        public static InterceptorAstVisitor OnYieldReturnStatement(this InterceptorAstVisitor self, Func<YieldReturnStatement, bool> filter, Action<YieldReturnStatement> action)
        {
            self.Add(filter, action);
            return self;
        }
    }



}
