using Bb.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Bb
{


    /// <summary>
    /// Represents a collection of directories used for configuration purposes.
    /// </summary>
    public class ConfigurationFolder : List<DirectoryInfo>
    {
        private ConfigurationFolder()
        {

        }

        /// <summary>
        /// Adds the directory of the calling assembly to the collection.
        /// </summary>
        /// <remarks>
        /// This method retrieves the directory of the assembly that called this method and adds it to the collection.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ConfigurationFolder.AddCallingAssemblyDirectory();
        /// </code>
        /// </example>
        public static void AddCallingAssemblyDirectory()
        {
            AddAssemblyDirectory(Assembly.GetCallingAssembly());
        }

        /// <summary>
        /// Adds the directory of the executing assembly to the collection.
        /// </summary>
        /// <remarks>
        /// This method retrieves the directory of the currently executing assembly and adds it to the collection.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ConfigurationFolder.AddExecutingAssemblyDirectory();
        /// </code>
        /// </example>
        public static void AddExecutingAssemblyDirectory()
        {
            AddAssemblyDirectory(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Adds the directory of the entry assembly to the collection.
        /// </summary>
        /// <remarks>
        /// This method retrieves the directory of the entry assembly (the application entry point) and adds it to the collection.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ConfigurationFolder.AddEntryAssemblyDirectory();
        /// </code>
        /// </example>
        public static void AddEntryAssemblyDirectory()
        {
            AddAssemblyDirectory(Assembly.GetEntryAssembly());
        }

        /// <summary>
        /// Adds the directory of the specified assembly to the collection.
        /// </summary>
        /// <param name="assembly">The assembly whose directory is to be added. Must not be null.</param>
        /// <remarks>
        /// This method retrieves the directory of the specified assembly and adds it to the collection.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the assembly is dynamic or has no location.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// Assembly assembly = Assembly.GetExecutingAssembly();
        /// ConfigurationFolder.AddAssemblyDirectory(assembly);
        /// </code>
        /// </example>
        public static void AddAssemblyDirectory(Assembly assembly)
        {
            if ( (assembly.IsDynamic)
                || (assembly.Location == null)
                || (assembly.Location == string.Empty))
                throw new InvalidOperationException("The assembly is dynamic or has no location.");
            
            AddDirectory(new FileInfo(assembly.Location).Directory);
        }

        /// <summary>
        /// Adds the specified directory to the collection if it exists.
        /// </summary>
        /// <param name="folder">The path of the directory to add.</param>
        /// <remarks>
        /// This method checks if the specified directory exists and adds it to the collection if it does.
        /// </remarks>
        public static void AddDirectoryIfExists(string folder)
        {
            AddDirectoryIfExists(new DirectoryInfo(folder));
        }

        /// <summary>
        /// Adds the specified directory to the collection if it exists.
        /// </summary>
        /// <param name="folder">The directory to add.</param>
        /// <remarks>
        /// This method checks if the specified directory exists and adds it to the collection if it does.
        /// </remarks>
        public static void AddDirectoryIfExists(DirectoryInfo folder)
        {
            folder.Refresh();
            if (folder.Exists)
                Instance.Add(folder);
        }

        /// <summary>
        /// Adds the specified directory to the collection.
        /// </summary>
        /// <param name="folder">The path of the directory to add. Must not be null or empty.</param>
        /// <remarks>
        /// This method adds a directory to the collection without checking if it exists.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ConfigurationFolder.AddDirectory("C:\\MyConfigs");
        /// </code>
        /// </example>
        public static void AddDirectory(string folder)
        {
            AddDirectory(new DirectoryInfo(folder));
        }

        /// <summary>
        /// Adds the specified directory to the collection.
        /// </summary>
        /// <param name="folder">The directory to add. Must not be null.</param>
        /// <remarks>
        /// This method adds a directory to the collection without checking if it exists.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var directory = new DirectoryInfo("C:\\MyConfigs");
        /// ConfigurationFolder.AddDirectory(directory);
        /// </code>
        /// </example>
        public static void AddDirectory(DirectoryInfo folder)
        {
            Instance.Add(folder);
        }

        /// <summary>
        /// Gets an array of paths for all the directories in the collection.
        /// </summary>
        /// <returns>
        /// An array of paths for all the directories in the collection.
        /// </returns>
        /// <remarks>
        /// This method retrieves the full paths of all directories currently in the collection.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// string[] paths = ConfigurationFolder.GetPaths();
        /// foreach (var path in paths)
        /// {
        ///     Console.WriteLine(path);
        /// }
        /// </code>
        /// </example>
        internal static string[] GetPaths()
        {
            List<string> result = new List<string>();

            foreach (var item in Instance)
                result.Add(item.FullName);

            return result.ToArray();
        }

        /// <summary>
        /// Retrieves all files matching the specified search pattern from the directories in the collection.
        /// </summary>
        /// <param name="searchPattern">The search pattern to match file names (e.g., "*.txt"). Must not be null or empty.</param>
        /// <returns>
        /// A collection of <see cref="FileInfo"/> objects representing the matching files.
        /// </returns>
        /// <remarks>
        /// This method searches all directories in the collection for files matching the specified search pattern.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// IEnumerable&lt;FileInfo&gt; files = ConfigurationFolder.Instance.GetFiles("*.config");
        /// foreach (var file in files)
        /// {
        ///     Console.WriteLine(file.FullName);
        /// }
        /// </code>
        /// </example>
        public IEnumerable<FileInfo> GetFiles(string searchPattern)
        {
            List<FileInfo> result = new List<FileInfo>();
            foreach (var item in Instance)
                result.AddRange(item.GetFiles(searchPattern));
            return result;
        }

        /// <summary>
        /// Gets the singleton instance of the ConfigurationFolder class.
        /// </summary>
        /// <value>
        /// The singleton instance of the ConfigurationFolder class.
        /// </value>
        /// <remarks>
        /// This property ensures that only one instance of the ConfigurationFolder class is created and used throughout the application.
        /// </remarks>
        internal static ConfigurationFolder Instance
        {
            get
            {
                if (_instance == null)
                    lock (_lock)
                        if (_instance == null)
                        {
                            _instance = new ConfigurationFolder();
                            AddDirectoryIfExists(Path.Combine(AppContext.BaseDirectory, "Configs"));
                        }
                return _instance;
            }
        }

        private static ConfigurationFolder _instance;
        private static object _lock = new object();

    }


    public class StartingConfiguration
    {

        public StartingConfiguration()
        {
            _settings = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets the singleton instance of the ConfigurationFolder class.
        /// </summary>
        /// <value>
        /// The singleton instance of the ConfigurationFolder class.
        /// </value>
        /// <remarks>
        /// This property ensures that only one instance of the ConfigurationFolder class is created and used throughout the application.
        /// </remarks>
        public static StartingConfiguration Instance
        {
            get
            {
                if (_instance == null)
                    lock (_lock)
                        if (_instance == null)
                            _instance = new StartingConfiguration();                            
                return _instance;
            }
        }

        /// <summary>
        /// Sets a configuration value for the specified key.
        /// </summary>
        /// <param name="key">The key of the configuration setting. Must not be null or empty.</param>
        /// <param name="value">The value to associate with the key. Can be null.</param>
        /// <returns>
        /// The current <see cref="StartingConfiguration"/> instance for method chaining.
        /// </returns>
        /// <remarks>
        /// This method adds or updates a configuration setting in the internal dictionary.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// StartingConfiguration.Instance.Set("AppName", "MyApplication");
        /// </code>
        /// </example>
        public StartingConfiguration Set(string key, object value)
        {
            if (_settings.ContainsKey(key))
                _settings[key] = value;
            else
                _settings.Add(key, value);
            return this;
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <typeparam name="T">The type of the value to retrieve.</typeparam>
        /// <param name="key">The key of the configuration setting. Must not be null or empty.</param>
        /// <returns>
        /// The value associated with the specified key, or the default value of <typeparamref name="T"/> if the key does not exist.
        /// </returns>
        /// <remarks>
        /// This method retrieves a configuration value and casts it to the specified type.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// string appName = StartingConfiguration.Instance.Get&lt;string&gt;("AppName");
        /// Console.WriteLine(appName);
        /// </code>
        /// </example>
        public T Get<T>(string key)
        {
            if (_settings.TryGetValue(key, out object value))
                return (T)value.ConvertTo<T>();
            return default;
        }

        /// <summary>
        /// Gets a formatted string of all configuration key-value pairs.
        /// </summary>
        /// <returns>
        /// A formatted string containing all configuration key-value pairs.
        /// </returns>
        /// <remarks>
        /// This method formats the configuration settings into a human-readable string.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// string configValues = StartingConfiguration.Instance.GetValues();
        /// Console.WriteLine(configValues);
        /// </code>
        /// </example>
        public string GetValues()
        {
            int maxKeyLength = _settings.Keys.Max(key => key.Length) + 1;
            List<string> result = new List<string>();
            foreach (var item in _settings)
            {
                string formattedKey = item.Key.PadRight(maxKeyLength);
                result.Add($"{formattedKey}= {item.Value}");
            }
        
            return string.Join(Environment.NewLine, result);

        }

        /// <summary>
        /// Loads configuration settings from a file.
        /// </summary>
        /// <param name="filePath">The path to the configuration file. Must not be null or empty.</param>
        /// <remarks>
        /// This method reads key-value pairs from a file and adds them to the configuration.
        /// </remarks>
        /// <exception cref="FileNotFoundException">
        /// Thrown if the specified file does not exist.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// StartingConfiguration.Instance.LoadFromFile("config.txt");
        /// </code>
        /// </example>
        public void LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"The configuration file '{filePath}' was not found.");
            SetFromContent(filePath);
        }

        /// <summary>
        /// Parses and sets configuration settings from the content of a file.
        /// </summary>
        /// <param name="filePath">The path to the configuration file. Must not be null or empty.</param>
        /// <remarks>
        /// This method reads the content of a file and parses it into key-value pairs.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// StartingConfiguration.Instance.SetFromContent("config.txt");
        /// </code>
        /// </example>
        public void SetFromContent(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(new[] { '=' }, 2);
                if (parts.Length == 2)
                {
                    var key = parts[0].Trim();
                    var value = parts[1].Trim();
                    _settings[key] = value;
                }
            }
        }

        public static ConfigurationFolder Folders => ConfigurationFolder.Instance;

        private static StartingConfiguration _instance;
        private static object _lock = new object();
        private Dictionary<string, object> _settings;

    }

}
