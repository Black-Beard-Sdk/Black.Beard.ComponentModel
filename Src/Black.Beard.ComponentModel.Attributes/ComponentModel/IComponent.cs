using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bb.ComponentModel
{

    //public delegate void CascadeEventHandler(object? sender, EventArgs e);

    /// <summary>
    /// Represents a component that can be added to a container.
    /// </summary>
    public interface IUIComponent : IUISite
    {

        /// <summary>
        /// Get asked service
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        object GetService(Type type);

    }

    /// <summary>
    /// Represents a component that can be added to a container.
    /// </summary>
    public interface IUISite : IDisposed, INotifyPropertyChanged
    {

        /// <summary>
        /// Gets the name of the parent component.
        /// </summary>
        IUIComponent Parent { get; set; }

        ///// <summary>
        ///// Initializes a cascading update
        ///// </summary>
        //void UpdateCascade();

        //void UpdateCascadeUp();

        //void UpdateCascadeDown();

        //event CascadeEventHandler? Cascade;

    }


}
