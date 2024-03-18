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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoginForm.View
{
    /// <summary>
    /// Interaction logic for FilmDetailView.xaml
    /// </summary>
    public partial class FilmDetailView : UserControl
    {
        public FilmDetailView()
        {
            InitializeComponent();
            DataContext = this;
            GenerateShowtimes();
        }
        public ObservableCollection<Showtime> Showtimes { get; set; } = new ObservableCollection<Showtime>();

        private void GenerateShowtimes()
        {
            Showtimes.Add(new Showtime { StartTime = "10:00" });
            Showtimes.Add(new Showtime { StartTime = "11:30" });
            Showtimes.Add(new Showtime { StartTime = "13:00" });
            Showtimes.Add(new Showtime { StartTime = "14:30" });
            Showtimes.Add(new Showtime { StartTime = "16:00" });
            Showtimes.Add(new Showtime { StartTime = "17:30" });
            Showtimes.Add(new Showtime { StartTime = "19:00" });
            Showtimes.Add(new Showtime { StartTime = "20:30" });
            Showtimes.Add(new Showtime { StartTime = "22:00" });
        }
    }

    public class Showtime
    {
        public string StartTime { get; set; }
    }
}
