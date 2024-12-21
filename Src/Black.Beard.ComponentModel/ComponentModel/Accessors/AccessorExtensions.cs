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
        public static AccessorList GetAccessors(this Type type, MemberStrategy strategy = 
            MemberStrategy.Direct 
          | MemberStrategy.Properties 
          | MemberStrategy.Instance 
          | MemberStrategy.Static)
        {
            return AccessorItem.GetPropertiesImpl(type, strategy);
        }
    
    }

}
