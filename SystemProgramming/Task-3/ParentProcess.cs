using System;

namespace CalculatorApp
{
    public class ParentProcess
    {
        public static void RunParentProcess(string num1, string num2, string operation)
        {
            try
            {
                if (!double.TryParse(num1, out _) || !double.TryParse(num2, out _))
                {
                    Console.WriteLine("Error: Arguments must be numbers");
                    return;
                }

                if (operation != "+" && operation != "-" && operation != "*" && operation != "/")
                {
                    Console.WriteLine("Error: Only +, -, *, / operations are supported");
                    return;
                }
                
                ChildProcess.RunChildProcess(num1, num2, operation);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in parent process: {ex.Message}");
            }
        }
    }
}