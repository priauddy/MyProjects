using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumeralSystems
{
    internal class HexadecimalProgram : ITheNumberSystem
    {
        public string UserInput { get; set; }

        //setting the user inputs from the main program to the Hexadecimal program
        public HexadecimalProgram(string newUserInput)
        {
            this.UserInput = newUserInput;
        }

        //program for converting hexadecial numbers to decimal numbers
        public double HexToDec()
        {
            double Answer = 0;
            string FractionalPart = string.Empty;
            string IntegralPart;
            //in case the user inputs a nnumber with a decimal point
            if (UserInput.Contains(','))
            {
                string[] SplittedNumber = UserInput.Split(',');

                IntegralPart = SplittedNumber[0];
                FractionalPart = SplittedNumber[1];
            }
            else IntegralPart = UserInput;

            int count = IntegralPart.Length - 1;
            for (int i = 0; i < IntegralPart.Length; i++)
            {
                int temp = 0;
                switch (IntegralPart[i])
                {
                    case 'x': break;
                    case 'A': temp = 10; break;
                    case 'B': temp = 11; break;
                    case 'C': temp = 12; break;
                    case 'D': temp = 13; break;
                    case 'E': temp = 14; break;
                    case 'F': temp = 15; break;
                    default: temp = -48 + (int)IntegralPart[i]; break; // due to the -48 ASCII standards
                }

                Answer += temp * (int)(Math.Pow(16, count));
                count--;
            }

            if (FractionalPart != string.Empty)
            {
                string _ = Answer.ToString();
                _ += '.';
                for (int i = 0; i < 16; ++i)
                {
                    double FractionalValue = Answer - Math.Truncate(Answer);// math class method which is used to compute an integral part of a specified decimal Number
                    FractionalValue *= 16;
                    int digit = (int)FractionalValue;

                    _ = digit.ToString("X");

                    FractionalValue -= digit;

                    if (FractionalValue == 0)
                    {
                        break;
                    }
                    else
                    {
                        _ = Answer.ToString();
                    }
                }
            }

            return Answer;
        }

        public void ShowResults()
        {
            Console.WriteLine("In Hexadecimal: " + UserInput);
            Console.WriteLine("In Decimal: " + HexToDec());
            double result = HexToDec();
            DecimalProgram decimalSystems = new DecimalProgram(result.ToString());
            Console.WriteLine(decimalSystems.DecimalToBinary());
            Console.WriteLine(decimalSystems.DecimalToOctal());
        }
    }
}
