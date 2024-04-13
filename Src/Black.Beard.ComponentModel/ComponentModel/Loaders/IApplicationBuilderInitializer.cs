using System;
using System.ComponentModel.Design;

namespace Bb.ComponentModel.Loaders
{


    public interface IApplicationBuilderInitializer<T> : IApplicationBuilderInitializer
    {

        bool CanInitialize(T builder, InitializationLoader<T> initializer);


        void Initialize(T builder);


        bool CanConfigure(T builder, InitializationLoader<T> initializer);


        void Configure(T builder);

    }


}
