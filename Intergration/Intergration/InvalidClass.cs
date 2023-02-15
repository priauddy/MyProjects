using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intergration
{
    internal class InvalidClass : Exception
    {
        public InvalidClass()
        {
        }
        public InvalidClass(string Note) : base($"Wrong equation: {Note}")
        {
        }
    }
}
