using BAL.Services;
using DAL.Entities;
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
using System.Windows.Shapes;

namespace CRUDApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private UserService _service = new();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Window_Mousedown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();            
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUser.Text.Trim();
            string passwordHash = txtPass.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(passwordHash))
            {
                MessageBox.Show("Both email and password are required", "Field required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            User? account = _service.Authenticate(username, passwordHash);
            if (account == null)
            {
                MessageBox.Show("Invalid email or password", "Wrong credentials", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MainWindow main = new();
            main.AuthenticateUser = account;
            main.Show();
            this.Hide();
        }


    }
}
