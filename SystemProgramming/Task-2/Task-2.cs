using System;
using System.Diagnostics;

namespace SystemProgramming
{
    public class Task_2
    {
        public static void Run()
        {
            string processName = "calc.exe";
            
            Console.WriteLine("Choose an action:");
            Console.WriteLine("1. Wait for the child process to exit");
            Console.WriteLine("2. Forcefully terminate the child process");
            string choice = Console.ReadLine();
            
            Process process = new Process();
            process.StartInfo.FileName = processName;
            process.StartInfo.UseShellExecute = false;

            try
            {
                process.Start();
                Console.WriteLine($"Process {processName} started.");
                
                if (choice == "1")
                {
                    process.WaitForExit();
                    Console.WriteLine($"Process exited with code: {process.ExitCode}");
                }
                else if (choice == "2")
                {
                    process.Kill();
                    Console.WriteLine($"Process {processName} was forcefully terminated.");
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting the process: {ex.Message}");
            }
        }
    }
}