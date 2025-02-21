using System;
using System.Collections.Generic;
using System.IO;

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
        public static string[] GetPaths()
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

}
