using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intergration
{
    internal interface IPolynomialClass
    {
        List<int> PolynomialCoefficients { get; set; }

        void DisplayFunction();
    }
}
