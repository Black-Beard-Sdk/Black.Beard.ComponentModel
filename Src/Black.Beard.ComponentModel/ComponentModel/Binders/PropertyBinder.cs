using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using Bb.Expressions;

namespace Bb.ComponentModel.Binders
{


    public class PropertyBinder<TTarget>
    {

        public PropertyBinder()
        {
            this._dic = new Dictionary<string, Action<TTarget, object>>();

        }


        #region parameters

        public void Clear()
        {
            _dic.Clear();
        }

        public void Clear(string propertyName)
        {
            if (_dic.ContainsKey(propertyName))
                _dic.Remove(propertyName);
        }


        public void Bind<TSource>(Expression<Func<TSource, object>> expression, Action<TTarget, object> action)
            where TSource : class, INotifyPropertyChanged
        {
            var propertyName = expression.GetPropertyName();
            Bind(propertyName, action);
        }

        public void Bind(string propertyName, Action<TTarget, object> action)
        {

            if (!_dic.TryGetValue(propertyName, out var a))
                _dic[propertyName] = action;

            else
                _dic[propertyName] = (o, t) =>
                {
                    a(o, t);
                    action(o, t);
                };

        }

        #endregion parameters


        internal bool TryGet(string propertyName, out Action<TTarget, object> action)
        {
            return _dic.TryGetValue(propertyName, out action);
        }

        private Dictionary<string, Action<TTarget, object>> _dic;

    }


}
