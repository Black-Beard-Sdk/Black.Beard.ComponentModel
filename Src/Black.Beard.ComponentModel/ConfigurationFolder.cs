using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
        /// <param name="folder">The path of the directory to add.</param>
        public static void AddDirectory(string folder)
        {
            AddDirectory(new DirectoryInfo(folder));
        }

        /// <summary>
        /// Adds the specified directory to the collection.
        /// </summary>
        /// <param name="folder">The directory to add.</param>
        public static void AddDirectory(DirectoryInfo folder)
        {
            Instance.Add(folder);
        }

        /// <summary>
        /// Gets an array of paths for all the directories in the collection.
        /// </summary>
        /// <returns>An array of paths for all the directories in the collection.</returns>
        internal static string[] GetPaths()
        {

            List<string> result = new List<string>();

            foreach (var item in Instance)
                result.Add(item.FullName);

            return result.ToArray();
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
        public static ConfigurationFolder Instance
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
                        {
                            _instance = new StartingConfiguration();                            
                        }
                return _instance;
            }
        }

        public StartingConfiguration Set(string key, object value)
        {
            if (_settings.ContainsKey(key))
                _settings[key] = value;
            else
                _settings.Add(key, value);
            return this;
        }

        public T Get<T>(string key)
        {
            if (_settings.ContainsKey(key))
                return (T)_settings[key];
            return default;
        }


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

        public void LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"The configuration file '{filePath}' was not found.");
            SetFromContent(filePath);
        }

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
