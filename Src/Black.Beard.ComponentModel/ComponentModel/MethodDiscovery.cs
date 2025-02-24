﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace Bb.ComponentModel
{

    /// <summary>
    /// Permet de retourner la liste des methodes d'evaluation disponibles dans les types fournis.
    /// </summary>
    public static class MethodDiscovery
    {

        ///// <summary>
        ///// Return the list of method from list of types
        ///// </summary>
        ///// <param name="type">type the declare methods</param>
        ///// <param name="returnType">Not evaluated if null. method return type</param>
        ///// <param name="parameters">Not evaluated if null. method arguments type</param>
        ///// <returns></returns>
        //public static IEnumerable<MethodInfo> GetMethods(Type returnType, BindingFlags bindings, params Type[] parameters)
        //{
        //    var _methods = GetMethods(TypeDiscovery.Instance, bindings, returnType, parameters);
        //    return _methods;
        //}

        /// <summary>
        /// Return the list of method from list of types
        /// </summary>
        /// <param name="type">type the declare methods</param>
        /// <param name="returnType">Not evaluated if null. method return type</param>
        /// <param name="parameters">Not evaluated if null. method arguments type</param>
        /// <returns></returns>
        public static IEnumerable<MethodInfo> GetMethods(IEnumerable<Type> types, BindingFlags bindings, Type returnType, List<Type> parameters)
        {

            List<MethodInfo> _methods = new List<MethodInfo>();
            foreach (var type in types)
            {
                var methods = GetMethods(type, bindings, returnType, parameters);
                _methods.AddRange(methods);
            }

            return _methods;

        }

        private static bool Evaluate(MethodInfo m, Type returnType, List<Type> parameters)
        {
            try
            {
                return returnType == null || m.ReturnType == returnType && parameters == null || EvaluateMethodParameters(m, parameters);
            }
            catch (Exception)
            {

            }

            return false;

        }

        /// <summary>
        /// Return the list of method
        /// </summary>
        /// <param name="type">type the declare methods</param>
        /// <param name="returnType">Not evaluated if null. method return type</param>
        /// <param name="parameters">Not evaluated if null. method arguments type</param>
        /// <returns></returns>
        public static IEnumerable<MethodInfo> GetMethods(Type type, BindingFlags bindings, Type returnType, List<Type> parameters = null)
        {
            var methods = type.GetMethods(bindings);
            foreach (var c in methods)
                if (returnType == null || c.ReturnType == returnType)
                    if (parameters == null || EvaluateMethodParameters(c, parameters))
                        yield return c;

        }

        private static bool EvaluateMethodParameters(MethodInfo item, List<Type> parameters)
        {

            if (parameters != null)
            {
                var _parameters = item.GetParameters();
                if (_parameters.Length != parameters.Count)
                    return false;

                for (var i = 0; i < parameters.Count; i++)
                {
                    var _p1 = _parameters[i];
                    var _p2 = parameters[i];
                    if (_p1.ParameterType != _p2)
                        return false;
                }
            }

            return true;

        }


    }

}



