using System;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using System.Reflection;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;

namespace Bb.ComponentModel.Observables
{
    public static partial class ObservableGenerator
    {


        public static Type CreateObservable<T>() where T : class, new()
        {
            return CreateObservable(typeof(T));
        }

        public static Type CreateObservable(Type type)
        {

            var assemblyName = type.FullName + "_Proxy";
            var fileName = assemblyName + ".dll";
            var name = new AssemblyName(assemblyName);
            var assembly = AssemblyBuilder.DefineDynamicAssembly(name, AssemblyBuilderAccess.Run);
            var module = assembly.DefineDynamicModule(assemblyName);
            var typeBuilder = module.DefineType(type.Name + "Proxy",
                TypeAttributes.Class | TypeAttributes.Public, type);
            typeBuilder.DefineDefaultConstructor(MethodAttributes.Public);
            var raiseEventMethod = ImplementPropertyChanged(typeBuilder, typeof(PropertyChangedEventHandler));
            var propertyInfos = type.GetProperties().Where(p => p.CanRead && p.CanWrite);
            foreach (var item in propertyInfos)
            {
                var baseMethod = item.GetGetMethod();
                var getAccessor = typeBuilder.DefineMethod(baseMethod.Name, baseMethod.Attributes, item.PropertyType,
                    null);
                var il = getAccessor.GetILGenerator();
                il.Emit(OpCodes.Ldarg_0);
                il.EmitCall(OpCodes.Call, baseMethod, null);
                il.Emit(OpCodes.Ret);
                typeBuilder.DefineMethodOverride(getAccessor, baseMethod);
                baseMethod = item.GetSetMethod();
                var setAccessor = typeBuilder.DefineMethod(baseMethod.Name, baseMethod.Attributes, typeof(void),
                    new[] { item.PropertyType });
                il = setAccessor.GetILGenerator();
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Call, baseMethod);
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldstr, item.Name);
                il.Emit(OpCodes.Callvirt, raiseEventMethod);
                il.Emit(OpCodes.Ret);
                typeBuilder.DefineMethodOverride(setAccessor, baseMethod);
            }
            var typeResult = typeBuilder.CreateType();

            return typeResult;

        }


        private static MethodBuilder ImplementPropertyChanged(TypeBuilder typeBuilder, Type eventHandlerType)
        {
            typeBuilder.AddInterfaceImplementation(typeof(INotifyPropertyChanged));
            var field = typeBuilder.DefineField("PropertyChanged", eventHandlerType, FieldAttributes.Private);
            var eventInfo = typeBuilder.DefineEvent("PropertyChanged", EventAttributes.None, eventHandlerType);
            //var methodBuilder = ImplementOnPropertyChangedHelper(typeBuilder, field, eventInfo);
            var methodBuilder = ImplementOnPropertyChanged(typeBuilder, field, eventInfo, eventHandlerType);
            ImplementAddEvent(typeBuilder, field, eventInfo, eventHandlerType);
            ImplementRemoveEvent(typeBuilder, field, eventInfo, eventHandlerType);
            return methodBuilder;
        }



        private static MethodBuilder ImplementOnPropertyChanged(TypeBuilder typeBuilder, FieldBuilder field,
            EventBuilder eventInfo, Type eventHandlerType)
        {
            var methodBuilder = typeBuilder.DefineMethod("OnPropertyChanged",
                MethodAttributes.Family | MethodAttributes.Virtual | MethodAttributes.HideBySig |
                MethodAttributes.NewSlot, typeof(void),
                new[] { typeof(string) });
            var generator = methodBuilder.GetILGenerator();
            var returnLabel = generator.DefineLabel();
            var propertyArgsCtor = typeof(PropertyChangedEventArgs).GetConstructor(new[] { typeof(string) });
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


        private static void ImplementAddEvent(TypeBuilder typeBuilder, FieldBuilder field, EventBuilder eventInfo, Type eventHandlerType)
        {
            var ibaseMethod = typeof(INotifyPropertyChanged).GetMethod("add_PropertyChanged");
            var addMethod = typeBuilder.DefineMethod("add_PropertyChanged",
                ibaseMethod.Attributes ^ MethodAttributes.Abstract,
                ibaseMethod.CallingConvention,
                ibaseMethod.ReturnType,
                new[] { typeof(PropertyChangedEventHandler) });
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

        private static void ImplementRemoveEvent(TypeBuilder typeBuilder, FieldBuilder field, EventBuilder eventInfo, Type eventHandlerType)
        {
            var ibaseMethod = typeof(INotifyPropertyChanged).GetMethod("remove_PropertyChanged");
            var removeMethod = typeBuilder.DefineMethod("remove_PropertyChanged",
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


    }




}
