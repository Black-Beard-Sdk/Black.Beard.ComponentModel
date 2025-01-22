using System;
using System.IO;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using ICSharpCode.Decompiler.CSharp;
using ICSharpCode.Decompiler.Metadata;
using ICSharpCode.Decompiler.TypeSystem;

namespace ICSharpCode.Decompiler
{
    public static class DecompilerHelpers
    {


        public static DecompilerTypeSystem CreateTypeSystem(this PEFile file, DecompilerSettings settings, out UniversalAssemblyResolver resolver, out CSharpDecompiler decompiler)
        {

            var targetFrameworkId = file.DetectTargetFrameworkId();
            settings.LoadInMemory = true;
            resolver = new UniversalAssemblyResolver(file.FileName, settings.ThrowOnAssemblyResolveErrors,
                targetFrameworkId,
                settings.LoadInMemory ? PEStreamOptions.PrefetchMetadata : PEStreamOptions.Default,
                settings.ApplyWindowsRuntimeProjections ? MetadataReaderOptions.ApplyWindowsRuntimeProjections : MetadataReaderOptions.None);


            var v1 = new Version(targetFrameworkId.Split('=')[1].Substring(1));

            var l = new FileInfo(typeof(int).Assembly.Location).Directory;
            var v2 = new Version(l.Name);
            if (v1.Major == v2.Major)
            {
                resolver.AddSearchDirectory(l.FullName);
            }

            var typeSystem = new DecompilerTypeSystem(file, resolver);
            decompiler = new CSharpDecompiler(typeSystem, settings);

            return typeSystem;
        }

        //static PEFile LoadPEFile(string fileName, DecompilerSettings settings)
        //{
        //    settings.LoadInMemory = true;
        //    return new PEFile(
        //        fileName,
        //        new FileStream(fileName, FileMode.Open, FileAccess.Read),
        //        streamOptions: settings.LoadInMemory ? PEStreamOptions.PrefetchEntireImage : PEStreamOptions.Default,
        //        metadataOptions: settings.ApplyWindowsRuntimeProjections ? MetadataReaderOptions.ApplyWindowsRuntimeProjections : MetadataReaderOptions.None
        //    );
        //}

    }
}
