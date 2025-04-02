using System;
using System.IO;

namespace WordSearchApp
{
    public class ParentProcessWordSearch
    {
        public static void RunParentProcess(string filePath, string searchWord)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Error: File {filePath} does not exist");
                    return;
                }
                
                int result = ChildProcessWordSearch.RunChildProcess(filePath, searchWord);
                Console.WriteLine($"The word '{searchWord}' appears in the file {result} times");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in parent process: {ex.Message}");
            }
        }
    }
}