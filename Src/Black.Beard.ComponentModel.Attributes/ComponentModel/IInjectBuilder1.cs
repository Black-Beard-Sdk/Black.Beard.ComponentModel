using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bb.ComponentModel
{

    /// <summary>
    /// specialized interface for Initialize service
    /// </summary>
    public interface IInjectBuilder<T> : IInjectBuilder
    {

        /// <summary>
        /// Execute the initializing process with <see cref="T"/>
        /// </summary>
        /// <param name="context">specified context <see cref="T"/></param>
        /// <returns></returns>
        object Run(T context);

        /// <summary>
        /// Return true if the process can be run
        /// </summary>
        /// <param name="context">specified context <see cref="T"/></param>
        /// <returns></returns>
        bool CanExecute(T context);


    }

}
