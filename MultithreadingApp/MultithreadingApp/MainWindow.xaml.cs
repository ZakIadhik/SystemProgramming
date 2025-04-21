using System;
using System.Threading.Tasks;
using System.Windows;

namespace MultithreadingApp
{
    public partial class MainWindow : Window
    {
        private RandomNumberGenerator randomNumberGenerator;
        private PrimeNumbersEndingWith7 primeNumbersEndingWith7;
        private ReportGenerator reportGenerator;
        private CasinoGame casinoGame;

        public MainWindow()
        {
            InitializeComponent();
            randomNumberGenerator = new RandomNumberGenerator();
            primeNumbersEndingWith7 = new PrimeNumbersEndingWith7();
            reportGenerator = new ReportGenerator();
            casinoGame = new CasinoGame();
        }

        private async void btnGenerateNumbers_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await randomNumberGenerator.GenerateNumbersAsync();
                txtOutput.AppendText("Numbers successfully generated and saved to the file.\n");
            }
            catch (Exception ex)
            {
                txtOutput.AppendText($"Error: {ex.Message}\n");
            }
        }

        private async void btnFilterNumbers_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await primeNumbersEndingWith7.FilterNumbersAsync();
                txtOutput.AppendText("Numbers that are prime and end with 7 have been successfully saved to a new file.\n");
            }
            catch (Exception ex)
            {
                txtOutput.AppendText($"Error: {ex.Message}\n");
            }
        }

        private async void btnGenerateReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await reportGenerator.GenerateReportAsync();
                txtOutput.AppendText("Report successfully generated.\n");
            }
            catch (Exception ex)
            {
                txtOutput.AppendText($"Error: {ex.Message}\n");
            }
        }

        private void btnStartCasinoGame_Click(object sender, RoutedEventArgs e)
        {
            casinoGame.StartGame();
            txtOutput.AppendText("Game started. Please wait for the completion...\n");
        }
    }
}
