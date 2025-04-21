using System.IO;
using System.Threading.Tasks;

namespace MultithreadingApp
{
    public class ReportGenerator
    {
        public async Task GenerateReportAsync()
        {
            await Task.Run(() =>
            {
                var reportLines = new[]
                {
                    "=== Report ===",
                    $"Date: {System.DateTime.Now}",
                    "Generated numbers file: numbers.txt",
                    "File of filtered prime numbers ending with 7: primeNumbersEndingWith7.txt"
                };

                File.WriteAllLines("report.txt", reportLines);
            });
        }
    }
}