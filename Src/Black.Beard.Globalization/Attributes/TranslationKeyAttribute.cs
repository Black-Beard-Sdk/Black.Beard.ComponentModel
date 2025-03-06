using Bb.Translations;
using System;

namespace Bb.ComponentModel.Attributes
{


    [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class TranslationKeyAttribute : Attribute
    {

        /// <summary>
        /// Constructor that create a new <see cref="TranslationKeyAttribute"/>
        /// </summary>
        /// <param name="translationKey"></param>
        public TranslationKeyAttribute(string translationKey)
        {
            this.Key = translationKey;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context">Context of translation</param>
        /// <param name="translationKey"></param>
        public TranslationKeyAttribute(string  context, string translationKey) 
            : this(translationKey)
        {
            this.Context = context;
        }

        /// <summary>
        /// Translation key
        /// </summary>
        public string Key { get; }

        public TranslatedKeyLabel GetTranslation() => TranslatedKeyLabel.Parse(this.Key);


        /// <summary>
        /// Context of translation
        /// </summary>
        public string Context { get; }

    }

}
