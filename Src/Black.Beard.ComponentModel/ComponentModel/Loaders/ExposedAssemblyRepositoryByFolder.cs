using System.IO;

namespace Bb.ComponentModel.Loaders
{


    /// <summary>
    /// Load assemblies from a folder
    /// </summary>
    public class ExposedAssemblyRepositoryByFolder : ExposedAssemblyRepositoryByName
    {

        public ExposedAssemblyRepositoryByFolder()
        {

        }

        /// <summary>
        /// Folder path for loading assemblies
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Load assemblies recursively
        /// </summary>
        public bool Recursively { get; set; }

        /// <summary>
        /// Filter for loading assemblies
        /// </summary>
        public string FileFilter { get; set; }


        internal override void Load()
        {

            var p = new DirectoryInfo(Path);
            
            SearchOption optionSearch = Recursively 
                ? SearchOption.AllDirectories 
                : SearchOption.TopDirectoryOnly;

            if (string.IsNullOrEmpty(FileFilter))
                FileFilter = "*.dll";

            FileInfo[] list = p.GetFiles(FileFilter, optionSearch);

            foreach (var f in list)
                AssemblyLoader.Instance.LoadAssembly(f);

        }

    }


}
