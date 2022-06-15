using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CalculatorLabb3
{
    public class Calculator
    {

        public static List<double> userInputs = new List<double>();
        public static double input;
        public static bool userInputBool = true;
        public static bool SaveResultMeny = true;
        public static string operatorString;

        public static double resultSavedInMemory = 0;



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

            while (userInputBool)
            {
                if (resultSavedInMemory != 0)
                {
                    Console.WriteLine("Would you like to use your stored result in this calculation?\n1. Yes\n2. No");
                    
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine($"You pressed yes, adding {resultSavedInMemory} to you current calculation and clearing the saved result from the stored memory");
                            userInputs.Add(resultSavedInMemory);
                            resultSavedInMemory = 0;
                            break;
                        case "2":
                            break;
                        default:
                            break;
                    }
                }

                Console.WriteLine("Please enter a number");

                string inputUSer = Console.ReadLine();

                if (double.TryParse(inputUSer, out input))
                {
                    
                    userInputs.Add(input);
                }
                else if (inputUSer == "")
                {
                    userInputBool = false;
                }
                else
                {
                    Console.WriteLine("You must enter numbers, not special characters!");
                }
               
            }

            userInputBool = true;


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

            for (int i = 0; i < userInputs.Count; i++)
            {
                if (i < (userInputs.Count -1))
                {
                    operatorString = calcFormString;
                }
                else
                {
                    operatorString = "";
                }
                
                resultString += $"{userInputs[i]} {operatorString} ";
            }

            resultString += $"= {result}";
            CalculationHistory.Add(resultString);

            


        }
        public static void PrintResult()
        {
            Console.WriteLine($"Your calculation: {resultString} \nPress enter to go back to menu...");
            Console.ReadLine();

            SaveResultInMemory(result);

            


            resultString = "";
            userInputs.Clear();
            result = 0;
            Console.Clear();
        }

        public static double SaveResultInMemory(double tempResult)
        {
            result = tempResult;

            if (resultSavedInMemory == 0)
            {
                while (SaveResultMeny)
                {
                    Console.WriteLine($"By the way! Would you like to save this result to use for later?\n1. Yes\n2. No");
                    string SaveResult = Console.ReadLine();
                    if (SaveResult == "1")
                    {
                        resultSavedInMemory = result;
                        Console.WriteLine($"You pressed yes, saving result {resultSavedInMemory} in memory...\nPress Enter to go back to menu");
                        Console.ReadLine();
                       
                        break;
                    }
                    else if (SaveResult == "2")
                    {
                        Console.WriteLine($"You pressed no, going back to meny...");
                        Thread.Sleep(2000);
                        break;
                    }
                }
            }
           
            return result;
        }

        public static double Addition()
        {

            foreach (var item in userInputs)
            {
                result += item;
            }
            return result;

        }
        public static double Subtraction()
        {

            result = userInputs[0];

            for (int i = 1; i < userInputs.Count; i++)
            {
                result -= userInputs[i];
            }
            return result;
        }
        public static double Multiplication()
        {
            result = userInputs[0];

            for (int i = 1; i < userInputs.Count; i++)
            {
                result *= userInputs[i];
            }
            return result;
        }
        public static double Division()
        {
            result = userInputs[0];

            for (int i = 1; i < userInputs.Count; i++)
            {
                result /= userInputs[i];
            }
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
