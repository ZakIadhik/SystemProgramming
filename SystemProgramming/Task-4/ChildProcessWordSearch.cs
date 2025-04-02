using System;
using System.IO;

namespace WordSearchApp
{
    public class ChildProcessWordSearch
    {
        public static int RunChildProcess(string filePath, string searchWord)
        {
            try
            {
                int count = 0;
                string content = File.ReadAllText(filePath);
                
                string[] words = content.Split(new char[] { ' ', '\n', '\r', '.', ',', '!', '?' }, 
                    StringSplitOptions.RemoveEmptyEntries);
              
                foreach (string word in words)
                {
                    if (word.Equals(searchWord, StringComparison.OrdinalIgnoreCase))
                    {
                        count++;
                    }
                }
                
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in child process: {ex.Message}");
                return -1; 
            }
        }
    }
}