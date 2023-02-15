using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intergration
{
    internal interface INtegrationMethodClass
    {
        double TrapezodalMethod(int numberOfInterval);

        double SimpsonMethod(int numberOfInterval);
    }
}
