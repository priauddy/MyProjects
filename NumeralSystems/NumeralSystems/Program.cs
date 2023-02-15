using System;

namespace NumeralSystems
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainProgram();

            void MainProgram()
            {
                Console.WriteLine("Type any number:");
                string input = Console.ReadLine();
                try
                {
                    ITheNumberSystem numberSystem;
                    if (input[0] == '0' && input[1] != 'x' && input[1] != 'X' && input[1] != ',')   //if number is octal
                    {
                        numberSystem = new OctalProgram(input);
                    }
                    else if (input[1] == 'x' || input[1] == 'X')  // if number is hexadecimal
                    {
                        numberSystem = new HexadecimalProgram(input);
                    }
                    else // if number is decimal
                    {
                        numberSystem = new DecimalProgram(input);
                    }
                    numberSystem.ShowResults();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                LoopOfMainProgram();//Re-loop the main program due to error
            }
            //ask the user if he/she wants to enter a new number
            void LoopOfMainProgram()
            {
                while (true)
                {
                    Console.WriteLine("Do you want to Convert another number? \n Type 'yes' or 'no'");
                    string answer = Console.ReadLine();
                    if (answer != "no")
                    {
                        if (answer == "yes") { Console.Clear(); MainProgram(); break; }
                        else Console.WriteLine("Wrong answer");
                    }
                    else { Environment.Exit(0); break; }
                }
            }
        }
    }
}
    

