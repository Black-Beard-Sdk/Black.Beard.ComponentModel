using System;

namespace Bb.ComponentModel
{
    public abstract class InjectBuilder<T> : IInjectBuilder<T>
    {

        public InjectBuilder()
        {

        }

        public Type Type => typeof(T);


        public string FriendlyName => GetType().Name;

        public virtual bool CanExecute(T service)
        {
            return true;
        }


        public bool CanExecute(object context)
        {
            return CanExecute((T)context);
        }

        public abstract object Execute(T service);

        public object Execute(object context)
        {
            return Execute((T)context);
        }


    }



}
