﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bb.ComponentModel.Factories
{


    /// <summary>
    /// Factory of T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Factory<T> : Factory, IFactory<T>
        where T : class
    {


        public Factory(ObjectCreator<T> objectActivator, MethodBase methodSource, ParameterInfo[] paramsInfo, MethodDescription description)
          : base(methodSource, paramsInfo, description, typeof(T))
        {
            this._delegate = objectActivator;
            base.MethodCall = typeof(Factory<T>).GetMethod(nameof(CallByKey));
            base.MethodReset = typeof(Factory<T>).GetMethod(nameof(Reset));
            base.MethodParameters = methodSource.GetParameters();
            Types = this.MethodParameters.Select(c => c.ParameterType).ToArray();
            this._dic = new Dictionary<string, T>();
            this.Name = description.Name;
        }


        /// <summary>
        /// Creates a new instance of T with the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public override object CallInstance(params dynamic[] args)
        {
            return CallByKey(null, args);
        }

        /// <summary>
        /// Creates a new instance of T with the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public override object CallInstance()
        {
            return CallByKey(null, null);
        }

        /// <summary>
        /// Creates a new instance of T with the specified arguments.
        /// </summary>
        /// <param name="key">key for match in the repository.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough]
        [System.Diagnostics.DebuggerNonUserCode]
        public T CallByKey(string key, params dynamic[] args)
        {

            if (this.IsCtor && args.Length == 0 && !string.IsNullOrEmpty(key))
            {

                if (!this._dic.TryGetValue(key, out T result))
                    this._dic.Add(key, result = _delegate(args));

                return result;

            }

            return _delegate(args);

        }

        ///// <summary>
        ///// Creates a new instance of T with the specified arguments.
        ///// </summary>
        ///// <param name="key">key for match in the repository.</param>
        ///// <param name="args">The arguments.</param>
        ///// <returns></returns>
        //[System.Diagnostics.DebuggerStepThrough]
        //[System.Diagnostics.DebuggerNonUserCode]
        //public T Call(params dynamic[] args)
        //{

        //    if (this.IsCtor && args.Length == 0 && !string.IsNullOrEmpty(key))
        //    {

        //        if (!this._dic.TryGetValue(null, out T result))
        //            this._dic.Add(null, result = _delegate(args));

        //        return result;

        //    }

        //    return _delegate(args);

        //}


        /// <summary>
        /// Creates a new instance of T with the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public void Reset()
        {
            this._dic.Clear();
        }

        /// <summary>
        /// return false if the delegate is null
        /// </summary>
        public override bool IsEmpty => _delegate == null;

        private ObjectCreator<T> _delegate { get; }
        private readonly Dictionary<string, T> _dic;

        

    }


}
