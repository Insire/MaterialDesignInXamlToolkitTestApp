using MahApps.Metro.Controls;
using System.Windows;

namespace TestApp
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var flyout = Flyouts.Items[0] as Flyout;

            flyout.IsOpen = !flyout.IsOpen;
        }
    }
}
