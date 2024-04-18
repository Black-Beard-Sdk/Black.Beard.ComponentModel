using Bb.ComponentModel.Attributes;
using System;

namespace Bb.Injections
{
    [System.Diagnostics.DebuggerDisplay("{LifeCycle} : {Type.FullName} -> {ImplementationType.FullName}")]
    public class TypeToInject
    {

        public TypeToInject()
        {

        }

        public Type? Type { get; set; }


        public IocScopeEnum LifeCycle { get; set; }

        public Type? ImplementationType { get; set; }

        public Func<IServiceProvider, object>? Function { get; set; }

        public object? Instance { get; set; }

    }



}
