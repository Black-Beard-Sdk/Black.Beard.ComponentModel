using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Bb.ComponentModel
{
    public static class Globals
    {

        /// <summary>
        /// Set DefaultThreadCurrentCulture with specified culture key
        /// </summary>
        /// <param name="cultureKey"></param>
        public static void SetCulture(string cultureKey)
        {
            if (!string.IsNullOrEmpty(cultureKey))
                CultureInfo.DefaultThreadCurrentCulture = CultureInfo.GetCultureInfo(cultureKey);
        }

        /// <summary>
        /// specify text convertion format for date 
        /// </summary>
        /// <param name="formatDateCulture"></param>
        public static void SetFormatDateCulture(string formatDateCulture)
        {

            if (string.IsNullOrEmpty(formatDateCulture))
                formatDateCulture = "u";

            Globals._formatDateCulture = formatDateCulture;

            DateTime.Now.ToText();

        }

        /// <summary>
        /// Convert date in text
        /// </summary>
        /// <param name="timeOffset"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToText(this DateTimeOffset timeOffset)
        {
            return timeOffset.ToUniversalTime().ToString(Globals._formatDateCulture, CultureInfo.DefaultThreadCurrentCulture);
        }

        /// <summary>
        /// Convert date in text
        /// </summary>
        /// <param name="timeOffset"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToText(this DateTime timeOffset)
        {
            return timeOffset.ToUniversalTime().ToString(Globals._formatDateCulture, CultureInfo.DefaultThreadCurrentCulture);
        }

        private static string _formatDateCulture;

    }

}



