using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_Equation
{
    internal class MatrixClass
    {
        private readonly List<LinearEquationClass> listOfEquations = new List<LinearEquationClass>();

        private int width;

        public int Width
        {
            get
            {
                return this.width;
            }
        }

        public int Length
        {
            get
            {
                return listOfEquations.Count;
            }
        }

        public LinearEquationClass RecieveEquation(int index)
        {
            return listOfEquations[index];
        }

        public LinearEquationClass LayoutOfEquation(int index, LinearEquationClass LinEq)
        {
            return listOfEquations[index] = LinEq;
        }

        public void ForwardElimination()
        {
            int Rows = this.Length;
            int Column = this.Width;

            for (int LRow = 0; LRow < Rows; LRow++)
            {
                for (int i = LRow + 1; i < Column - 1; i++)
                {
                    double Element = this.RecieveEquation(i).Array[LRow] / this.RecieveEquation(LRow).Array[LRow];

                    for (int LCol = LRow; LCol < Column; LCol++)
                        this.RecieveEquation(i).Array[LCol] -= Element * this.RecieveEquation(LRow).Array[LCol];
                }
            }
        }

        private double[] SolveMatrix()
        {
            int length = this.RecieveEquation(0).Array.Length;

            for (int i = 0; i < this.Length - 1; i++)
            {
                if (this.RecieveEquation(i).Array[i] == 0 && !PivotProcedure(this, i, i))
                    throw new Exception("Can not calculate this");
                for (int j = i; j < this.Length; j++)
                {
                    double[] SetUp = new double[length];

                    for (int x = 0; x < length; x++)
                    {
                        SetUp[x] = this.RecieveEquation(j).Array[x];
                        if (this.RecieveEquation(j).Array[i] != 0)
                            SetUp[x] = SetUp[x] / this.RecieveEquation(j).Array[i];
                    }
                    _ = this.LayoutOfEquation(j, new LinearEquationClass(SetUp));
                }
                for (int y = i + 1; y < this.Length; y++)
                {
                    double[] f = new double[length];
                    for (int g = 0; g < length; g++)
                    {
                        f[g] = this.RecieveEquation(y).Array[g];
                        if (this.RecieveEquation(y).Array[i] != 0)
                            f[g] = f[g] - this.RecieveEquation(i).Array[g];
                    }
                    this.LayoutOfEquation(y, new LinearEquationClass(f));
                }
            }

            return ReverseSubstitution(this);
        }

        private bool PivotProcedure(MatrixClass matrix, int row, int column)
        {
            bool swapped = false;
            for (int z = matrix.Length - 1; z > row; z--)
            {
                if (matrix.RecieveEquation(z).Array[row] != 0)
                {
                    _ = new double[matrix.RecieveEquation(0).Array.Length];
                    double[] temp = matrix.RecieveEquation(z).Array;
                    matrix.LayoutOfEquation(z, matrix.RecieveEquation(column));
                    matrix.LayoutOfEquation(column, new LinearEquationClass(temp));
                    swapped = true;
                }
            }

            return swapped;
        }

        public double[] ReverseSubstitution(MatrixClass matrix)
        {
            int length = matrix.RecieveEquation(0).Array.Length;
            double[] result = new double[matrix.Length];
            for (int i = matrix.Length - 1; i >= 0; i--)
            {
                double val = matrix.RecieveEquation(i).Array[length - 1];
                for (int x = length - 2; x > i - 1; x--)
                {
                    if (result.Length <= x || matrix.RecieveEquation(i).Array.Length <= x)
                        break;

                    val -= matrix.RecieveEquation(i).Array[x] * result[x];
                }
                result[i] = val / matrix.RecieveEquation(i).Array[i];

                if (!Confirmation(result[i]))
                    throw new Exception("Can not calculate this");
            }
            return result;
        }

        private bool Confirmation(double result)
        {
            return !(double.IsNaN(result) || double.IsInfinity(result));
        }

        public void ShowResults()
        {
            double[] result = this.SolveMatrix();

            for (int i = 0; i < result.Length; i++)
                Console.WriteLine($"x{i + 1} = {result[i]}");
        }

        public void JoinEquation(LinearEquationClass LinEq)
        {
            if (this.listOfEquations.Count == 0)
                this.width = LinEq.Array.Length;

            if (LinEq.Array.Length != this.width)
                throw new Exception("Invalid equation added, wrong dimensions!");

            this.listOfEquations.Add(LinEq);
        }

        public void TakeOutEquation(LinearEquationClass LinEq)
        {
            this.listOfEquations.Remove(LinEq);
        }

        public override string ToString()
        {
            String Result = "";
            foreach (LinearEquationClass e in listOfEquations)
                Result += String.Join(" ", e.Array) + "\n";

            return Result;
        }
    }
}
