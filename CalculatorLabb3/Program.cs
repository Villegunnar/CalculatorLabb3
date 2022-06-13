using System;

namespace CalculatorLabb3
{
    class Program
    {
        static void Main(string[] args)
        {


            while (true)
            {
                Console.WriteLine("1. Calculate \n2. Calculate History");
                string menyChocie = Console.ReadLine();
                switch (menyChocie)
                {
                    case "1":
                        Console.Clear();
                        Calculator calc = new Calculator();


                        Console.WriteLine("Please enter a number");
                        while (!double.TryParse(Console.ReadLine(), out calc.input1))
                        {
                            Console.WriteLine("Error, enter a number instead");
                        }


                        Console.WriteLine("Please enter another number");
                        while (!double.TryParse(Console.ReadLine(), out calc.input2))
                        {
                            Console.WriteLine("Error, enter a number instead");
                        }

                        Console.WriteLine("Choose your from of calculation\n1. Addition\n2. Subtraction\n3. Multiplication");
                        string calcForm = Console.ReadLine();
                        switch (calcForm)
                        {
                            case "1":
                                double additionResult = calc.Addition(calc.input1, calc.input2);
                                Calculator.printCalc(Convert.ToString(additionResult));
                                break;
                            case "2":
                                double subtractionResult = calc.Subtraction(calc.input1, calc.input2);
                                Calculator.printCalc(Convert.ToString(subtractionResult));

                                break;
                            case "3":
                                double multiplicationResult = calc.Multiplication(calc.input1, calc.input2);
                                Calculator.printCalc(Convert.ToString(multiplicationResult));
                                break;

                            default:
                                break;
                        }

                        break;
                    case "2":
                        Calculator.PrintCalcHistory();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
