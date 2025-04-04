﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bb.ComponentModel.Factories
{


    /// <summary>
    /// Factory of T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FactoryByIoc<T> : Factory, IFactoryByIoc<T>
        where T : class
    {


        public FactoryByIoc(ObjectCreatorByIoc<T> objectActivator, MethodBase methodSource, ParameterInfo[] paramsInfo, MethodDescription description)
          : base(methodSource, paramsInfo, description, typeof(T))
        {
            this._delegate = objectActivator;
            base.MethodCall = typeof(Factory<T>).GetMethod(nameof(Call));
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
        public override object CallInstance()
        {
            return Call(null, null);
        }

        /// <summary>
        /// Creates a new instance of T with the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public override object CallInstance(params dynamic[] args)
        {
            if (args.Length == 0)
                return Call(null, null);
            return Call(null, (IServiceProvider)args[0]);
        }

        /// <summary>
        /// Creates a new instance of T with the specified arguments.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public T Invoke(IServiceProvider serviceProvider)
        {
            return Call(null, serviceProvider);
        }

        /// <summary>
        /// Creates a new instance of T with the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough]
        [System.Diagnostics.DebuggerNonUserCode]
        public T CallByKey(string key, params dynamic[] args)
        {

            var arg1 = (IServiceProvider)args[0];

            if (this.IsCtor && args.Length == 0 && !string.IsNullOrEmpty(key))
            {

                if (!this._dic.TryGetValue(key, out T result))
                    this._dic.Add(key, result = _delegate(arg1));

                return result;

            }

            return _delegate(arg1);

        }


        /// <summary>
        /// Creates a new instance of T with the specified arguments.
        /// </summary>
        /// <param name="arg">The arguments.</param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough]
        [System.Diagnostics.DebuggerNonUserCode]
        public T Call(string key, IServiceProvider arg)
        {

            if (this.IsCtor && !string.IsNullOrEmpty(key))
            {

                if (!this._dic.TryGetValue(key, out T result))
                    this._dic.Add(key, result = _delegate(arg));

                return result;

            }

            return _delegate(arg);

        }

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
        /// Set attribute to looking for inject instance
        /// </summary>
        /// <typeparam name="T1">Type of attribute to looking for</typeparam>
        public void SetInjectionAttribute<T1>()
            where T1 : Attribute
        {
            ObjectCreatorByIoc.SetInjectionAttribute<T1>();
        }

        /// <summary>
        /// Clear attribute to looking for inject instance
        /// </summary>
        public static void ClearAttribute()
        {
            ObjectCreatorByIoc.ClearSetInjectionAttribute();
        }

        /// <summary>
        /// return false if the delegate is null
        /// </summary>
        public override bool IsEmpty => _delegate == null;

        private ObjectCreatorByIoc<T> _delegate { get; }
        private readonly Dictionary<string, T> _dic;



    }


}
