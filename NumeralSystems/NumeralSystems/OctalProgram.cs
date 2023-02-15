using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumeralSystems
{
    internal class OctalProgram : ITheNumberSystem
    {
        public double Number { get; private set; }

        public OctalProgram(string userInput)
        {
            Number = double.Parse(userInput);
        }

        //converting octal Number to decimal  program
        public string OctalToDecimal()
        {
            int digit = (int)Number;
            double decValue = 0;
            int baseToPowerNumber = 1;

            int value = digit;
            while (value > 0)
            {
                int lastDigit = value % 10;
                if (lastDigit > 8) throw new IndexOutOfRangeException();
                value /= 10;
                decValue += lastDigit * baseToPowerNumber;
                baseToPowerNumber *= 8;
            }
            string answer = decValue.ToString();
            double fraction = Number - Math.Truncate(Number);
            if (fraction != 0) answer += (',');

            // Conversion of fraction side of a Number
            //limit of digits after point
            int Limitation = 3;
            while (true && Limitation > 0)
            {
                Limitation--;
                fraction *= 8;
                int fractional = (int)fraction;
                if (fraction == 0) break;
                else
                {
                    answer += fractional;
                    fraction -= fractional;
                }
            }
            return answer;
        }

        public void ShowResults()
        {
            Console.WriteLine("In Octal: " + Number);
            Console.WriteLine("In Decimal: " + OctalToDecimal());
            string Result = OctalToDecimal();
            DecimalProgram dec = new DecimalProgram(Result);
            Console.WriteLine(dec.DecimalToBinary());
            Console.WriteLine(dec.DecimalToHexa());
        }
    }
}
