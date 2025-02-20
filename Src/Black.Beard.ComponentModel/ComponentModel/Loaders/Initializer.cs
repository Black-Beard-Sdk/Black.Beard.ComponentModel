using Bb.ComponentModel.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Bb.ComponentModel.Loaders
{


    /// <summary>
    /// Initialize the application
    /// </summary>
    /// <example>
    /// 
    /// Create a class that will be discovered
    /// <code lang="Csharp">
    /// [ExposeClass(ConstantsCore.Initialization, ExposedType = typeof(IInjectBuilder&lt;Initializer &gt;), LifeCycle = IocScopeEnum.Transiant)]
    /// public class NLogInitializer : IInjectBuilder &lt;Initializer &gt;
    /// {
    /// 
    ///     public string FriendlyName => typeof(NLogInitializer).Name;
    /// 
    ///     public Type Type => typeof(Initializer);
    /// 
    ///     public bool CanExecute(Initializer context) => context.CanExecuteModule(FriendlyName);
    /// 
    ///     public bool CanExecute(object context) => CanExecute((Initializer)context);
    /// 
    ///     public object Execute(object context) => Execute((Initializer)context);
    /// 
    ///     public object Execute(Initializer context)
    ///     {
    ///         // execute your code here
    ///         return null;
    ///     }
    /// 
    /// }
    /// </code>
    /// 
    /// Run the initializer
    /// <code lang="Csharp">
    ///     Initializer.Initialize(args);
    /// </code>
    /// 
    /// </example>
    public class Initializer : IServiceProvider
    {

        static Initializer()
        {
            Creator = (args) => new Initializer(args);
        }

        /// <summary>
        /// Discover all initializer and execute them for initializing the application
        /// </summary>
        /// <param name="args">arguments to push in the initialization process</param>
        /// <returns></returns>
        public static Initializer Initialize(params string[] args)
        {
            return Initialize((i) => { }, args);
        }

        /// <summary>
        /// Discover all initializer and execute them for initializing the application
        /// </summary>
        /// <param name="init">method to configure the process of initialization</param>
        /// <param name="args">arguments to push in the initialization process</param>
        /// <returns></returns>
        public static Initializer Initialize(Action<Initializer> init, params string[] args)
        {
            return Initialize(init, null, args);
        }

        /// <summary>
        /// Discover all initializer and execute them for initializing the application
        /// </summary>
        /// <param name="args">arguments to push in the initialization process</param>
        /// <param name="init">method to configure the process of initialization</param>
        /// <param name="initializer">method to configure every InjectionLoader</param>
        public static Initializer Initialize(Action<Initializer> init, Action<InjectionLoader<Initializer>> initializer, params string[] args)
        {

            init ??= (i) => { };
            initializer ??= (i) => { };

            if (args == null || args.Length == 0)
                args = Environment.GetCommandLineArgs();

            Initializer i = Creator(args);
            init(i);

            i.Initialize(initializer);

            return i;

        }

        /// <summary>
        /// Add service provider
        /// </summary>
        /// <param name="service">Service provider</param>
        /// <returns></returns>
        public Initializer WithService(IServiceProvider service)
        {
            if (service is LocalServiceProvider s && s.AutoAdd)
                _serviceProvider = s;
            else
                _serviceProvider = new LocalServiceProvider(service) { AutoAdd = true };
            return this;
        }

        /// <summary>
        /// Override the default creator
        /// </summary>
        public static Func<string[], Initializer> Creator { get; set; }

        /// <summary>
        /// The context of the initialization
        /// </summary>
        public static string Context { get; set; } = ConstantsCore.Initialization;

        /// <summary>
        /// initialize the initializer
        /// </summary>
        /// <param name="args"></param>
        protected Initializer(params string[] args)
        {
            _args = args;
            Initializer.Last = this;
            _datas = new Dictionary<string, object>();
            _datasConfigs = new Dictionary<string, HashSet<string>>();
        }

        /// <summary>
        /// return the last initializer instance
        /// </summary>
        public static Initializer Last { get; private set; }

        #region IServiceProvider

        /// <summary>
        /// Get asked service
        /// </summary>
        /// <param name="serviceType">type of the value to reach</param>
        /// <returns>return the service</returns>
        public object GetService(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }

        #endregion IServiceProvider

        /// <summary>
        /// Initialize the inject builder
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Initializer SetInjectValue(Func<string, object> value)
        {
            InjectValue = value;
            return this;
        }

        /// <summary>
        /// called if the system can't resolve the value
        /// </summary>
        public Func<PropertyDescriptor, string, IInjectBuilder<Initializer>, object> InjectRescue { get; set; }

        /// <summary>
        /// called if the system can't resolve the value
        /// </summary>
        public Func<string, object> InjectValue { get; set; }

        /// <summary>
        /// Method called for every InjectBuilder of initializer
        /// </summary>
        public Action<IInjectBuilder<Initializer>> OnInitialization { get; set; }


        #region folders

        /// <summary>
        /// Return the list configuration folders.
        /// </summary>
        public IEnumerable<string> GetFolderKeys => _datasConfigs.Keys;

        /// <summary>
        /// Add a folder to use for a context use by specified key
        /// </summary>
        /// <param name="folderKey">folder context key</param>
        /// <param name="folder">folder path</param>
        public void AddFolder(string folderKey, string folder)
        {
            if (!_datasConfigs.TryGetValue(folderKey, out HashSet<string> list))
                _datasConfigs.Add(folderKey, list = new HashSet<string>());
            list.Add(folder);
        }

        /// <summary>
        /// try to get the list of folder for the specified value.
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value for the key</param>
        /// <returns></returns>
        public bool TryGetFolders(string key, out IEnumerable<string> value)
        {
            value = default;
            if (_datasConfigs.TryGetValue(key, out var value1))
                value = value1;
            return value != null;

        }

        #endregion folders


        #region variables

        /// <summary>
        /// Return the list of stored keys
        /// </summary>
        public IEnumerable<string> GetKeys => _datas.Keys;

        /// <summary>
        /// Add or replace value to use for initialization
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value for the key</param>
        public void AddOrReplace(string key, object value)
        {
            if (_datas.ContainsKey(key))
                _datas[key] = value;
            else
                _datas.Add(key, value);
        }

        /// <summary>
        /// try to get the value for the specified value.
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value for the key</param>
        /// <returns></returns>
        public bool TryGetValue(string key, out object value)
        {
            return _datas.TryGetValue(key, out value);
        }

        #endregion variables


        #region private

        private void Initialize(Action<InjectionLoader<Initializer>> initializer)
        {

            this.Configure(_serviceProvider, Context, init =>
            {

                init.WithArguments(_args)
                    
                    .WithInjectRescue(InjectRescue)
                    .WithInjectValue(InjectValue)
                    ;

                initializer?.Invoke(init);

            }, OnInitialization)
            ;

        }

        private LocalServiceProvider _serviceProvider = new LocalServiceProvider() { AutoAdd = true };
        private Dictionary<string, object> _datas;
        private Dictionary<string, HashSet<string>> _datasConfigs;
        private readonly string[] _args;

        #endregion private


    }

}
