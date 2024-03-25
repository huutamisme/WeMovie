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

namespace LoginForm
{
    /// <summary>
    /// Interaction logic for EditUserProfile.xaml
    /// </summary>
    public partial class EditUserProfile : Window
    {
        public EditUserProfile()
        {
            InitializeComponent();
        }

        private void RadioButton_Male_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Female_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
