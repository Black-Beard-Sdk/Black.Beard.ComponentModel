using Bb.ComponentModel.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Bb.ComponentModel
{
    public class MethodDiscoveryAssembly
    {

        public MethodDiscoveryAssembly(ITypeReferential typeReferential, string startWith, Type inheritFrom)
        {
            _typeReferential = typeReferential;
            _startWith = startWith;
            _inheritFrom = inheritFrom;
        }


        public string Context { get; set; }

        /// <summary>
        /// Return list of method for the specified arguments
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="returnType"></param>
        /// <param name="methodSign"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">returnType</exception>
        /// <exception cref="ArgumentNullException">methodSign</exception>
        public virtual IEnumerable<(Type, ExposeClassAttribute, ExposeMethodAttribute, MethodInfo)> GetActions(BindingFlags bindings, Type returnType, List<Type> methodSign) //where T : Context
        {

            this.methodSign = methodSign;
            this.returnType = returnType;

            Type[] types = GetTypes();
            var actions = GetActions_Impl(bindings, types);

            if (!string.IsNullOrEmpty(_startWith))
                return actions.Where(c => c.Item3.DisplayName.StartsWith(_startWith)).ToList();

            return actions;

        }

        public virtual Type[] GetTypes()
        {

            var t = _inheritFrom ?? typeof(object);

            var types = !string.IsNullOrEmpty(Context)
                ? _typeReferential.GetTypesWithAttributes<ExposeClassAttribute>(t, attribute => attribute.Context == Context)
                : _typeReferential.GetTypesWithAttributes(typeof(ExposeClassAttribute));

            return types.ToArray();

        }

        /// <summary>
        /// Permet de retourner la liste des methodes d'evaluation disponibles dans les types fournis.
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        private IEnumerable<(Type, ExposeClassAttribute, ExposeMethodAttribute, MethodInfo)> GetActions_Impl(BindingFlags bindings, params Type[] types)
        {

            var _result = new List<(Type, ExposeClassAttribute, ExposeMethodAttribute, MethodInfo)>();

            var _types = new ExposedTypes()
               .GetTypes()
               .Where(c => types.Contains(c.Key))
               .ToList();

            foreach (var u in _types)
            {

                var type = u.Key;

                foreach (ExposeClassAttribute attribute in u.Value)
                    if (attribute.Context == Context)
                    {

                        var items = MethodDiscovery.GetMethods(type, bindings, returnType, methodSign);

                        foreach (var method in items)
                        {

                            ExposeMethodAttribute attribute2 = TypeDescriptor.GetAttributes(method).OfType<ExposeMethodAttribute>().FirstOrDefault();
                            if (attribute2 != null && (string.IsNullOrEmpty(Context) || attribute2.Context == Context))
                                _result.Add((u.Key, attribute, attribute2, method));

                        }
                    }

            }

            return _result;
        }

        private Type returnType;
        private List<Type> methodSign;
        private readonly ITypeReferential _typeReferential;
        private readonly string _startWith;
        private readonly Type _inheritFrom;
    }
}



