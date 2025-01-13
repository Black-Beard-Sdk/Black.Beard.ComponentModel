
using System;

namespace Bb.ComponentModel
{
    /// <summary>
    /// Class base that implement default behavior for <see cref="IInjectBuilder{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class InjectBuilderBase<T> : IInjectBuilder<T>
    {

        /// <summary>
        /// Friendly name of the builder. by default it's the namespace + name of the class
        /// </summary>
        public virtual string FriendlyName => $"{GetType().Namespace}.{GetType().Name}";

        /// <summary>
        /// Return the type of service that should be passed by argument
        /// </summary>
        public virtual Type Type => typeof(T);

        /// <summary>
        /// Return true if the process can be ran
        /// </summary>
        /// <param name="context">specified context <see cref="T"/></param>
        /// <returns></returns>
        public virtual bool CanExecute(T context) => true;

        /// <summary>
        /// Return true if the process can be run
        /// </summary>
        /// <param name="context">specified context <see cref="object"/></param>
        /// <returns></returns>
        public virtual bool CanExecute(object context) => CanExecute((T)context);

        /// <summary>
        /// Execute the initializing process with <see cref="object"/>
        /// </summary>
        /// <param name="context">specified context <see cref="object"/></param>
        /// <returns></returns>
        public virtual object Execute(object context) => Execute((T)context);

        /// <summary>
        /// Execute the initializing process with <see cref="T"/>
        /// </summary>
        /// <param name="context">specified context <see cref="T"/></param>
        /// <returns></returns>
        public abstract object Execute(T context);

    }

}
