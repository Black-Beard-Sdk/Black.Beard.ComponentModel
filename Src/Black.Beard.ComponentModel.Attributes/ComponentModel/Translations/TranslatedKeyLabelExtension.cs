using Bb.ComponentModel.Attributes;
using Bb.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Bb.ComponentModel.Translations
{


    public static class TranslatedKeyLabelExtension
    {


        public static string[] SplitPath(string path)
        {
            if (path != null)
                return path.Replace(" ", "").Split('.', StringSplitOptions.RemoveEmptyEntries);
            return new string[0];
        }

        public static string ConcatPath(string[] path)
        {
            if (path != null && path.Length > 0)
                return String.Join(".", path).Replace(" ", "");
            return String.Empty;

        }

        public static string[] ClonePath(string[] path)
        {
            return path?.ToArray() ?? new string[0];
        }


        /// <summary>
        /// Return the translation of the key if the member contains <see cref="TranslationKeyAttribute"/>
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static IEnumerable<TranslatedKeyLabel> GetFrom(this MemberInfo info)
        {

            var items = info.GetCustomAttributes<TranslationKeyAttribute>()
                .ToList();

            foreach (TranslationKeyAttribute attribute in items)
                yield return attribute.GetTranslation();

        }

        /// <summary>
        /// return true if the key is a valid translation key
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsValidTranslationKey(this string self)
        {
            return TranslatedKeyLabel.IsValid(self);
        }

        /// <summary>
        /// return true if the key is a valid translation key
        /// </summary>
        /// <param name="self"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool TryConvertInTranslationKey(this string self, out TranslatedKeyLabel key)
        {
            return TranslatedKeyLabel.TryConvert(self, out key);
        }


        public static TranslatedKeyLabel GetTranslation(this string self, params string[] self2)
        {

            var results = new List<TranslatedKeyLabel>();
            var result = TranslatedKeyLabel.Parse(self);

            if (result != null)
            {
                if (!result.IsNotValidKey)
                    return result;
                results.Add(result);
            }

            foreach (var item in self2)
            {
                result = TranslatedKeyLabel.Parse(item);
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

            return TranslatedKeyLabel.EmptyKey;

        }

    }

}



