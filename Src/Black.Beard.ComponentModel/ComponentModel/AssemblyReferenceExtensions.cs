﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using ICSharpCode.Decompiler.Metadata;

namespace Bb.ComponentModel
{
    public static class AssemblyReferenceExtensions
    {

        /// <summary>
        /// Try to load the assemblies.
        /// </summary>
        /// <param name="failedOnloadError">if set to <c>true</c> [failed onload error].</param>
        /// <exception cref="System.ArgumentException">name is invalid. -or- The length of name exceeds 1024 characters</exception>
        /// <exception cref="System.TypeLoadException">throwOnError is true, and the type cannot be found</exception>
        /// <exception cref="System.IO.FileNotFoundException">name requires a dependent assembly that could not be found.</exception>
        /// <exception cref="System.IO.FileLoadException">
        ///     name requires a dependent assembly that was found but could not be loaded. -or-
        ///     The current assembly was loaded into the reflection-only context, and name requires
        ///     a dependent assembly that was not preloaded.
        ///</exception>
        /// <exception cref="System.BadImageFormatException">
        ///     name requires a dependent assembly, but the file is not a valid assembly. -or-
        ///     name requires a dependent assembly which was compiled for a version of the runtime
        ///     later than the currently loaded version.
        /// </exception>
        /// <returns>return false if item are fail to loading</returns>
        public static bool LoadAssemblies(this IEnumerable<AssemblyMatched> self, bool failedOnloadError = true)
        {

            bool result = true;
            foreach (var item in self)
            {

                var p = item.Load(failedOnloadError);
                if (item.FailedToLoad)
                    result = false;
            }

          return result;

        }

        /// <summary>
        /// Load all assemblies if not loaded and return the list of assembly failed to loaded
        /// </summary>
        /// <param name="self">list of assembly to load</param>
        /// <returns>list of assembly not loaded</returns>
        public static IEnumerable<PEFile> LoadAssemblies(this IEnumerable<PEFile> self)
        {

            List<PEFile> _result = new List<PEFile>();

            foreach (var item in self)
            {

                var file = new FileInfo(item.FullName);
                var isLoaded = TypeDiscovery.Instance.IsLoaded(file);

                if (!isLoaded)
                    try
                    {
                        AssemblyLoader.Instance.LoadAssembly(file, null);
                    }
                    catch (Exception)
                    {
                        _result.Add(item);
                    }
            }

            return _result;


        }


        /// <summary>
        /// Determines whether the specified file is located in the system directory.
        /// </summary>
        /// <param name="file">The file to check. Must not be null.</param>
        /// <returns><c>true</c> if the file is in the system directory; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the file parameter is null.</exception>
        /// <remarks>
        /// This method checks if the specified file is located in the system directory.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// FileInfo fileInfo = new FileInfo("C:\\Windows\\System32\\example.dll");
        /// bool isInSystemDirectory = fileInfo.InSystemDirectory();
        /// </code>
        /// </example>
        public static bool InSystemDirectory(this FileInfo file)
        {
            return AssemblyDirectoryResolver.IsSystemDirectory(file.Directory);
        }

        /// <summary>
        /// Determines whether the specified file is located in the entry directory.
        /// </summary>
        /// <param name="file">The file to check. Must not be null.</param>
        /// <returns><c>true</c> if the file is in the entry directory; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the file parameter is null.</exception>
        /// <remarks>
        /// This method checks if the specified file is located in the entry directory.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// FileInfo fileInfo = new FileInfo("C:\\Windows\\System32\\example.dll");
        /// bool isInSystemDirectory = fileInfo.InEntryDirectory();
        /// </code>
        /// </example>
        public static bool InEntryDirectory(this FileInfo file)
        {
            return AssemblyDirectoryResolver.IsEntryDirectory(file.Directory);
        }

