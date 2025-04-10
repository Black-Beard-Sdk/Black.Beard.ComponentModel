using System.Collections.Generic;

namespace Bb.ComponentModel.Attributes
{


    /// <summary>
    /// Configuration to register Exposition manually  
    /// </summary>    
    [ExposeClass(Context = ConstantsCore.Configuration, Name = ConstantsCore.ExposedTypes, LifeCycle = IocScope.Singleton)]
    public class ExposedTypeConfigurations : List<ExposedAttributeTypeConfiguration>
    {


    }


}
