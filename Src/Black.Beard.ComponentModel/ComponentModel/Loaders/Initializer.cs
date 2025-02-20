using Bb.ComponentModel.Factories;
using System;
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
        /// <param name="args">arguments to push in the initialization process</param>
        /// <param name="init">method to configure the process of initialization</param>
        public static Initializer Initialize(Action<Initializer> init, params string[] args)
        {

            init ??= (i) => { };

            if (args == null || args.Length == 0)
                args = Environment.GetCommandLineArgs();

            Initializer initializer = Creator(args);

            init(initializer);

            initializer.Initialize();

            return initializer;

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

        public Action<IInjectBuilder<Initializer>> OnInitialization { get; set; }



        #region private

        private void Initialize()
        {

            this.Configure(_serviceProvider, Context, init =>
            {
                init.WithArguments(_args)
                    .WithInjectRescue(InjectRescue)
                    .WithInjectValue(InjectValue)
                    ;
            }, OnInitialization)
            ;

        }

        private LocalServiceProvider _serviceProvider = new LocalServiceProvider() { AutoAdd = true };
        private readonly string[] _args;

        #endregion private


    }

}
