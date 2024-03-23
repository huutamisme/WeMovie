using System.Collections.ObjectModel;
using System.Windows;

namespace LoginForm
{
    /// <summary>
    /// Interaction logic for FilmDetail.xaml
    /// </summary>
    public partial class FilmDetail : Window
    {

        public FilmDetail()
        {
            InitializeComponent();
            DataContext = this;
            GenerateShowtimes();
        }
        public ObservableCollection<Showtime> Showtimes { get; set; } = new ObservableCollection<Showtime>();

        private void GenerateShowtimes()
        {
            //Showtimes.Add(new Showtime { StartTime = "10:00" });
            //Showtimes.Add(new Showtime { StartTime = "11:30" });
            //Showtimes.Add(new Showtime { StartTime = "13:00" });
            //Showtimes.Add(new Showtime { StartTime = "14:30" });
            //Showtimes.Add(new Showtime { StartTime = "16:00" });
            //Showtimes.Add(new Showtime { StartTime = "17:30" });
            //Showtimes.Add(new Showtime { StartTime = "19:00" });
            //Showtimes.Add(new Showtime { StartTime = "20:30" });
            //Showtimes.Add(new Showtime { StartTime = "22:00" });
        }
    }

    //public class Showtime
    //{
    //    public string StartTime { get; set; }
    //}
}
