using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CheckPassword
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

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            textBox.Text = passwordBox.Password;
            textBox.Visibility = Visibility.Visible;
            passwordBox.Visibility = Visibility.Collapsed;
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordBox.Password = textBox.Text;
            passwordBox.Visibility = Visibility.Visible;
            textBox.Visibility = Visibility.Collapsed;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string password = null;

            if (checkBox.IsChecked.Value)
                password = textBox.Text;
            else password = passwordBox.Password;

            if (PasswordCheck.ValidatePassword(password)) MessageBox.Show("Vaslid password!", "Correct", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
