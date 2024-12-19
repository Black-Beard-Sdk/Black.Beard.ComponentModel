using System;
using System.Reflection.Emit;
using System.Reflection;
using System.Collections.Generic;

namespace Bb.ComponentModel.Observables
{
    public static partial class DynamicGenerator
    {


        public static bool Intercept(Type type, bool makeObservable, bool makeDisposable, out InterceptorResult result)
        {

            bool status = true;

            result = new InterceptorResult
            {
                IsObservable = false,
                IsDisposable = false,
                Type = type
            };

            var _name = "Intercepted";
            var assemblyName = type.FullName + "_" + _name;
            var assembly = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(assemblyName), AssemblyBuilderAccess.Run);
            var module = assembly.DefineDynamicModule(assemblyName);
            var typeBuilder = module.DefineType(type.Name + _name, TypeAttributes.Class | TypeAttributes.Public, type);
            

            if (makeObservable)
            {
                typeBuilder.CreateObservable(type, result);
                if (!result.IsObservable)
                    status = false;
            }

            if (makeDisposable)
            {
                typeBuilder.CreateIDisposable(type, result);
                if (!result.IsDisposable)
                    status = false;
            }

            if (status && (makeObservable | makeDisposable))
            {
                typeBuilder.OverrideConstructor(type, result);
                result.Type = typeBuilder.CreateType();
            }

            return status;

        }

    }

    public class InterceptorResult
    {

        public InterceptorResult()
        {
            this._list = new List<string>();
        }

        public bool IsObservable { get; set; }

        public bool IsDisposable { get; set; }

        public Type Type { get; set; }

        internal void Log(string v)
        {
            _list.Add(v);
        }

        private readonly List<string> _list;

    }


}
