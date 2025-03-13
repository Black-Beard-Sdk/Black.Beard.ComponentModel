using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Bb.ComponentModel
{

    [DebuggerDisplay("{FullName}")]
    /// <summary>
    /// Type matched
    /// </summary>
    public class TypeMatched : AssemblyMatched
    {

        public TypeMatched()
        {

        }

        /// <summary>
        /// Gets the full name of the type.
        /// </summary>
        /// <value>
        /// The full name type.
        /// </value>
        public string FullName { get; internal set; }

        /// <summary>
        /// Gets the type namespace of the type.
        /// </summary>
        /// <value>
        /// The type namespace of the type.
        /// </value>
        public string TypeNamespace { get; internal set; }

        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        /// <value>
        /// The name of the type.
        /// </value>
        public string TypeName { get; internal set; }

        /// <summary>
        /// Gets the <see cref="System.Type"/>. Call the method Load for load the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public Type Type { get; private set; }

        /// <summary>
        /// Gets the full name of the declaring type when the type is a nested type.
        /// </summary>
        /// <value>
        /// The full name of the declaring type.
        /// </value>
        public string DeclaringTypeFullName { get; internal set; }

        /// <summary>
        /// Gets the generic parameters if the type expect arguments.
        /// </summary>
        /// <value>
        /// The generic parameters.
        /// </value>
        public List<GenericTypeMatched> GenericParameters { get; internal set; }

        /// <summary>
        /// Try to load the assembly.
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
        public override bool Load(bool failedOnloadError = true)
        {

            var result = base.Load(failedOnloadError);
            if (Assembly != null)
            {

                var name = this.FullName;

                if (!string.IsNullOrEmpty(this.DeclaringTypeFullName))
                    name = this.DeclaringTypeFullName + "+" + name.Substring(this.DeclaringTypeFullName.Length + 1);

                this.Type = Assembly.GetType(name, failedOnloadError, false);
                result = this.Type != null;
            }

            return result;

        }

        private bool? _isLoaded;

    }


    public class GenericTypeMatched
    {

        /// <summary>
        /// Gets the index of generic type
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        public int Index { get; internal set; }

        /// <summary>
        /// Gets the name of the generic type.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether this instance has default constructor constraint. (no argument)
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has default constructor constraint; otherwise, <c>false</c>.
        /// </value>
        public bool HasDefaultConstructorConstraint { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the generic type must be a value type.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has value type constraint; otherwise, <c>false</c>.
        /// </value>
        public bool HasValueTypeConstraint { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the generic type must be a class
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has reference type constraint; otherwise, <c>false</c>.
        /// </value>
        public bool HasReferenceTypeConstraint { get; internal set; }

        /// <summary>
        /// Gets the constraints type list.
        /// </summary>
        /// <value>
        /// The constraints.
        /// </value>
        public List<string> Constraints { get; internal set; }

    }


}



