using System;

namespace Bb.ComponentModel.Accessors
{


    [Flags]
    public enum MemberStrategy
    {

        /// <summary>
        /// Include instance members
        /// </summary>
        Instance = 1,

        /// <summary>
        /// Include static members
        /// </summary>
        Static = 2,

        /// <summary>
        /// direct copy of the value in the property
        /// </summary>
        Direct = 4,

        /// <summary>
        /// Convert the argument in the target type property if different.
        /// </summary>
        ConvertIfDifferent = 8,

        /// <summary>
        /// Append the properties in the accessor's list
        /// </summary>
        Properties = 16,

        /// <summary>
        /// Append the fields in the accessor's list
        /// </summary>
        Fields = 32,

        /// <summary>
        /// Include not public fields
        /// </summary>
        NotPublicFields = 64 + Fields,

    }

}
