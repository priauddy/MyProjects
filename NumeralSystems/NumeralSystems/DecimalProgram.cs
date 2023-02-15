using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumeralSystems
{
    internal class DecimalProgram : ITheNumberSystem
    {
        protected double Number { get; private set; }

        public DecimalProgram(string userInput)
        {
            Number = double.Parse(userInput);
        }

        public void ShowResults() => Console.WriteLine("In decimal: " + Number + "\n" + DecimalToBinary() + "\n" + DecimalToHexa() + "\n" + DecimalToOctal());

        private string DecimalToEverything(int Base)
        {
            string result = string.Empty;

            int Integral = (int)Number;

            double fraction = Number - Integral;
            //Refuse the input of a negative Number
            if (Integral < 0) throw new System.IndexOutOfRangeException();

            while (Integral > 0)
            {
                int reminder = Integral % Base;
                result += (char)(reminder + '0');
                Integral /= Base;
            }
            result = Undo(result);
            if (fraction != 0) result += ('.');

            // Converting the fraction part of the Number to binary Number
            int Limit = 5;
            while (true && Limit > 0)
            {
                Limit--;
                fraction *= Base;
                int fractionBit = (int)fraction;
                if (fraction == 0) break;
                else
                {
                    result += fractionBit;
                    fraction -= fractionBit;
                }
            }
            return result;
        }

        public string DecimalToBinary()
        {
            return "In binary: " + DecimalToEverything(2);
        }

        public string DecimalToOctal()
        {
            return "In octal: " + DecimalToEverything(8);
        }

        public string DecimalToHexa()
        {
            string result = string.Empty;

            int Integral = (int)Number;

            double fractional = Number - Integral;

            result += string.Format("{0:X}", Integral);
            if (fractional != 0) result += ('.');

            // Converting the fraction part of the Number to hexadecimal Number
            int Limit = 5;
            while (true && Limit > 0)
            {
                Limit--;
                fractional *= 16;
                int fractionalBit = (int)fractional;
                if (fractional == 0) break;
                else
                {
                    result += string.Format("{0:X}", fractionalBit);
                    fractional -= fractionalBit;
                }
            }
            return "In hexadecimal: " + result;
        }

        private string Undo(string input)
        {
            char[] k = input.ToCharArray();
            int left;
            int right = k.Length - 1;

            for (left = 0; left < right; left++, right--)
            {
                char temp = k[left];
                k[left] = k[right];
                k[right] = temp;
            }
            return string.Join("", k);
        }
    }
}
