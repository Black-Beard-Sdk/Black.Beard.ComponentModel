
using Bb.ComponentModel.Attributes;
using System;

namespace Bb.ComponentModel
{

    /// <summary>
    /// Class base that implement default behavior for <see cref="IInjectBuilder{T}"/>
    /// </summary>
    /// <typeparam name="T">context of the initialization</typeparam>
    /// <example>
    /// 
    ///     Sample add service in the web application
    /// 
    /// <code lang="C#>
    /// 
    ///     // In the main inser the bloc that create and initialize the WebApplication class
    ///     WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
    ///     builder.Initialize(builder.Services.BuildServiceProvider(), null, c => { });
    ///
    ///     var app = builder.Build();
    ///     app.Initialize(app.Services, null, c => { });
    ///     
    ///     // add a new class that will add service in the web application
    ///     [ExposeClass(ConstantsCore.Initialization, ExposedType = typeof(IInjectBuilder&lt;WebApplicationBuilder&gt;), LifeCycle = IocScopeEnum.Transiant)]
    ///     public class ConfigureWebApplicationBuilder : InjectBuilder&lt;WebApplicationBuilder&gt;
    ///     {
    ///         public object Execute(WebApplicationBuilder builder)
    ///         {
    ///             var services = builder.Services;
    ///             // Add service
    ///             return null;
    ///         }
    ///     }
    /// 
    /// 
    /// 
    ///     // add a new class that will configure the WebApplication service
    ///     [ExposeClass(ConstantsCore.Initialization, ExposedType = typeof(IInjectBuilder&lt;WebApplication&gt;), LifeCycle = IocScopeEnum.Transiant)]
    ///     public class ConfigureWebApplication : InjectBuilder&lt;WebApplication&gt;
    ///     {
    ///         public object Execute(WebApplication builder)
    ///         {
    ///             return null;
    ///         }
    ///     }
    /// </code>
    /// </example>
    public abstract class InjectBuilder<T> : InjectBuilder, IInjectBuilder<T>
    {

        /// <summary>
        /// Return the type of service that should be passed by argument
        /// </summary>
        public override Type Type => typeof(T);

        /// <summary>
        /// Return true if the process can be ran
        /// </summary>
        /// <param name="context">specified context <see cref="T"/></param>
        /// <returns></returns>
        public virtual bool CanExecute(T context) => true;

        /// <summary>
        /// Return true if the process can be run
        /// </summary>
        /// <param name="context">specified context <see cref="object"/></param>
        /// <returns></returns>
        public override bool CanExecute(object context) => CanExecute((T)context);

        /// <summary>
        /// Execute the initializing process with <see cref="object"/>
        /// </summary>
        /// <param name="context">specified context <see cref="object"/></param>
        /// <returns></returns>        
        public override object Execute(object context) => Execute((T)context);

        /// <summary>
        /// Execute the initializing process with <see cref="T"/>
        /// </summary>
        /// <param name="context">specified context <see cref="T"/></param>
        /// <returns></returns>
        public abstract object Execute(T context);

    }

    /// <summary>
    /// Class base that implement default behavior for <see cref="IInjectBuilder"/>
    /// </summary>
    public abstract class InjectBuilder : IInjectBuilder
    {

        /// <summary>
        /// Friendly name of the builder. by default it's the namespace + name of the class
        /// </summary>
        public virtual string FriendlyName => $"{GetType().Namespace}.{GetType().Name}";

        /// <summary>
        /// Return the type of service that should be passed by argument
        /// </summary>
        public abstract Type Type { get; }

        /// <summary>
        /// Return true if the process can be run
        /// </summary>
        /// <param name="context">specified context <see cref="object"/></param>
        /// <returns></returns>
        public virtual bool CanExecute(object context) => true;

        /// <summary>
        /// Execute the initializing process with <see cref="object"/>
        /// </summary>
        /// <param name="context">specified context <see cref="object"/></param>
        /// <returns></returns>        
        public abstract object Execute(object context);

    }

}
