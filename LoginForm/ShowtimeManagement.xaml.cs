using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class ShowtimeManagement : Window
    {
        public ObservableCollection<MovieViewModel> MovieList { get; set; }

        public ShowtimeManagement()
        {
            InitializeComponent();
            DataContext = this;

            // Initialize the MovieList with sample data
            MovieList = new ObservableCollection<MovieViewModel>()
            {
                new MovieViewModel
                {
                    DisplayName = "Movie 1",
                    RunningTime = "150 minutes",
                    Showtimes = new ObservableCollection<ShowtimeModel>
                    {
                        new ShowtimeModel { StartTime = "10:00 AM" },
                        new ShowtimeModel { StartTime = "1:00 PM" },
                        new ShowtimeModel { StartTime = "4:00 PM" },
                        new ShowtimeModel { StartTime = "4:00 PM" },
                        new ShowtimeModel { StartTime = "4:00 PM" }
                    }
                },
                new MovieViewModel
                {
                    DisplayName = "Movie 2",
                    RunningTime = "2h 15m",
                    Showtimes = new ObservableCollection<ShowtimeModel>
                    {
                        new ShowtimeModel { StartTime = "11:00 AM" },
                        new ShowtimeModel { StartTime = "2:00 PM" },
                        new ShowtimeModel { StartTime = "5:00 PM" }
                    }
                },
                // Add more sample movies as needed
            };
        }
    }

    public class ShowtimeModel
    {
        public string StartTime { get; set; }
    }

    public class MovieViewModel
    {
        public string DisplayName { get; set; }
        public string RunningTime { get; set; }
        public ObservableCollection<ShowtimeModel> Showtimes { get; set; }
    }
}





