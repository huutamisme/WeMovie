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

namespace WeMovieManager
{
    /// <summary>
    /// Interaction logic for AddShowtime.xaml
    /// </summary>
    public partial class AddShowtime : Window
    {
        public AddShowtime()
        {
            InitializeComponent();
            List<string> movieNames = new List<string>
            {
                "The Shawshank Redemption",
                "The Godfather",
                "The Dark Knight",
                "Forrest Gump",
                "Inception"
            };

            // Set the sample data as the ItemsSource for the ComboBox
            filmList.ItemsSource = movieNames;
        }

        private void TimePicker_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            // Get the selected time from the TimePicker
            DateTime? selectedTime = timePicker.SelectedTime;

            // Update UI element with the selected time
            if (selectedTime.HasValue)
            {
                // Assuming you have a Label named 'selectedTimeLabel'
                selectedTimeLabel.Text = selectedTime.Value.ToString("HH:mm");
            }
        }

        private void Button_MouseEnter_1(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;

            btn.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFA5B9D6");
            btn.Background = new SolidColorBrush(Colors.OrangeRed);
        }
        private void Button_MouseLeave_1(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
