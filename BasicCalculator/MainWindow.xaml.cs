using System.Windows;
using System.Windows.Controls;

namespace BasicCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void input_Click(object sender, RoutedEventArgs e)
        {
            Button callingButton = (Button)sender;
            lblScreen.Content += callingButton.Content.ToString();
        }
        private void btnBackspace_Click(object sender, RoutedEventArgs e)
        {
         
            if(lblScreen.HasContent)
            {
                string newString = lblScreen.Content.ToString();
                if (newString.Length > 0)
                {
                    lblScreen.Content = newString.Substring(0, newString.Length - 1);
                }
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lblScreen.Content = "";
        }
    }
}
