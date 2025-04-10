using System;

namespace Bb.Accessors
{

    /// <summary>
    /// Enumeration for member access strategies.
    /// </summary>
    [Flags]
    public enum MemberStrategys
    {

        /// <summary>
        /// Include instance members.
        /// </summary>
        /// <remarks>
        /// This flag indicates that instance members (non-static) should be included in the accessor's list.
        /// </remarks>
        Instance = 1,

        /// <summary>
        /// Include static members.
        /// </summary>
        /// <remarks>
        /// This flag indicates that static members should be included in the accessor's list.
        /// </remarks>
        Static = 2,

        /// <summary>
        /// Direct copy of the value in the property.
        /// </summary>
        /// <remarks>
        /// This flag specifies that the value should be directly copied to the property without any conversion.
        /// </remarks>
        Direct = 4,

        /// <summary>
        /// Convert the argument to the target type property if different.
        /// </summary>
        /// <remarks>
        /// This flag specifies that the argument should be converted to the target type of the property if the types differ.
        /// </remarks>
        ConvertIfDifferent = 8,

        /// <summary>
        /// Append the properties to the accessor's list.
        /// </summary>
        /// <remarks>
        /// This flag indicates that properties should be included in the accessor's list.
        /// </remarks>
        Properties = 16,

        /// <summary>
        /// Append the fields to the accessor's list.
        /// </summary>
        /// <remarks>
        /// This flag indicates that fields should be included in the accessor's list.
        /// </remarks>
        Fields = 32,

        /// <summary>
        /// Include non-public fields.
        /// </summary>
        /// <remarks>
        /// This flag specifies that non-public fields should be included in the accessor's list. It also includes the <see cref="Fields"/> flag.
        /// </remarks>
        NotPublicFields = 64 + Fields,

    }

}
