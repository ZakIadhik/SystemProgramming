using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MultithreadingApp
{
    public class RandomNumberGenerator
    {
        private readonly string filePath = "numbers.txt";

        public async Task GenerateNumbersAsync(int count = 100)
        {
            await Task.Run(() =>
            {
                Random random = new();
                var numbers = new List<int>();
                for (int i = 0; i < count; i++)
                {
                    numbers.Add(random.Next(1, 1000));
                }
                File.WriteAllLines(filePath, numbers.Select(n => n.ToString()));
            });
        }
    }
}