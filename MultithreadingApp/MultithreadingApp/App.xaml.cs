using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace MultithreadingApp
{
    public partial class App : Application
    {
        public App()
        {
            var processes = Process.GetProcessesByName("MultithreadingApp");

            if (processes.Length > 3)
            {
                MessageBox.Show("The application can be launched no more than 3 times.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
        }
    }
}