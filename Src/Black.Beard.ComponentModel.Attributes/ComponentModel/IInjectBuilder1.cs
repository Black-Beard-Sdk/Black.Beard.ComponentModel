using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bb.ComponentModel
{
    

    public interface IInjectBuilder<T> : IInjectBuilder
    {

        object Run(T context);


    }

}
