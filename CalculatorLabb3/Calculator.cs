using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CalculatorLabb3
{
    public class Calculator
    {
        public static double input1;
        public static double input2;
        public static double result;
        public static string resultString;
        public static string calcFormString;
        
        public static List<string> CalculationHistory = new List<string>();

        public static bool mainMenu = true;
        public static bool calcFormMenu = true;



        public static void MainMenu()
        {

            while (mainMenu)
            {
               
                Console.WriteLine("-----------------------   Calculator   -----------------------\n\n1. Calculate \n2. Calculate History\n3. Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        UserInputs();
                        CalculationForm();
                        break;
                    case "2":
                        PrintCalcHistory();
                        break;
                    case "3":
                        Exit();
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }
        public static void UserInputs()
        {
            Console.Clear();
            
            
                Console.WriteLine("Please enter a number");
                while (!double.TryParse(Console.ReadLine(), out input1))
                {
                    Console.WriteLine("Error, enter a number instead");
                }

                Console.WriteLine("Please enter another number");
                while (!double.TryParse(Console.ReadLine(), out input2))
                {
                    Console.WriteLine("Error, enter a number instead");
                }
                Console.Clear();
            

        }
        public static void CalculationForm()
        {
            while (calcFormMenu)
            {
                Console.WriteLine("Choose your from of calculation\n1. Addition (+)\n2. Subtraction (-)\n3. Division(/)\n4. Multiplication(*)");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Addition();
                        StoreCalculation("+");
                        PrintResult();
                        calcFormMenu = false;

                        break;
                    case "2":
                        Console.Clear();
                        Subtraction();
                        StoreCalculation("-");
                        PrintResult();
                        calcFormMenu = false;
                        break;
                    case "3":
                        Console.Clear();
                        Division();
                        StoreCalculation("/");
                        PrintResult();
                        calcFormMenu = false;
                        break;
                    case "4":
                        Console.Clear();
                        Multiplication();
                        StoreCalculation("*");
                        PrintResult();
                        calcFormMenu = false;
                        break;

                    default:
                        Console.Clear();
                        break;
                }
            }
            calcFormMenu = true;
        }
        public static void StoreCalculation(string calcOperator)
        {
            calcFormString = calcOperator;
            resultString = $"{input1} {calcFormString} {input2} = {result}";
            CalculationHistory.Add(resultString);
        }
        public static void PrintResult()
        {
            Console.WriteLine($"Your calculation: {resultString} \nPress enter to go back to menu...");
            Console.ReadLine();
            Console.Clear();
        }

        
        public static double Addition()
        {
            result = input1 + input2;
            return result;

        }
        public static double Subtraction()
        {
            result = input1 - input2;
            return result;
        }
        public static double Multiplication()
        {
            result = input1 * input2;
            return result;
        }
        public static double Division()
        {
            result = input1 / input2;
            return result;
        }




        public static void PrintCalcHistory()
        {
            Console.Clear();
            if (CalculationHistory.Count > 0)
            {
                Console.WriteLine("Calculation History \n");
                foreach (string item in CalculationHistory)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("\nPress enter to go back to menu...");
            }
            else
            {
                Console.WriteLine("No results was found!\nPress enter to go back to menu...");
            }
            Console.ReadLine();
            Console.Clear();
        }
        public static void Exit()
        {
            mainMenu = false;
            Console.WriteLine("The application is shutting down...");
            Thread.Sleep(3000);
        }



    }
}