        /// <summary>
        /// Determines whether the specified assembly is an SDK assembly.
        /// </summary>
        /// <param name="file">The assembly to check. Must not be null.</param>
        /// <returns><c>true</c> if the assembly is an SDK assembly; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the file parameter is null.</exception>
        /// <remarks>
        /// This method checks if the specified assembly contains attributes that indicate it is an SDK assembly.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var assembly = new PEFile("path");
        /// bool isSdk = assembly.IsSdk();
        /// </code>
        /// </example>
        public static bool IsSdk(this PEFile file)
        {
            foreach (var item3 in file.Module.GetAssemblyAttributes())
                foreach (var item4 in item3.FixedArguments)
                    if (item4.Value != null && item4.Value.ToString().Contains("Microsoft"))
                        return true;

            return false;

        }

        /// <summary>
        /// Determines whether the specified assembly is an SDK assembly.
        /// </summary>
        /// <param name="file">The assembly to check. Must not be null.</param>
        /// <returns><c>true</c> if the assembly is an SDK assembly; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the file parameter is null.</exception>
        /// <remarks>
        /// This method checks if the specified assembly contains attributes that indicate it is an SDK assembly.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// Assembly assembly = Assembly.Load("SomeAssembly");
        /// bool isSdk = assembly.IsSdk();
        /// </code>
        /// </example>
        public static bool IsSdk(this Assembly file)
        {
            foreach (CustomAttributeData item3 in file.CustomAttributes)
                foreach (var item4 in item3.ConstructorArguments)
                    if (item4.Value != null && item4.Value.ToString().Contains("Microsoft"))
                        return true;

            return false;

        }



        /// <summary>
        /// Return true if the assembly reference contains the assembly name
        /// </summary>
        /// <param name="self"></param>
        /// <param name="failedOnloadError"></param>
        /// <returns></returns>
        public static IEnumerable<AssemblyMatched> EnsureIsLoaded(this IEnumerable<AssemblyMatched> self, bool failedOnloadError = true)
        {

            AssemblyLoader.Instance.EnsureAssemblyIsLoaded(Assembly.GetEntryAssembly(), true, false);

            foreach (var item in self)
                if (!item.AssemblyIsLoaded)
                    item.Load(failedOnloadError);

            return self;

        }

        /// <summary>
        /// Return true if the assembly reference contains the assembly name
        /// </summary>
        /// <param name="entries"><see cref="AssemblyReference">list of assembly reference</param>
        /// <param name="assembly"><see cref="AssemblyName"/> assembly name</param>
        /// <returns></returns>
        public static bool References(this ImmutableArray<AssemblyReference> entries, AssemblyName assembly)
        {
            foreach (var entry in entries)
                if (entry.Matches(assembly).HasFlag(AssemblyComparerFlags.Name))
                    return true;
            return false;
        }

        /// <summary>
        /// return an evaluation of the assembly reference comparison.
        /// </summary>
        /// <param name="entry"><see cref="AssemblyReference">assembly reference</param>
        /// <param name="assembly"><see cref="AssemblyName"/> assembly name</param>
        /// <returns>evaluation result</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static AssemblyComparerFlags Matches(this AssemblyReference entry, AssemblyName assembly)
        {

            if (entry == null)
                throw new ArgumentNullException(nameof(entry));

            if (assembly == null)
                throw new ArgumentNullException(nameof(assembly));

            AssemblyComparerFlags result = AssemblyComparerFlags.NoMatch;

            if (entry?.Name == assembly?.Name)
            {

                result = AssemblyComparerFlags.Name;

                if (assembly.CultureInfo != null && !string.IsNullOrEmpty(entry.Culture))
                {
                    if (CultureInfo.GetCultureInfo(entry.Culture) == assembly.CultureInfo)
                        result |= AssemblyComparerFlags.Culture;
                }
                else
                    result |= AssemblyComparerFlags.Culture;


                if (assembly.Version != null && entry.Version != null)
                {
                    if (entry.Version == assembly.Version)
                        result |= AssemblyComparerFlags.Version;
                }
                else
                    result |= AssemblyComparerFlags.Version;


                var tokenLeft = entry.GetPublicKeyToken();
                var tokenRight = assembly.GetPublicKeyToken();
                if (tokenRight != null && tokenLeft != null)
                {
                    if (entry.GetPublicKeyToken().SequenceEqual(tokenRight))
                        result |= AssemblyComparerFlags.PublicKeyToken;
                }
                else
                    result |= AssemblyComparerFlags.PublicKeyToken;

            }

            return result;

        }


    }


}
