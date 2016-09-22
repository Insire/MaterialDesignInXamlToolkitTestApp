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

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            var flyout = Flyouts.Items[0] as Flyout;

            flyout.IsOpen = !flyout.IsOpen;
        }

        private void Test_Button_Click(object sender, RoutedEventArgs e)
        {
            var flyout = Flyouts.Items[1] as Flyout;

            flyout.IsOpen = !flyout.IsOpen;
        }
    }
}
