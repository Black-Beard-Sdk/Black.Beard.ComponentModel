using System;
using System.ComponentModel.Design;

namespace Bb.ComponentModel.Loaders
{


    public interface IApplicationBuilderInitializer<T> : IApplicationBuilderInitializer
    {

        bool CanExecute(T builder, InitializationLoader<T> initializer);


        void Execute(T builder);


    }


}
