using System;
using System.Diagnostics;

namespace SystemProgramming
{
    public class Task_1
    {
        public static void Run()
        {
            string processName = "calc.exe"; 

            Process process = new Process();

            process.StartInfo.FileName = processName;

            try
            {
                process.Start();
                process.WaitForExit();
                
                Console.WriteLine($"Process {processName} finished with code: {process.ExitCode}");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error running the process: {ex.Message}");
            }
        }
    }
}