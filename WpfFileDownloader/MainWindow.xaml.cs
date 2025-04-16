using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows;

namespace WpfFileDownloader
{
    public partial class MainWindow : Window
    {
        private static Mutex mutex = new Mutex();
        private static ManualResetEvent mre = new ManualResetEvent(true);
        private int completedDownloads = 0;
        private int totalDownloads = 3; 

        public MainWindow()
        {
            InitializeComponent();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> urls = new List<string>
            {
                "https://filesamples.com/samples/document/txt/sample1.txt",
                "https://filesamples.com/samples/document/txt/sample2.txt",
                "https://filesamples.com/samples/document/txt/sample3.txt"
            };

            ThreadPool.QueueUserWorkItem(DownloadFilesSequentially, urls);
        }

        private void DownloadFilesSequentially(object urlsObject)
        {
            List<string> urls = (List<string>)urlsObject;

            foreach (var url in urls)
            {
                mre.WaitOne();
                mre.Reset();

                DownloadFile(url);

                mre.Set();
            }

            Dispatcher.Invoke(() =>
            {
                statusListBox.Items.Add("All files have been downloaded! 🚀");
                Console.WriteLine("All files have been downloaded! 🚀");
            });
        }

        private void DownloadFile(string url)
        {
            string fileName = Path.GetFileName(url);

            WriteToListBox($"Download started: {fileName}...");
            Console.WriteLine($"Download started: {fileName}...");

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile(url, fileName);
                }

                WriteToListBox($"Download completed: {fileName}");
                Console.WriteLine($"Download completed: {fileName}");
            }
            catch (Exception ex)
            {
                WriteToListBox($"Error downloading {fileName}: {ex.Message}");
                Console.WriteLine($"Error downloading {fileName}: {ex.Message}");
            }
        }

        private void WriteToListBox(string message)
        {
            Dispatcher.Invoke(() =>
            {
                mutex.WaitOne();
                statusListBox.Items.Add(message);
                mutex.ReleaseMutex();
            });
        }
    }
}
