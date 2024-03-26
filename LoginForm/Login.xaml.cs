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
using LoginForm.View;
using MahApps.Metro.Controls;
using Xceed.Wpf.Toolkit.Primitives;

namespace LoginForm
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {
        public HomePage homePage;
        public Login(HomePage homePage)
        {
            this.homePage = homePage;
            InitializeComponent();
            MyDatePicker.PreviewTextInput += DatePicker_PreviewTextInput;
        }

        public Login()
        {
            InitializeComponent();
            MyDatePicker.PreviewTextInput += DatePicker_PreviewTextInput;
        }

        public string gender = "Male";

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
                

                var username = emailBoxSignUp.Text;
                var password = passwordBoxSignUp.Password;

                var query = from user in App.WeMovieDb.Users
                            where user.username.Equals(username)
                            select new { Username = user.username, Password = user.password };
                var students = query.ToList();
                if (students.Count == 1)
                {
                    new MessageBoxCustom("Error", "User already exists", MessageType.Error, MessageButtons.OK);
                }
                else
                {
                    //sign up successfully
                    Trace.WriteLine(MyDatePicker.Text);
                    DateTime date = DateTime.ParseExact(MyDatePicker.Text, "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    App.WeMovieDb.Database.ExecuteSqlCommand("INSERT [User](username, password, birthday, gender) "
                                                        + "VALUES({0},{1}, {2}, {3})"
                                                        , username, password, date, gender);
                    txtBlockFLyout.Text = "Sign up successfully!";
                    SuccessFlyout.IsOpen = true;
                    SuccessFlyout.CloseButtonVisibility = Visibility.Hidden;
                }
            }
        }

        private async void SignInButtonClick(object sender, RoutedEventArgs e)
        {
            if (emailBox.Text.Length == 0)
            {
                txtBlockError.Text = "Please fill in all information fields";
                ErrorFlyout.IsOpen = true;
                ErrorFlyout.CloseButtonVisibility = Visibility.Hidden;
                await Task.Delay(1000);
                emailBox.Focus();
                return;
            }
            else if (passwordBox.Password.Length == 0)
            {
                txtBlockError.Text = "Please fill in all information fields";
                ErrorFlyout.IsOpen = true;
                ErrorFlyout.CloseButtonVisibility = Visibility.Hidden;
                await Task.Delay(1000);
                passwordBox.Focus();
                return;
            }
            else
            {
                var username = emailBox.Text;
                var password = passwordBox.Password;

                var query = from user in App.WeMovieDb.Users
                            where user.username.Equals(username)
                            select new { Username = user.username, Password = user.password };
                var students = query.ToList();
                Trace.WriteLine(students.Count);
                if (students.Count == 1)
                {
                    if (students[0].Password.Trim().Equals(password))
                    {
                        txtBlockFLyout.Text = "Sign in successfully!";
                        SuccessFlyout.IsOpen = true;
                        SuccessFlyout.CloseButtonVisibility = Visibility.Hidden;
                        await Task.Delay(1000);
                        App.isLoggedIn = true;
                        App.username = username;
                        homePage.showLogin();
                        this.Close();
                    }
                }

            }
        }

        private void RadioButton_Male_Checked(object sender, RoutedEventArgs e)
        {
            gender = "Male";
        }

        private void RadioButton_Female_Checked(object sender, RoutedEventArgs e)
        {
            gender = "Female";
        }
    }
}
