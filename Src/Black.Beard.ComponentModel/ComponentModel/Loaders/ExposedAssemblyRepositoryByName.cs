using System.Linq;
using System.Reflection.Metadata;

namespace Bb.ComponentModel.Loaders
{


    /// <summary>
    /// Load assemblies by name
    /// </summary>
    public class ExposedAssemblyRepositoryByName : ExposedAssemblyRepository
    {

        public ExposedAssemblyRepositoryByName()
        {

        }

        /// <summary>
        /// Assembly name to load
        /// </summary>
        public string AssemblyName { get; set; }


        internal override void Load()
        {
            AssemblyLoader.Instance.LoadAssemblyName(AssemblyName);  
        }

    }


}
