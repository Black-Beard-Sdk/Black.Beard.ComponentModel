using System;
using System.Reflection.Emit;
using System.Reflection;
using System.Linq;

namespace Bb.ComponentModel.Observables
{

    public static partial class DynamicGenerator
    {


        public static void CreateIDisposable(this TypeBuilder typeBuilder, Type type, InterceptorResult result)
        {

            MethodInfo methodDisposing = null;
            MethodInfo method = null;
            bool isDisposable = typeof(IDisposable).IsAssignableFrom(type);
            var methodInfos = type.GetMethods().Where(p => p.Name == nameof(IDisposable.Dispose));

            if (isDisposable)
            {

                methodDisposing = methodInfos.Where(c =>
                {
                    var isVirtual = (c.Attributes & MethodAttributes.Virtual) == MethodAttributes.Virtual;
                    var p = c.GetParameters();
                    if (p.Length == 1)
                        if (p[0].ParameterType == typeof(bool))
                            return true;
                    return false;
                }).FirstOrDefault();

                method = methodInfos.Where(c =>
                {
                    var isVirtual = (c.Attributes & MethodAttributes.Virtual) == MethodAttributes.Virtual;
                    var p = c.GetParameters();
                    return (p.Length == 0);
                }).FirstOrDefault();

                if (methodDisposing == null && method == null) // dispose is implemented but not with virtual signature
                {
                    result.Log("dispose is already implemented but not with virtual signature. make method (Dispose(bool disposing) or Dispose() are virtual");
                    return;
                }

            }

            var raiseEventMethod = ImplementIDisposed(
                typeBuilder,
                typeof(IDisposed),
                "Disposed",
                typeof(DisposedEventHandler),
                typeof(EventArgs)
            );

            if (methodDisposing != null)
                OverrideWithDisposing(typeBuilder, methodDisposing, raiseEventMethod);

            else if (method != null)
                OverrideWithoutDisposing(typeBuilder, method, raiseEventMethod);

            else
                CreateNewMethodDispose(typeBuilder, raiseEventMethod);

            result.IsDisposable = true;

        }

        private static void CreateNewMethodDispose(TypeBuilder typeBuilder, MethodBuilder raiseEventMethod)
        {

            var attributes = MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.NewSlot;
            var newMethod = typeBuilder.DefineMethod("Dispose", attributes, voidType, new Type[] { });
            var il = newMethod.GetILGenerator();

            il.Emit(OpCodes.Nop);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Call, raiseEventMethod);
            il.Emit(OpCodes.Nop);
            il.Emit(OpCodes.Ret);

        }

        private static void OverrideWithDisposing(TypeBuilder typeBuilder, MethodInfo methodDisposing, MethodBuilder raiseEventMethod)
        {

            var newMethod = typeBuilder.DefineMethod(methodDisposing.Name, methodDisposing.Attributes, voidType, new Type[] { typeof(bool) });
            var il = newMethod.GetILGenerator();

            il.Emit(OpCodes.Nop);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Call, methodDisposing);
            il.Emit(OpCodes.Nop);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Callvirt, raiseEventMethod);
            il.Emit(OpCodes.Nop);
            il.Emit(OpCodes.Ret);

            typeBuilder.DefineMethodOverride(newMethod, methodDisposing);

        }

        private static void OverrideWithoutDisposing(TypeBuilder typeBuilder, MethodInfo baseMethod, MethodBuilder raiseEventMethod)
        {

            var newMethod = typeBuilder.DefineMethod(baseMethod.Name, baseMethod.Attributes, voidType, new Type[] { });
            var il = newMethod.GetILGenerator();

            il.Emit(OpCodes.Nop);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Call, baseMethod);
            il.Emit(OpCodes.Nop);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Callvirt, raiseEventMethod);
            il.Emit(OpCodes.Nop);
            il.Emit(OpCodes.Ret);

            typeBuilder.DefineMethodOverride(newMethod, baseMethod);

        }

        public static MethodBuilder ImplementIDisposed(TypeBuilder typeBuilder, Type interfaceType, string eventFieldName, Type eventHandlerType, Type eventArgType)
        {
            typeBuilder.AddInterfaceImplementation(interfaceType);
            var field = typeBuilder.DefineField(eventFieldName, eventHandlerType, FieldAttributes.Private);
            var eventInfo = typeBuilder.DefineEvent(eventFieldName, EventAttributes.None, eventHandlerType);
            ImplementAddEvent(typeBuilder, field, eventInfo, interfaceType, eventFieldName, eventHandlerType);
            ImplementRemoveEvent(typeBuilder, field, eventInfo, interfaceType, eventFieldName, eventHandlerType);
            var methodBuilder = ImplementOnDispoed(typeBuilder, field, eventInfo, eventFieldName, eventHandlerType, eventArgType);
            return methodBuilder;
        }

        private static MethodBuilder ImplementOnDispoed(TypeBuilder typeBuilder, FieldBuilder field, EventBuilder eventInfo
            , string eventFieldName, Type eventHandlerType, Type eventArgType)
        {

            var attributes = MethodAttributes.Family | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.NewSlot;
            var propertyArgsCtor = eventArgType.GetConstructor(new Type[] { });

            var methodBuilder = typeBuilder.DefineMethod($"On{eventFieldName}", attributes, voidType, new Type[] { });
            var generator = methodBuilder.GetILGenerator();
            var returnLabel = generator.DefineLabel();

            generator.DeclareLocal(eventHandlerType);

            generator.Emit(OpCodes.Nop);
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldfld, field);
            generator.Emit(OpCodes.Ldnull);
            generator.Emit(OpCodes.Cgt_Un);
            generator.Emit(OpCodes.Stloc_0);
            generator.Emit(OpCodes.Ldloc_0);
            generator.Emit(OpCodes.Brfalse, returnLabel);

            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldfld, field);
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldsfld, EventArgsEmpty);
            generator.Emit(OpCodes.Callvirt, eventHandlerType.GetMethod("Invoke"));
            generator.Emit(OpCodes.Nop);


            //generator.Emit(OpCodes.Ldloc_0);
            //generator.Emit(OpCodes.Ldarg_0);
            //generator.Emit(OpCodes.Newobj, propertyArgsCtor);
            //generator.Emit(OpCodes.Callvirt, eventHandlerType.GetMethod("Invoke"));

            generator.MarkLabel(returnLabel);
            generator.Emit(OpCodes.Ret);

            eventInfo.SetRaiseMethod(methodBuilder);
            return methodBuilder;
        }

        private static FieldInfo EventArgsEmpty = typeof(EventArgs).GetField(nameof(EventArgs.Empty), BindingFlags.Static | BindingFlags.Public);

    }




}
