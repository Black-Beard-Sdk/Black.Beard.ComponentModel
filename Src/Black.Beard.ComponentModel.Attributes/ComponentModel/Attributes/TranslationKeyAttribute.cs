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
        /// Translation key
        /// </summary>
        public string Key { get; }

    }

}
