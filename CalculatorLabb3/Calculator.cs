using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorLabb3
{
    public class Calculator
    {
        public double input1;
        public double input2;
        public static List<string> CalculationHistory;

        public Calculator()
        {
            CalculationHistory = new List<string>();
        }

        public double Addition(double input1, double input2)
        {
            double result = input1 + input2;
            string resultstring = $"{input1} + {input2} = {result}";
            AddCalculationToList(resultstring);
            return result;

        }
        public double Subtraction(double input1, double input2)
        {
            double result = input1 - input2;
            string resultstring = $"{input1} - {input2} = {result}";
            AddCalculationToList(resultstring);
            return result;
        }
        public double Multiplication(double input1, double input2)
        {
            double result = input1 * input2;
            string resultstring = $"{input1} * {input2} = {result}";
            AddCalculationToList(resultstring);

            return result;
        }

        public static void printCalc(string outPut)
        {
           
            Console.WriteLine(outPut);
        }
        public void AddCalculationToList(string calc)
        {
            CalculationHistory.Add(calc);
        }
        public static void PrintCalcHistory()
        {
            Console.Clear();
            if (CalculationHistory != null)
            {
                foreach (string item in CalculationHistory)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("No results was found");
            }
 
        }
    }
}
