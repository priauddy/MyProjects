using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
    internal class VandermondeMatrixClass : MatrixClass
    {
        public void toVandermonde()
        {
            for (int i = 0; i < this.listOfEquations.Count; i++)
            {
                this.SetEquation(i, new EquationClass($"{Math.Pow(listOfEquations[i].Array.First(), 2)} {listOfEquations[i].Array.First()} {1} {listOfEquations[i].Array.Last()}"));
            }
        }
    }
}
