using System;
using System.Collections.Generic;

namespace Polynomial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }
            Console.WriteLine("Please input points in x y representation.\nType END to finish.");
            int index = 1;
            try
            {
                VandermondeMatrixClass matrix = new VandermondeMatrixClass();
                while (true)
                {
                    Console.Write($"P#{index++}: ");
                    String input = Console.ReadLine();
                    if (input.Trim().ToUpper() == "END" || input.Trim() == "")
                        break;
                    matrix.AddEquation(new PointClass(input));
                }
                matrix.toVandermonde();
                Console.WriteLine("Resulting polynomial will be of the order - " + PolynomialClass.CalculateOrder(matrix) + "\nCalculated polynomial:");
                double[] coefficients = matrix.GetResults();
                Console.WriteLine(PolynomialClass.Format(coefficients));
                Dictionary<int, double> calculatedPolynomial = PolynomialClass.Calculate(coefficients);
                foreach (KeyValuePair<int, double> value in calculatedPolynomial)
                    Console.WriteLine($"f({value.Key}) = {value.Value:0.000}");
                Console.WriteLine("Derivative:\n" + PolynomialClass.CalculateDerivative(coefficients));
                double inititalGuess = 2;
                Console.WriteLine("Looking for a root with initial guess 2");
                Console.WriteLine("Root found for x = " + PolynomialClass.CalculateRoot(coefficients, inititalGuess).ToString("0.00000"));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured: " + e.Message);
            }
        }
    }
}
