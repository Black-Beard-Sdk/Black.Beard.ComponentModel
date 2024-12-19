using System;
using System.Reflection.Emit;
using System.Reflection;
using System.Linq;

namespace Bb.ComponentModel.Observables
{

    public static partial class DynamicGenerator
    {


        public static void OverrideConstructor(this TypeBuilder typeBuilder, Type type, InterceptorResult result)
        {


            type.GetConstructors().ToList().ForEach((Action<ConstructorInfo>)(ctorBase =>
            {
                var parameters = ctorBase.GetParameters();

                if (parameters.Length == 0)
                    typeBuilder.DefineDefaultConstructor(ctorBase.Attributes);
                
                else
                {
                    var types = parameters.Select(p => p.ParameterType).ToArray();
                    var newCtor = typeBuilder.DefineConstructor((MethodAttributes)ctorBase.Attributes, CallingConventions.Standard, types);
                    var il = newCtor.GetILGenerator();

                    il.Emit(OpCodes.Ldarg_0);
                    for (int i = 0; i < parameters.Length; i++)
                        il.Emit(OpCodes.Ldarg, i + 1);
                    il.Emit(OpCodes.Call, ctorBase);
                    il.Emit(OpCodes.Nop);
                    il.Emit(OpCodes.Nop);
                    il.Emit(OpCodes.Ret);
                }
            }));

        }

    }




}
