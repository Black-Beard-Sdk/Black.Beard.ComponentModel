using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bb.ComponentModel
{
    
    /// <summary>
    /// Generic interface for Initialize service
    /// </summary>
    public interface IInjectBuilder
    {

        /// <summary>
        /// Friendly name of the builder
        /// </summary>
        string FriendlyName { get; }


        /// <summary>
        /// Execute the initializing process with <see cref="object"/>
        /// </summary>
        /// <param name="context">specified context <see cref="object"/></param>
        /// <returns></returns>
        object Execute(object context);

        /// <summary>
        /// Return true if the process can be run
        /// </summary>
        /// <param name="context">specified context <see cref="object"/></param>
        /// <returns></returns>
        bool CanExecute(object context);

        /// <summary>
        /// Return the type of service that should be passed by argument
        /// </summary>
        Type Type { get; }


    }



    public abstract class InjectBuilder<T> : IInjectBuilder<T>
    {

        public InjectBuilder()
        {

        }

        public Type Type => typeof(T);


        public string FriendlyName => GetType().Name;

        public virtual bool CanExecute(T service)
        {
            return true;
        }


        public bool CanExecute(object context)
        {
            return CanExecute((T)context);
        }

        public abstract object Execute(T service);

        public object Execute(object context)
        {
            return Execute((T)context);
        }


    }



}
