using LoginForm.Commands;
using LoginForm.Models;
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
        private Film _film;

        public string FilmTitle
        {
            get
            {
                return _film.FilmTitle;
            }
        }

        public string Duration
        {
            get
            {
                return _film.Duration;
            }
        }

        public string ThumbnailPath
        {
            get
            {
                return _film.ThumbnailPath;
            }
        }

        public string Genre
        {
            get
            {
                return _film.Genre;
            }
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
        public FilmDetailViewModel(Film film) {
            _film = film;
            GenerateShowtimes();
            HomeNavigateCommand = new NavigateCommand(new Services.NavigationService(App._navigationStore, () => { return new HomePageViewModel(); }));
        }
    }
    public class Showtime
    {
        public string StartTime { get; set; }
    }
}
