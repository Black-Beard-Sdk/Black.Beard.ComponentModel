using System;
using System.Collections.Generic;

namespace Bb.ComponentModel.Factories
{

    public class ObjectActivatorResolver<T>
        where T : class
    {

        public ObjectActivatorResolver()
        {

            _dic = new Index();
            var ctors = typeof(T).GetConstructors();
            foreach (var item in ctors)
            {
                var i = ObjectCreator.GetActivator<T>(item);
                _dic.Add(i.Item2, i.Item1);
            }

        }

        public ObjectCreator<T> Get(Type[] args)
        {

            var instance = _dic.Get(args);
            if (instance != null)
                return instance;

            throw new Exception();

        }

        private Index _dic;


        private class Index
        {

            public Index()
            {
                this._dic = new Dictionary<Type, Index>();
            }

            public void Add(Type[] types, ObjectCreator<T> instance)
            {

                if (types.Length == 0)
                    this._instance = instance;

                else
                    Add(0, types, instance);

            }

            private void Add(int index, Type[] types, ObjectCreator<T> instance)
            {

                if (index < types.Length)
                {

                    var type = types[index];
                    if (!_dic.TryGetValue(type, out Index i))
                    {
                        i = new Index();
                        _dic.Add(type, i);
                    }
                    i.Add(index + 1, types, instance);
                }
                else
                    this._instance = instance;

            }

            internal ObjectCreator<T> Get(Type[] args)
            {
                return Get(0, args);
            }

            private ObjectCreator<T> Get(int v, Type[] args)
            {
                if (v == args.Length)
                    return _instance;

                return _dic[args[v]].Get(v + 1, args);

            }

            private ObjectCreator<T> _instance;
            private readonly Dictionary<Type, Index> _dic;
        }

    }


}