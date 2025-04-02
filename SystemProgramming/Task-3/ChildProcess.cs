using System;

namespace CalculatorApp
{
    public class ChildProcess
    {
        public static void RunChildProcess(string num1, string num2, string operation)
        {
            try
            {
                double number1 = double.Parse(num1);
                double number2 = double.Parse(num2);
                
                Console.WriteLine($"Received arguments: {number1} {operation} {number2}");
           
                double result = 0;
                switch (operation)
                {
                    case "+":
                        result = number1 + number2;
                        break;
                    case "-":
                        result = number1 - number2;
                        break;
                    case "*":
                        result = number1 * number2;
                        break;
                    case "/":
                        if (number2 == 0)
                        {
                            Console.WriteLine("Error: Division by zero");
                            return;
                        }
                        result = number1 / number2;
                        break;
                    default:
                        Console.WriteLine("Error: Unknown operation");
                        return;
                }
                
                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in child process: {ex.Message}");
            }
        }
    }
}