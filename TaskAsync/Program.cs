using System;
using System.Threading.Tasks;

namespace EfThreadingDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var manual = new ManualStudentService();
            var async = new AsyncStudentService();

            Console.WriteLine("== Manual methods ==");
            manual.AddStudentManually("Ivan");
            manual.ShowAllStudentsManually();

            Console.WriteLine("\n== Async methods ==");
            await async.AddStudentAsync("Maria");
            await async.ShowAllStudentsAsync();

            Console.ReadLine();
        }
    }
}