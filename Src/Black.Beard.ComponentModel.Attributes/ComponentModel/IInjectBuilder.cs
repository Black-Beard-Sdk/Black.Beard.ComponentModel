using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bb.ComponentModel
{
    
    /// <summary>
    /// 
    /// </summary>
    public interface IInjectBuilder
    {

        object Run(object context);

        Type Type { get; }


    }

}
