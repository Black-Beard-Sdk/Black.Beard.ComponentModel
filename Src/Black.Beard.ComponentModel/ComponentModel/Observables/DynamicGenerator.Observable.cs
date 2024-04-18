using System;
using System.Reflection.Emit;
using System.Reflection;
using System.ComponentModel;
using System.Linq;

namespace Bb.ComponentModel.Observables
{
    public static partial class DynamicGenerator
    {



        public static void CreateObservable(this TypeBuilder typeBuilder, Type type, InterceptorResult result)
        {


            var propertyInfos = type.GetProperties().Where(p => p.CanWrite && p.GetAccessors().Length == 2).ToArray();

            if (propertyInfos.Length > 0)
            {

                var raiseEventMethod = ImplementPropertyChanged(
                    typeBuilder,
                    typeof(INotifyPropertyChanged), "PropertyChanged",
                    typeof(PropertyChangedEventHandler), 
                    typeof(PropertyChangedEventArgs)
                );

                WrapProperties(typeBuilder, raiseEventMethod, propertyInfos);

                result.IsObservable = true;

            }
            else
            {
                result.Log("no property to intercept. Check the virtual properties");
            }

        }

        private static void WrapProperties(TypeBuilder typeBuilder, MethodBuilder raiseEventMethod, PropertyInfo[] propertyInfos)
        {

            ILGenerator il;

            foreach (var item in propertyInfos)
            {

                if (item.CanRead && item.GetGetMethod().IsVirtual)
                {

                    var baseMethodGet = item.GetGetMethod();
                    var getAccessor = typeBuilder.DefineMethod(baseMethodGet.Name, baseMethodGet.Attributes, item.PropertyType, null);

                    il = getAccessor.GetILGenerator();
                    il.Emit(OpCodes.Ldarg_0);
                    il.EmitCall(OpCodes.Call, baseMethodGet, null);
                    il.Emit(OpCodes.Ret);
                    typeBuilder.DefineMethodOverride(getAccessor, baseMethodGet);

                }

                var baseMethodSet = item.GetSetMethod();
                var setAccessor = typeBuilder.DefineMethod(baseMethodSet.Name, baseMethodSet.Attributes, voidType, new[] { item.PropertyType });

                il = setAccessor.GetILGenerator();
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Call, baseMethodSet);
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldstr, item.Name);
                il.Emit(OpCodes.Callvirt, raiseEventMethod);
                il.Emit(OpCodes.Ret);
                typeBuilder.DefineMethodOverride(setAccessor, baseMethodSet);

            }

        }

        public static MethodBuilder ImplementPropertyChanged(TypeBuilder typeBuilder
            , Type interfaceType, string eventFieldName, Type eventHandlerType, Type eventArgType)
        {
            typeBuilder.AddInterfaceImplementation(interfaceType);
            var field = typeBuilder.DefineField(eventFieldName, eventHandlerType, FieldAttributes.Private);
            var eventInfo = typeBuilder.DefineEvent(eventFieldName, EventAttributes.None, eventHandlerType);
            ImplementAddEvent(typeBuilder, field, eventInfo, interfaceType, eventFieldName, eventHandlerType);
            ImplementRemoveEvent(typeBuilder, field, eventInfo, interfaceType, eventFieldName, eventHandlerType);
            var methodBuilder = ImplementOnPropertyChanged(typeBuilder, field, eventInfo, eventFieldName, eventHandlerType, eventArgType);
            return methodBuilder;
        }

        private static MethodBuilder ImplementOnPropertyChanged(TypeBuilder typeBuilder, FieldBuilder field, EventBuilder eventInfo
            , string eventFieldName, Type eventHandlerType, Type eventArgType)
        {

            var attributes = MethodAttributes.Family | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.NewSlot;
            var propertyArgsCtor = eventArgType.GetConstructor(new[] { typeof(string) });


            var methodBuilder = typeBuilder.DefineMethod($"On{eventFieldName}", attributes, typeof(void), new[] { typeof(string) });

            var generator = methodBuilder.GetILGenerator();
            var returnLabel = generator.DefineLabel();
            generator.DeclareLocal(eventHandlerType);

            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldfld, field);
            generator.Emit(OpCodes.Stloc_0);
            generator.Emit(OpCodes.Ldloc_0);
            generator.Emit(OpCodes.Brfalse, returnLabel);

            generator.Emit(OpCodes.Ldloc_0);
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldarg_1);
            generator.Emit(OpCodes.Newobj, propertyArgsCtor);
            generator.Emit(OpCodes.Callvirt, eventHandlerType.GetMethod("Invoke"));

            generator.MarkLabel(returnLabel);
            generator.Emit(OpCodes.Ret);

            eventInfo.SetRaiseMethod(methodBuilder);
            return methodBuilder;
        }

        private static void ImplementAddEvent(TypeBuilder typeBuilder, FieldBuilder field, EventBuilder eventInfo
            , Type interfaceType, string eventFieldName, Type eventHandlerType)
        {
            var ibaseMethod = interfaceType.GetMethod($"add_{eventFieldName}");
            var addMethod = typeBuilder.DefineMethod($"add_{eventFieldName}",
                ibaseMethod.Attributes ^ MethodAttributes.Abstract,
                ibaseMethod.CallingConvention,
                ibaseMethod.ReturnType, new[] { eventHandlerType });
            var generator = addMethod.GetILGenerator();
            var combine = typeof(Delegate).GetMethod("Combine", new[] { typeof(Delegate), typeof(Delegate) });
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldfld, field);
            generator.Emit(OpCodes.Ldarg_1);
            generator.Emit(OpCodes.Call, combine);
            generator.Emit(OpCodes.Castclass, eventHandlerType);
            generator.Emit(OpCodes.Stfld, field);
            generator.Emit(OpCodes.Ret);
            eventInfo.SetAddOnMethod(addMethod);
        }

        private static void ImplementRemoveEvent(TypeBuilder typeBuilder, FieldBuilder field, EventBuilder eventInfo
            , Type interfaceType, string eventFieldName, Type eventHandlerType)
        {
            var ibaseMethod = interfaceType.GetMethod($"remove_{eventFieldName}");
            var removeMethod = typeBuilder.DefineMethod($"remove_{eventFieldName}",
                ibaseMethod.Attributes ^ MethodAttributes.Abstract,
                ibaseMethod.CallingConvention,
                ibaseMethod.ReturnType, new[] { eventHandlerType });
            var remove = typeof(Delegate).GetMethod("Remove", new[] { typeof(Delegate), typeof(Delegate) });
            var generator = removeMethod.GetILGenerator();
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldfld, field);
            generator.Emit(OpCodes.Ldarg_1);
            generator.Emit(OpCodes.Call, remove);
            generator.Emit(OpCodes.Castclass, eventHandlerType);
            generator.Emit(OpCodes.Stfld, field);
            generator.Emit(OpCodes.Ret);
            eventInfo.SetRemoveOnMethod(removeMethod);
        }


        private static Type voidType = typeof(void);

    }




}
