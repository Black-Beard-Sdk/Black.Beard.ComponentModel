
using System;
using System.Collections.Generic;

namespace Bb.ComponentModel
{

    /// <summary>
    /// Class base that implement default behavior for <see cref="IInjectBuilder{T}"/>
    /// </summary>
    /// <typeparam name="T">context of the initialization</typeparam>
    /// <example>
    /// 
    /// Sample add service in the web application
    /// 
    /// First add a new class that will intercept the service to configure. in this case the WebApplicationBuilder and the WebApplication
    /// <code lang="C#">
    ///     
    ///     [ExposeClass(ConstantsCore.Initialization, ExposedType = typeof(IInjectBuilder&lt;WebApplicationBuilder&gt;), LifeCycle = IocScopeEnum.Transiant)]
    ///     public class ConfigureWebApplicationBuilder : InjectBuilder&lt;WebApplicationBuilder&gt;
    ///     {
    ///         public object Execute(WebApplicationBuilder context)
    ///         {
    ///             // Add your code here
    ///             return null;
    ///         }
    ///     }
    ///     
    ///     [ExposeClass(ConstantsCore.Initialization, ExposedType = typeof(IInjectBuilder&lt;WebApplication&gt;), LifeCycle = IocScopeEnum.Transiant)]
    ///     public class ConfigureWebApplication : InjectBuilder&lt;WebApplication&gt;
    ///     {
    ///         public object Execute(WebApplication context)
    ///         {
    ///             // Add your code here
    ///             return null;
    ///         }
    ///     }
    /// </code>
    /// 
    /// call the builder in the main program
    /// <code>
    /// 
    ///     // In the main program insert the bloc that create and initialize the WebApplication class
    ///     WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
    ///     builder.Configure(builder.Services.BuildServiceProvider());
    ///
    ///     var app = builder.Build();
    ///     app.Configure(app.Services);
    ///     
    /// </code>
    /// 
    /// exclude the builder from the environment
    /// <code>
    ///     InjectBuilder.InitializeExcludedFromEnvironment("environmentKey"); 
    /// </code>
    /// 
    ///     /// 
    /// exclude the builder from the variable launch
    /// <code>
    ///     run -friendlyName
    /// </code>
    /// 
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
        public virtual bool CanExecute(T context) => FilterToLaunch(this);

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
        public virtual bool CanExecute(object context) => FilterToLaunch != null ? FilterToLaunch(this) : true;

        /// <summary>
        /// Execute the initializing process with <see cref="object"/>
        /// </summary>
        /// <param name="context">specified context <see cref="object"/></param>
        /// <returns></returns>        
        public abstract object Execute(object context);

        /// <summary>
        /// Internal filter to launch the builders
        /// </summary>
        public static Func<IInjectBuilder, bool> FilterToLaunch = (i) => true;

        /// <summary>
        /// Sets the specified friendly name and launch flag.
        /// </summary>
        /// <param name="friendlyName">The friendly name.</param>
        /// <param name="toLaunch">The launch flag.</param>
        /// <remarks>
        /// This method sets the launch flag for the specified friendly name. If the launch flag is true, the friendly name is removed from the cache. If the launch flag is false, the friendly name is added to the cache.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when the friendlyName parameter is null.</exception>
        public static void Set(string friendlyName, bool toLaunch)
        {

            if (friendlyName == null)
                throw new ArgumentNullException(nameof(friendlyName));

            if (toLaunch)
            { 
                if (_cache.Contains(friendlyName))
                    _cache.Remove(friendlyName);
            }
            else
            {
                if (!_cache.Contains(friendlyName))
                    _cache.Add(friendlyName);
            }
        }

        /// <summary>
        /// Determines whether the specified builder should be injected into the builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns><c>true</c> if the specified builder should be injected into the builder; otherwise, <c>false</c>.</returns>
        /// <remarks>
        /// This method checks if the specified builder's friendly name is not present in the cache of a item that must not to execute. If the friendly name is not present, it means the builder should be injected into the builder.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when the builder parameter is null.</exception>
        public static bool ToInjectBuilder(IInjectBuilder builder)
        {

            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            return !_cache.Contains(builder.FriendlyName);

        }

        /// <summary>
        /// Initializes the excluded items from the environment based on the specified key.
        /// </summary>
        /// <param name="key">The key to retrieve the environment variable.</param>
        /// <remarks>
        /// This method retrieves the value of the environment variable specified by the key parameter. If the value is not null, it splits the value into individual items using ';' as the separator. For each item, if it starts with '-', it adds the item (excluding the '-' character) to the cache. Otherwise, it removes the item from the cache.
        /// e.g. If the value is "friendlyName1;friendlyName2;-friendlyName3", the cache will contain "friendlyName1" and "friendlyName2" and will not contain "friendlyName3".
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when the key parameter is null.</exception>
        public static void InitializeExcludedFromEnvironment(string key)
        {
            var value = Environment.GetEnvironmentVariable(key);
            if (string.IsNullOrEmpty(value))
            {
                var items = value.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in items)
                {
                    if (item.StartsWith("-"))
                        _cache.Add(item.Substring(1));
                    else
                        _cache.Remove(item);
                }
            }
        }

        private static HashSet<string> _cache = new HashSet<string>();

    }

}
