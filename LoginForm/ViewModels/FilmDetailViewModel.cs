using LoginForm.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LoginForm.ViewModels
{
    public class FilmDetailViewModel : ViewModelBase
    {
        public ICommand HomeNavigateCommand { get; set; }

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
        public FilmDetailViewModel() {
            GenerateShowtimes();
            HomeNavigateCommand = new NavigateCommand(new Services.NavigationService(App._navigationStore, () => { return new HomePageViewModel(); }));
        }
    }
    public class Showtime
    {
        public string StartTime { get; set; }
    }
}
