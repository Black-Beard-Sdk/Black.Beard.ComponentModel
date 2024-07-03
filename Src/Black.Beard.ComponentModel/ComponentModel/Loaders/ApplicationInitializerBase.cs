//using System;

//namespace Bb.ComponentModel.Loaders
//{
//    /// <summary>
//    /// Class initializer base
//    /// </summary>
//    /// <typeparam name="T"></typeparam>
//    public abstract class ApplicationInitializerBase<T> : IApplicationBuilderInitializer<T>
//    {

//        /// <summary>
//        /// Initializes a new instance of the <see cref="ApplicationInitializerBase{T}"/> class.
//        /// </summary>
//        public ApplicationInitializerBase()
//        {


//        }

//        /// <summary>
//        /// Gets the friendly name.
//        /// </summary>
//        public virtual string FriendlyName => GetType().Name;

//        /// <summary>
//        /// Gets the execution order priority.
//        /// </summary>
//        public virtual int OrderPriority => 0;

//        /// <summary>
//        /// Gets or sets a value indicating whether this <see cref="ApplicationInitializerBase{T}"/> is executed.
//        /// </summary>
//        public bool Executed { get; set; }

//        /// <summary>
//        /// Gets the type of the expected service.
//        /// </summary>
//        public virtual Type Type => typeof(T);

//        /// <summary>
//        /// Determines whether this instance can execute the specified builder.
//        /// </summary>
//        /// <param name="builder"></param>
//        /// <param name="initializer"></param>
//        /// <returns></returns>
//        public virtual bool CanExecute(T builder, InitializationLoader<T> initializer)
//        {
//            return true;
//        }

//        /// <summary>
//        /// Initializing method to override
//        /// </summary>
//        /// <param name="builder"></param>
//        public abstract void Execute(T builder);

//    }


//}
