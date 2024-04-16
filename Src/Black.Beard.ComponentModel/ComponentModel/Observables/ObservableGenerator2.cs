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
     

        //private static void ImplementAddEvent(TypeBuilder typeBuilder, FieldBuilder field, EventBuilder eventInfo)
        //{
        //    var ibaseMethod = typeof(INotifyPropertyChanged).GetMethod("add_PropertyChanged");
        //    var addMethod = typeBuilder.DefineMethod("add_PropertyChanged",
        //        ibaseMethod.Attributes ^ MethodAttributes.Abstract,
        //        ibaseMethod.CallingConvention,
        //        ibaseMethod.ReturnType,
        //        new[] { typeof(PropertyChangedEventHandler) });
        //    var generator = addMethod.GetILGenerator();
        //    var combine = typeof(Delegate).GetMethod("Combine", new[] { typeof(Delegate), typeof(Delegate) });
        //    generator.Emit(OpCodes.Ldarg_0);
        //    generator.Emit(OpCodes.Ldarg_0);
        //    generator.Emit(OpCodes.Ldfld, field);
        //    generator.Emit(OpCodes.Ldarg_1);
        //    generator.Emit(OpCodes.Call, combine);
        //    generator.Emit(OpCodes.Castclass, typeof(PropertyChangedEventHandler));
        //    generator.Emit(OpCodes.Stfld, field);
        //    generator.Emit(OpCodes.Ret);
        //    eventInfo.SetAddOnMethod(addMethod);
        //}


        //private static MethodBuilder ImplementOnPropertyChanged(TypeBuilder typeBuilder, FieldBuilder field,
        //    EventBuilder eventInfo)
        //{
        //    var methodBuilder = typeBuilder.DefineMethod("OnPropertyChanged",
        //        MethodAttributes.Family | MethodAttributes.Virtual | MethodAttributes.HideBySig |
        //        MethodAttributes.NewSlot, typeof(void),
        //        new[] { typeof(string) });
        //    var generator = methodBuilder.GetILGenerator();
        //    var returnLabel = generator.DefineLabel();
        //    var propertyArgsCtor = typeof(PropertyChangedEventArgs).GetConstructor(new[] { typeof(string) });
        //    generator.DeclareLocal(typeof(PropertyChangedEventHandler));
        //    generator.Emit(OpCodes.Ldarg_0);
        //    generator.Emit(OpCodes.Ldfld, field);
        //    generator.Emit(OpCodes.Stloc_0);
        //    generator.Emit(OpCodes.Ldloc_0);
        //    generator.Emit(OpCodes.Brfalse, returnLabel);
        //    generator.Emit(OpCodes.Ldloc_0);
        //    generator.Emit(OpCodes.Ldarg_0);
        //    generator.Emit(OpCodes.Ldarg_1);
        //    generator.Emit(OpCodes.Newobj, propertyArgsCtor);
        //    generator.Emit(OpCodes.Callvirt, typeof(PropertyChangedEventHandler).GetMethod("Invoke"));
        //    generator.MarkLabel(returnLabel);
        //    generator.Emit(OpCodes.Ret);
        //    eventInfo.SetRaiseMethod(methodBuilder);
        //    return methodBuilder;
        //}


        //private static MethodBuilder ImplementPropertyChanged(TypeBuilder typeBuilder)
        //{
        //    typeBuilder.AddInterfaceImplementation(typeof(INotifyPropertyChanged));
        //    var field = typeBuilder.DefineField("PropertyChanged", typeof(PropertyChangedEventHandler),
        //        FieldAttributes.Private);
        //    var eventInfo = typeBuilder.DefineEvent("PropertyChanged", EventAttributes.None,
        //        typeof(PropertyChangedEventHandler));
        //    //var methodBuilder = ImplementOnPropertyChangedHelper(typeBuilder, field, eventInfo);
        //    var methodBuilder = ImplementOnPropertyChanged(typeBuilder, field, eventInfo);
        //    ImplementAddEvent(typeBuilder, field, eventInfo);
        //    ImplementRemoveEvent(typeBuilder, field, eventInfo);
        //    return methodBuilder;
        //}


        //private static void ImplementRemoveEvent(TypeBuilder typeBuilder, FieldBuilder field, EventBuilder eventInfo)
        //{
        //    var ibaseMethod = typeof(INotifyPropertyChanged).GetMethod("remove_PropertyChanged");
        //    var removeMethod = typeBuilder.DefineMethod("remove_PropertyChanged",
        //        ibaseMethod.Attributes ^ MethodAttributes.Abstract,
        //        ibaseMethod.CallingConvention,
        //        ibaseMethod.ReturnType,
        //        new[] { typeof(PropertyChangedEventHandler) });
        //    var remove = typeof(Delegate).GetMethod("Remove", new[] { typeof(Delegate), typeof(Delegate) });
        //    var generator = removeMethod.GetILGenerator();
        //    generator.Emit(OpCodes.Ldarg_0);
        //    generator.Emit(OpCodes.Ldarg_0);
        //    generator.Emit(OpCodes.Ldfld, field);
        //    generator.Emit(OpCodes.Ldarg_1);
        //    generator.Emit(OpCodes.Call, remove);
        //    generator.Emit(OpCodes.Castclass, typeof(PropertyChangedEventHandler));
        //    generator.Emit(OpCodes.Stfld, field);
        //    generator.Emit(OpCodes.Ret);
        //    eventInfo.SetRemoveOnMethod(removeMethod);
        //}


    }




}
