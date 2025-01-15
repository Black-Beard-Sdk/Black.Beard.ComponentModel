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


    }


}
