﻿using System;

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
        void Execute(object context);

        /// <summary>
        /// Return true if the process can be ran
        /// </summary>
        /// <param name="context">specified context <see cref="object"/></param>
        /// <returns></returns>
        bool CanExecute(object context);

        /// <summary>
        /// Return the type of service that should be passed by argument
        /// </summary>
        Type Type { get; }

    }



}
