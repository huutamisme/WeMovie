using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using WeMovieManager.Commands;
using WeMovieManager.Model;
using WeMovieManager.Services;
using WeMovieManager.ViewModels;

namespace WeMovieManager
{
    /// <summary>
    /// Interaction logic for EditShowtime.xaml
    /// </summary>
    public partial class EditShowtime : Window
    {
        ShowtimeDTO showtimeDTO;
        public EditShowtime(ShowtimeDTO showtime)
        {
            showtimeDTO = showtime;
            InitializeComponent();
            movieToBind.Text = showtime.FilmName;
            priceToBind.Text = showtime.Price.ToString();
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DeleteShowtime_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxCustom mb = new MessageBoxCustom("Confirm", "Are you sure to delete this showtime?", MessageType.Warning, MessageButtons.YesNo);
            mb.Show();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var query = from showtime in App.WeMovieDb.Showtimes where showtime.id == showtimeDTO.Id select showtime;
            var result = query.Single();
            result.price = Int32.Parse(priceToBind.Text);
            if(_movieDate.Text.Length > 0)
            {
                result.date = _movieDate.DisplayDate.Date;
            }
            if (timePicker.SelectedTime.ToString().Length > 0)
            {
                result.time = timePicker.SelectedTime.Value.TimeOfDay;
            }
            App.WeMovieDb.SaveChanges();

            ICommand ShowtimeCommand = new NavigateCommand(new NavigationService(App._navigationStore, () => { return new ShowTimeManagementViewModel(); }));
            ShowtimeCommand.Execute(this);
            this.Close();
        }
    }
}
