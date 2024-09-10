//using System;

//namespace Bb
//{

//    public interface IProjectorService<T>
//    {

//        void Register(T targetService);

//        void Project(object sourceService, T targetService);

//    }

//    public class ProjectorEventArgs<T> : EventArgs
//    {

//        public ProjectorEventArgs(Action<T, object, bool> test, Action<T, object> evaluator)
//        {
//            Evaluate = evaluator;
//        }

//        public Action<T, object> Evaluate { get; }

//    }

//}
