using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace WeMovieManager
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {
        private Window mainWindow;

        public Login(Window mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;

        }

        private async void SignInButtonClick(object sender, RoutedEventArgs e)
        {
            if (emailBox.Text.Length == 0)
            {
                txtBlockError.Text = "Please fill in all information fields";
                ErrorFlyout.IsOpen = true;
                ErrorFlyout.CloseButtonVisibility = Visibility.Hidden;
                await Task.Delay(2000);
                emailBox.Focus();
                return;
            }
            else if (passwordBox.Password.Length == 0)
            {
                txtBlockError.Text = "Please fill in all information fields";
                ErrorFlyout.IsOpen = true;
                ErrorFlyout.CloseButtonVisibility = Visibility.Hidden;
                await Task.Delay(2000);
                passwordBox.Focus();
                return;
            }
            else
            {
                //sign in successfully
                var username = emailBox.Text;
                var password = passwordBox.Password;

                var query = from user in App.WeMovieDb.Managers
                            where user.username.Equals(username)
                            select new { Username = user.username, Password = user.password };
                var students = query.ToList();
                if (students.Count == 1)
                {
                    if (students[0].Password.Equals(password))
                    {
                        txtBlockFLyout.Text = "Sign in successfully!";
                        SuccessFlyout.IsOpen = true;
                        SuccessFlyout.CloseButtonVisibility = Visibility.Hidden;
                        await Task.Delay(1000);
                        this.Close();
                        mainWindow.Show();
                    }
                }
                //txtBlockFLyout.Text = "Sign in successfully!";
                //SuccessFlyout.IsOpen = true;
                //SuccessFlyout.CloseButtonVisibility = Visibility.Hidden;
                //await Task.Delay(1000);
                //this.Close();
                //mainWindow.Show();

            }
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SignInButtonClick(sender, e);
            }
        }

    }
}
