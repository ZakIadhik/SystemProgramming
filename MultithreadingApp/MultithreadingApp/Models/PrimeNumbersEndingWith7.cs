using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MultithreadingApp
{
    public class PrimeNumbersEndingWith7
    {
        private readonly string inputFilePath = "numbers.txt";
        private readonly string outputFilePath = "primeNumbersEndingWith7.txt";

        public async Task FilterNumbersAsync()
        {
            await Task.Run(() =>
            {
                var numbers = File.ReadAllLines(inputFilePath).Select(int.Parse).ToList();
                var filtered = numbers.Where(n => IsPrime(n) && n % 10 == 7).ToList();
                File.WriteAllLines(outputFilePath, filtered.Select(n => n.ToString()));
            });
        }

        private bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
                if (number % i == 0) return false;
            return true;
        }
    }
}