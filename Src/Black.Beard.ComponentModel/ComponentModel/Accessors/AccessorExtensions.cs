using System;

namespace Bb.ComponentModel.Accessors
{
    public static class AccessorExtensions
    {


        /// <summary>
        /// Returns the property accessor list.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="strategy"></param>
        /// <returns></returns>
        public static AccessorList GetAccessors(this Type type, AccessorStrategyEnum strategy = AccessorStrategyEnum.Direct)
        {
            return AccessorItem.GetPropertiesImpl(type, strategy);
        }
    
    }

}
