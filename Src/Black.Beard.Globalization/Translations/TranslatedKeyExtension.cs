using Bb.ComponentModel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bb.Translations
{

    /// <summary>
    /// Provides extension methods for working with <see cref="TranslationKey"/> and related operations.
    /// </summary>
    public static class TranslatedKeyExtension
    {

        /// <summary>
        /// Splits a path string into an array of segments, removing spaces and empty entries.
        /// </summary>
        /// <param name="path">The path string to split.</param>
        /// <returns>An array of path segments.</returns>
        /// <example>
        /// <code lang="C#">
        /// string[] segments = TranslatedKeyLabelExtension.SplitPath("path.to.key");
        /// </code>
        /// </example>
        public static string[] SplitPath(string path)
        {
            if (path != null)
                return path.Replace(" ", "").Split('.', StringSplitOptions.RemoveEmptyEntries);
            return new string[0];
        }

        /// <summary>
        /// Concatenates an array of path segments into a single path string.
        /// </summary>
        /// <param name="path">The array of path segments to concatenate.</param>
        /// <returns>A concatenated path string.</returns>
        /// <example>
        /// <code lang="C#">
        /// string path = TranslatedKeyLabelExtension.ConcatPath(new[] { "path", "to", "key" });
        /// </code>
        /// </example>
        public static string ConcatenateTranslationPath(string[] path)
        {
            if (path != null && path.Length > 0)
                return String.Join(".", path).Replace(" ", "");
            return String.Empty;

        }

        /// <summary>
        /// Creates a copy of the specified path array.
        /// </summary>
        /// <param name="path">The array of path segments to clone.</param>
        /// <returns>A new array containing the same path segments.</returns>
        /// <example>
        /// <code lang="C#">
        /// string[] clonedPath = TranslatedKeyLabelExtension.ClonePath(new[] { "path", "to", "key" });
        /// </code>
        /// </example>
        public static string[] ClonePath(string[] path)
        {
            return path?.ToArray() ?? new string[0];
        }

        /// <summary>
        /// Retrieves the translations of the key from a member that contains <see cref="TranslationKeyAttribute"/>.
        /// </summary>
        /// <param name="info">The member information to retrieve translations from.</param>
        /// <returns>An enumerable collection of <see cref="TranslationKey"/> objects.</returns>
        /// <example>
        /// <code lang="C#">
        /// var translations = typeof(MyClass).GetProperty("MyProperty").GetFrom();
        /// </code>
        /// </example>
        public static IEnumerable<TranslationKey> GetFrom(this MemberInfo info)
        {

            var items = info.GetCustomAttributes<TranslationKeyAttribute>()
                .ToList();

            foreach (TranslationKeyAttribute attribute in items)
                yield return attribute.GetTranslation();

        }

        /// <summary>
        /// Determines whether the specified string is a valid translation key.
        /// </summary>
        /// <param name="self">The string to validate.</param>
        /// <returns><c>true</c> if the string is a valid translation key; otherwise, <c>false</c>.</returns>
        /// <example>
        /// <code lang="C#">
        /// bool isValid = "path.to.key".IsValidTranslationKey();
        /// </code>
        /// </example>
        public static bool IsValidTranslationKey(this string self)
        {
            return TranslationKey.IsValid(self);
        }

        /// <summary>
        /// Attempts to convert the specified string into a <see cref="TranslationKey"/>.
        /// </summary>
        /// <param name="self">The string to convert.</param>
        /// <param name="key">When this method returns, contains the converted <see cref="TranslationKey"/> if the conversion succeeded; otherwise, <c>null</c>.</param>
        /// <returns><c>true</c> if the conversion succeeded; otherwise, <c>false</c>.</returns>
        /// <example>
        /// <code lang="C#">
        /// if ("path.to.key".TryConvertInTranslationKey(out var key))
        /// {
        ///     Console.WriteLine(key);
        /// }
        /// </code>
        /// </example>
        public static bool TryConvertInTranslationKey(this string self, out TranslationKey key)
        {
            return TranslationKey.TryConvert(self, out key);
        }

        /// <summary>
        /// Retrieves the first valid translation key from the specified string and additional keys.
        /// </summary>
        /// <param name="self">The primary string to parse.</param>
        /// <param name="self2">Additional strings to parse.</param>
        /// <returns>The first valid <see cref="TranslationKey"/> found, or <see cref="TranslationKey.EmptyKey"/> if none are valid.</returns>
        /// <example>
        /// <code lang="C#">
        /// var key = "invalid.key".GetTranslation("path.to.key");
        /// </code>
        /// </example>
        public static TranslationKey GetTranslation(this string self, params string[] self2)
        {

            var results = new List<TranslationKey>();
            var result = TranslationKey.Parse(self);

            if (result != null)
            {
                if (!result.IsNotValidKey)
                    return result;
                results.Add(result);
            }

            foreach (var item in self2)
            {
                result = TranslationKey.Parse(item);
                if (result != null)
                {
                    if (!result.IsNotValidKey)
                        return result;
                    results.Add(result);
                }
            }

            var i = results.FirstOrDefault(c => !c.IsNotValidKey);
            if (i != null)
                return i;

            i = results.FirstOrDefault(c => c.IsNotValidKey);
            if (i != null)
                return i;

            return TranslationKey.EmptyKey;

        }

        /// <summary>
        /// Retrieves the translation key from the specified string.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static TranslationKey ToTranslation(this string self)
        {
            return TranslationKey.Parse(self);
        }


    }

}



