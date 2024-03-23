using LoginForm.Commands;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;

namespace LoginForm.ViewModels
{
    public class FilmDetailViewModel : ViewModelBase
    {
        public static WeMovieEntities db = new WeMovieEntities();
        public ICommand HomeNavigateCommand { get; set; }
        private Film _film;
        public int id
        {
            get
            {
                return _film.id;
            }
        }
        public string name
        {
            get
            {
                return _film.name;
            }
        }

        public int duration
        {
            get
            {
                return (int)_film.duration;
            }
        }

        public string poster
        {
            get
            {
                return _film.poster;
            }
        }

        public string genre
        {
            get
            {
                return _film.genre;
            }
        }
        public ObservableCollection<Showtime> Showtimes { get; set; } = new ObservableCollection<Showtime>();

        private void GenerateShowtimes()
        {

            using (var db = new WeMovieEntities())
            {
                var showtimes = db.Showtimes.Where(s => s.Film == _film.id).ToList();
                Debug.WriteLine("count " + showtimes.Count);
                foreach (var showtime in showtimes)
                {
                    Debug.WriteLine("check " + showtime.time);
                    Showtimes.Add(showtime);
                }
            }
        }
        public FilmDetailViewModel(Film film)
        {
            _film = film;
            GenerateShowtimes();
            HomeNavigateCommand = new NavigateCommand(new Services.NavigationService(App._navigationStore, () => { return new HomePageViewModel(); }));
        }
    }
    //public class Showtime
    //{
    //    public string StartTime { get; set; }
    //}
}
