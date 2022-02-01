using Bb.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bb.ComponentModel.Translations
{
    public static class TranslatedKeyLabelExtension
    {

        public static IEnumerable<TranslatedKeyLabel> GetFrom(this MemberInfo info)
        {

            var items = info.GetCustomAttributes<TranslationKeyAttribute>()
                .ToList();

            foreach (TranslationKeyAttribute attribute in items)
                yield return (TranslatedKeyLabel)attribute.Key;

        }

        public static bool IsValidKey(this string self)
        {

            return TranslatedKeyLabel.Parse(self) != null;

        }

        public static bool IsValidKey(this string self, out TranslatedKeyLabel key)
        {
            key = TranslatedKeyLabel.Parse(self);
            return key != null;
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



