﻿
namespace Bb.ComponentModel
{

    /// <summary>
    /// specialized interface for Initialize service
    /// </summary>
    public interface IInjectBuilder<T> : IInjectBuilder
    {

        /// <summary>
        /// Return true if the process can be run
        /// </summary>
        /// <param name="context">specified context <see cref="T"/></param>
        /// <returns></returns>
        bool CanExecute(T context);


        /// <summary>
        /// Execute the initializing process with <see cref="T"/>
        /// </summary>
        /// <param name="context">specified context <see cref="T"/></param>
        /// <returns></returns>
        object Execute(T context);


    }

}
