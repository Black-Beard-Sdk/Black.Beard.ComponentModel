using System;

namespace Bb.ComponentModel.Factories
{
    /// <summary>
    /// IFactory base
    /// </summary>
    public interface IFactory
    {


        public string Name { get; }

        /// <summary>
        /// return false if the delegate is null
        /// </summary>
        public bool IsEmpty { get; }

        public bool IsStatic { get; }

        public bool IsCtor { get; }

        public Type[] Types { get; }

        public MethodDescription MethodInfos { get; }

    }
      

}

