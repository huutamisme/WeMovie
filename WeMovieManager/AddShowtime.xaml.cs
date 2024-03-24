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
using WeMovieManager.Services;
using WeMovieManager.ViewModels;

namespace WeMovieManager
{
    /// <summary>
    /// Interaction logic for AddShowtime.xaml
    /// </summary>
    public partial class AddShowtime : Window
    {
        public List<int> ids = new List<int>();
        public List<string> movieNames = new List<string>();
        public AddShowtime()
        {
            var query = from film in App.WeMovieDb.Films select new { Name = film.name, id = film.id };
            var results = query.ToList();
            InitializeComponent();
            foreach (var movie in results)
            {
                ids.Add(movie.id);
                movieNames.Add(movie.Name);
            }

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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void filmList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = filmList.SelectedIndex;
            Trace.WriteLine(movieNames[index]);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (timePicker.SelectedTime.ToString().Length == 0)
            {
                MessageBox.Show("Please input show time", "Error");
            }
            else if(_moviePrice.Text.Length == 0)
            {
                MessageBox.Show("Please input ticket price", "Error");
            }
            else if(_movieDate.Text.Length == 0)
            {
                MessageBox.Show("Please input show date", "Error");
            }
            else
            {
                Showtime toBeInserted = new Showtime
                {
                    Film = ids[filmList.SelectedIndex],
                    time = timePicker.SelectedTime.Value.TimeOfDay,
                    date = _movieDate.DisplayDate.Date,
                    price = Int32.Parse(_moviePrice.Text),
                    seatQuantities = 112
                };

                int showId = App.WeMovieDb.Database.SqlQuery<int>("INSERT Showtime(time, date, Film, price, seatQuantities) " 
                                                        + "VALUES({0},{1}, {2}, {3}, {4}); SELECT CAST(SCOPE_IDENTITY() AS INT)"
                                                        , toBeInserted.time, toBeInserted.date, toBeInserted.Film, toBeInserted.price, toBeInserted.seatQuantities).Single();
                App.WeMovieDb.SaveChanges();
                for(int i = 1; i <= 112; i++)
                {
                    Seat seat = new Seat
                    {
                        status = "NotTaken",
                        Showtime = showId
                    };
                    App.WeMovieDb.Database.ExecuteSqlCommand("INSERT Seat(status, Showtime) "
                                                        + "VALUES({0},{1})"
                                                        , seat.status, seat.Showtime);
                    App.WeMovieDb.SaveChanges();
                }
                ICommand ShowTimeManagementNavigateCommand = new NavigateCommand(new NavigationService(App._navigationStore, () => { return new ShowTimeManagementViewModel(); }));
                ShowTimeManagementNavigateCommand.Execute(this);
                this.Close();
            }
        }
    }
}
