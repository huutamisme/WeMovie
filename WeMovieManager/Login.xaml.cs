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
            MyDatePicker.PreviewTextInput += DatePicker_PreviewTextInput;
            this.mainWindow = mainWindow;

        }


        private void DatePicker_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            DatePicker datePicker = sender as DatePicker;
            if (datePicker == null)
                return;

            if (!char.IsDigit(e.Text, 0) && e.Text != "/")
            {
                e.Handled = true;
                return;
            }
        }

        private bool IsValidDate(string input)
        {
            DateTime date;
            return DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        }

        private async void SignUpButtonClick(object sender, RoutedEventArgs e)
        {
            string newText = MyDatePicker.Text;
            string emailPattern = @"^[a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$";
            if (emailBoxSignUp.Text.Length == 0)
            {
                txtBlockError.Text = "Please fill in all information fields";
                ErrorFlyout.IsOpen = true;
                ErrorFlyout.CloseButtonVisibility = Visibility.Hidden;
                await Task.Delay(2000);
                emailBoxSignUp.Focus();
                return;
            }
            else if (!Regex.IsMatch(emailBoxSignUp.Text, emailPattern))
            {
                txtBlockError.Text = "Please input valid email!";
                ErrorFlyout.IsOpen = true;
                ErrorFlyout.CloseButtonVisibility = Visibility.Hidden;
                await Task.Delay(2000);
                emailBoxSignUp.Undo();
                emailBoxSignUp.Focus();
                return;
            }
            else if (passwordBoxSignUp.Password.Length == 0)
            {
                txtBlockError.Text = "Please fill in all information fields";
                ErrorFlyout.IsOpen = true;
                ErrorFlyout.CloseButtonVisibility = Visibility.Hidden;
                await Task.Delay(2000);
                passwordBoxSignUp.Focus();
                return;
            }
            else if (!IsValidDate(newText))
            {
                txtBlockError.Text = "Invalid date format. Please enter a valid date in the format dd/mm/yyyy.";
                ErrorFlyout.IsOpen = true;
                ErrorFlyout.CloseButtonVisibility = Visibility.Hidden;
                await Task.Delay(2000);
                MyDatePicker.Focus();
                return;
            }
            else
            {
                //sign up successfully
                txtBlockFLyout.Text = "Sign up successfully!";
                SuccessFlyout.IsOpen = true;
                SuccessFlyout.CloseButtonVisibility = Visibility.Hidden;
            }
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
                        await Task.Delay(2000);
                        this.Close();
                        mainWindow.Show();
                    }
                }
            }
        }
    }
}
