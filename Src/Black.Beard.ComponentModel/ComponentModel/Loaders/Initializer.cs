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

        /// <summary>
        /// Discover all initializer and execute them for initializing the application
        /// </summary>
        /// <param name="args">arguments to push in the initialization process</param>
        /// <returns></returns>
        public static Initializer Initialize(params string[] args)
        {
            return Initialize(null, args);
        }

        /// <summary>
        /// Discover all initializer and execute them for initializing the application
        /// </summary>
        /// <param name="init">method to configure the process of initialization</param>
        /// <param name="args">arguments to push in the initialization process</param>
        /// <returns></returns>
        public static Initializer Initialize(Action<Initializer> init, params string[] args)
        {
            return Initialize(init, null, null, args);
        }

        /// <summary>0.
        /// 
        /// Discover all initializer and execute them for initializing the application
        /// </summary>
        /// <param name="args">arguments to push in the initialization process</param>
        /// <param name="init">method to configure the process of initialization. the parameter can be null</param>
        /// <param name="initializer">method to configure every InjectionLoader. the parameter can be null</param>
        /// <param name="onInitialization">method to configure every InjectionLoader. the parameter can be null</param>
        public static Initializer Initialize(Action<Initializer> init, Action<InjectionLoader<Initializer>> initializer, Action<IInjectBuilder<Initializer>> onInitialization, params string[] args)
        {
            Initializer i = new Initializer(args);
            init?.Invoke(i);
            return i.Configure(i._serviceProvider, i.Context, c =>
            {
                
                c.WithArguments(i._args);
                
                if (initializer != null)
                    initializer(c);

            }, onInitialization);
        }

        /// <summary>
        /// initialize the initializer
        /// </summary>
        /// <param name="args"></param>
        public Initializer(params string[] args)
        {
            _args = args ?? Environment.GetCommandLineArgs();
            _datas = new Dictionary<string, object>();
            _folders = new Dictionary<string, HashSet<string>>();
        }

        /// <summary>
        /// The context of the initialization
        /// </summary>
        public string Context { get; set; } = ConstantsCore.Initialization;


        #region IServiceProvider

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
        /// Get asked service
        /// </summary>
        /// <param name="serviceType">type of the value to reach</param>
        /// <returns>return the service</returns>
        public object GetService(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }

        #endregion IServiceProvider


        #region folders

        /// <summary>
        /// Return the list configuration folders.
        /// </summary>
        public IEnumerable<string> GetFolderKeys => _folders.Keys;

        /// <summary>
        /// Add a folder to use for a context use by specified key
        /// </summary>
        /// <param name="folderKey">folder context key</param>
        /// <param name="folder">folder path</param>
        public void AddFolder(string folderKey, string folder)
        {
            if (!_folders.TryGetValue(folderKey, out HashSet<string> list))
                _folders.Add(folderKey, list = new HashSet<string>());
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
            if (_folders.TryGetValue(key, out var value1))
                value = value1;
            return value != null;

        }

        /// <summary>
        /// Return true if the folder is already referenced
        /// </summary>
        /// <param name="folderKey">folder context key</param>
        /// <param name="folder">folder path</param>
        /// <returns></returns>
        public bool ContainsFolder(string folderKey, string folder)
        {
            if (_folders.TryGetValue(folderKey, out HashSet<string> list))
                return list.Contains(folder);
            return false;
        }

        /// <summary>
        /// Return true if the folder is already referenced
        /// </summary>
        /// <param name="folder">folder path</param>
        /// <returns></returns>
        public bool ContainsFolder(string folder)
        {
            foreach (var folderKey in _folders.Keys)
                if (_folders[folderKey].Contains(folder))
                    return true;
            return false;
        }

        /// <summary>
        /// remove a folder to use for a context use by specified key
        /// </summary>
        /// <param name="folderKey">folder context key</param>
        /// <param name="folder">folder path</param>
        public void DelFolder(string folderKey, string folder)
        {
            var l = new List<string>();

            if (_folders.TryGetValue(folderKey, out HashSet<string> list))
            {

                if (list.Contains(folder))
                    list.Remove(folder);

                if (list.Count == 0)
                    l.Add(folderKey);

            }

            foreach (var item in l)
                _folders.Remove(item);

        }

        /// <summary>
        /// remove a folder to use for a context use by specified key
        /// </summary>
        /// <param name="folder">folder path</param>
        public void DelFolder(string folder)
        {

            var l = new List<string>();

            foreach (var folderKey in _folders.Keys)
            {

                var list = _folders[folderKey];
                if (list.Contains(folder))
                    list.Remove(folder);

                if (list.Count == 0)
                    l.Add(folderKey);

            }

            foreach (var item in l)
                _folders.Remove(item);
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

        /// <summary>
        /// Return true if the key is referenced
        /// </summary>
        /// <param name="key">key to evaluate</param>
        /// <returns></returns>
        public bool ContainsKey(string key)
        {
            return _datas.ContainsKey(key);
        }


        /// <summary>
        /// Return true if the key is deleted or false if the key was not found
        /// </summary>
        /// <param name="key">key to remove</param>
        /// <returns></returns>
        public bool RemoveKey(string key)
        {
            if (_datas.ContainsKey(key))
            {
                _datas.Remove(key);
                return true;
            }

            return false;
        }


        #endregion variables


        #region private


        private LocalServiceProvider _serviceProvider = new LocalServiceProvider() { AutoAdd = true };
        private Dictionary<string, object> _datas;
        private Dictionary<string, HashSet<string>> _folders;
        private readonly string[] _args;

        #endregion private


    }

}
