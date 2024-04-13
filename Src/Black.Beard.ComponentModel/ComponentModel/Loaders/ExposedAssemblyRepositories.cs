using System.Collections.Generic;
using System.Reflection;

namespace Bb.ComponentModel.Loaders
{


    public class ExposedAssemblyRepositories
    {

        public ExposedAssemblyRepositories()
        {
            ByFolder = new List<ExposedAssemblyRepositoryByFolder>();
            ByName = new List<ExposedAssemblyRepositoryByName>();
        }

        public List<ExposedAssemblyRepositoryByFolder> ByFolder { get; set; }


        public List<ExposedAssemblyRepositoryByName> ByName { get; set; }


        public void Load()
        {

            AssemblyLoader.Instance.EnsureAssemblyIsLoaded(Assembly.GetEntryAssembly(), true, false);

            foreach (var item in ByFolder)
                item.Load();

            foreach (var item in ByName)
                item.Load();

        }


    }



}
