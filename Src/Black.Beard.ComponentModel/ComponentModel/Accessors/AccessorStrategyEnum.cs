using System;

namespace Bb.ComponentModel.Accessors
{


    [Flags]
    public enum AccessorStrategyEnum
    {

        /// <summary>
        /// direct copy of the value in the property
        /// </summary>
        Direct,

        /// <summary>
        /// Convert the argument in the target type property if different.
        /// </summary>
        ConvertIfDifferent,

        /// <summary>
        /// Append the fields in the accessor's list
        /// </summary>
        WithFields,

    }

}
