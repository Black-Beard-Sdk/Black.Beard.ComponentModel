using System.Collections.Generic;

namespace Bb.ComponentModel.Attributes
{


    /// <summary>
    /// Configuration to register Exposition manually  
    /// </summary>
    /// <seealso cref="List{ComponentModel.ExposedTypeConfiguration}" />
    [ExposeClass(Context = ConstantsCore.Configuration, Name = ConstantsCore.ExposedTypes, LifeCycle = IocScopeEnum.Singleton)]
    public class ExposedTypeConfigurations : List<ExposedAttributeTypeConfiguration>
    {


    }


}
