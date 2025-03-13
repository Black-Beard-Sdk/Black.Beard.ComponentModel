using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace Bb.ComponentModel
{


    /// <summary>
    /// Provides methods to compare file and directory paths.
    /// </summary>
    internal static class PathHelper
    {

        /// <summary>
        /// Initializes the <see cref="PathHelper"/> class.
        /// </summary>
        static PathHelper()
        {
            _pathComparer = new PathComparer();
        }

        /// <summary>
        /// Determines whether the specified directory paths are equal.
        /// </summary>
        /// <param name="path1">The first directory path.</param>
        /// <param name="path2">The second directory path.</param>
        /// <returns><see langword="true"/> if the specified paths are equal; otherwise, <see langword="false"/>.</returns>
        /// <remarks>
        /// This method compares the full names of the directories in a case-insensitive manner.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var dir1 = new DirectoryInfo("C:\\Path1");
        /// var dir2 = new DirectoryInfo("C:\\path1");
        /// bool areEqual = dir1.IsPathEquals(dir2);
        /// </code>
        /// </example>
        public static bool IsPathEquals(this DirectoryInfo path1, DirectoryInfo path2)
        {
            return _pathComparer.Equals(path1.FullName, path2.FullName);
        }

        /// <summary>
        /// Determines whether the specified file paths are equal.
        /// </summary>
        /// <param name="path1">The first file path.</param>
        /// <param name="path2">The second file path.</param>
        /// <returns><see langword="true"/> if the specified paths are equal; otherwise, <see langword="false"/>.</returns>
        /// <remarks>
        /// This method compares the full names of the files in a case-insensitive manner.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var file1 = new FileInfo("C:\\Path1\\file.txt");
        /// var file2 = new FileInfo("C:\\path1\\FILE.TXT");
        /// bool areEqual = file1.IsPathEquals(file2);
        /// </code>
        /// </example>
        public static bool IsPathEquals(this FileInfo path1, FileInfo path2)
        {
            return _pathComparer.Equals(path1.FullName, path2.FullName);
        }

        /// <summary>
        /// Determines whether the specified string paths are equal.
        /// </summary>
        /// <param name="path1">The first string path.</param>
        /// <param name="path2">The second string path.</param>
        /// <returns><see langword="true"/> if the specified paths are equal; otherwise, <see langword="false"/>.</returns>
        /// <remarks>
        /// This method compares the formatted paths in a case-insensitive manner.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// string path1 = "C:\\Path1";
        /// string path2 = "C:\\path1";
        /// bool areEqual = path1.IsPathEquals(path2);
        /// </code>
        /// </example>
        public static bool IsPathEquals(this string path1, string path2)
        {
            return _pathComparer.Equals(path1.FormatPath(), path2.FormatPath());
        }

        /// <summary>
        /// Formats the specified path to a standard format.
        /// </summary>
        /// <param name="path">The path to format.</param>
        /// <returns>The formatted path.</returns>
        /// <remarks>
        /// This method converts the path to a lower-case invariant string and removes URI encoding.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// string path = "file:///C:/Path1";
        /// string formattedPath = path.FormatPath();
        /// </code>
        /// </example>
        public static string FormatPath(this string path)
        {
            if (path.StartsWith("file:///"))
                path = new Uri(path).LocalPath;

            path = Uri.UnescapeDataString(path);

            path = Path.GetFullPath(path).TrimEnd(Path.DirectorySeparatorChar);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                path = path.ToLowerInvariant();

            return path;

        }

        private static readonly PathComparer _pathComparer;
         
    }

    /// <summary>
    /// Compares file and directory paths for equality.
    /// </summary>
    internal class PathComparer : IEqualityComparer<string>
    {

        /// <summary>
        /// Determines whether the specified paths are equal.
        /// </summary>
        /// <param name="x">The first path.</param>
        /// <param name="y">The second path.</param>
        /// <returns><see langword="true"/> if the specified paths are equal; otherwise, <see langword="false"/>.</returns>
        /// <remarks>
        /// This method compares the full paths in a case-insensitive manner.
        /// </remarks>
        public bool Equals(string x, string y)
        {
            if (x == null || y == null)
                return false;

            var x1 = Path.GetFullPath(x).TrimEnd(Path.DirectorySeparatorChar);
            var y1 = Path.GetFullPath(y).TrimEnd(Path.DirectorySeparatorChar);

            StringComparison comparison = 
                RuntimeInformation.IsOSPlatform(OSPlatform.Windows) 
                ? StringComparison.OrdinalIgnoreCase
                : StringComparison.Ordinal
                ;

            var result = string.Equals(x1, y1, comparison);

            return result;
        }

        /// <summary>
        /// Returns a hash code for the specified path.
        /// </summary>
        /// <param name="obj">The path.</param>
        /// <returns>A hash code for the specified path.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the path is null.</exception>
        /// <remarks>
        /// This method returns a hash code for the full path in a case-insensitive manner.
        /// </remarks>
        public int GetHashCode(string obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            return Path.GetFullPath(obj)
                .TrimEnd(Path.DirectorySeparatorChar)
                .ToLowerInvariant()
                .GetHashCode();
        }

    }


}
