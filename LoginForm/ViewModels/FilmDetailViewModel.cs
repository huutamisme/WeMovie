using LoginForm.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
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

        // T18, T16,... Phim dành cho khán giả trên 18, 16t
        // P: Phim dành cho khán giả mọi lứa tuổi
        public string certificationStatement
        {
            get
            {
                if (_film.certification != "P" && _film.certification != "K")
                {
                    string resultString = Regex.Match(_film.certification, @"\d+").Value;
                    return "Movie for audiences from " + resultString + " years of age or older";
                }
                if (_film.certification == "K")
                {
                    string resultString = Regex.Match(_film.certification, @"\d+").Value;
                    return "Movie for audiences under " + resultString + " years of age with parents's guidance";
                }
                else
                {
                    return "Movie for all audiences";
                }
            }
        }
        public string certification
        {
            get
            {
                return _film.certification;
            }
        }
        public List<Actor> actors
        {
            get
            {
                // B1: lấy ra những bảng film_actor có film_id = _film.id
                // B2: lấy ra actor.id của bảng film_actor, sau đó tìm những actor có id = film_actor.id
                List<Actor> result = new List<Actor>();
                using (var db = new WeMovieEntities())
                {
                    var filmActors = db.Film_Actor
                                        .Where(fa => fa.Film_id == _film.id)
                                        .ToList();
                    foreach (var filmActor in filmActors)
                    {
                        Debug.WriteLine("actor id " + filmActor.Actor_id);
                        var id = filmActor.Actor_id;
                        var actor = db.Actors.FirstOrDefault(a => a.id == id);
                        result.Add(actor);
                    }
                }

                return result;
            }
        }
        public Director director
        {
            get
            {
                using (var db = new WeMovieEntities())
                {
                    var filmDirector = db.Film_Director
                                        .Where(fd => fd.Film_id == _film.id).FirstOrDefault();
                    Debug.WriteLine("actor id " + filmDirector.Director_id);
                    var id = filmDirector.Director_id;
                    var director = db.Directors.FirstOrDefault(d => d.id == id);
                    Debug.WriteLine("director " + director.name);
                    return director;

                }
            }
        }

        public string firstActorImage
        {
            get
            {
                using (var db = new WeMovieEntities())
                {
                    var filmActors = db.Film_Actor
                                        .Where(fd => fd.Film_id == _film.id)
                                        .ToList();
                    int i = 0;
                    foreach (var filmActor in filmActors)
                    {
                        Debug.WriteLine("actor id " + filmActor.Actor_id);
                        var id = filmActor.Actor_id;
                        var actor = db.Actors.FirstOrDefault(d => d.id == id);
                        if (i == 0)
                        {
                            return actor.avatar;
                        }
                        i++;
                    }
                }
                return "";
            }
        }

        public string secondActorImage
        {
            get
            {
                using (var db = new WeMovieEntities())
                {
                    var filmActors = db.Film_Actor
                                        .Where(fd => fd.Film_id == _film.id)
                                        .ToList();
                    int i = 0;
                    foreach (var filmActor in filmActors)
                    {
                        Debug.WriteLine("actor id " + filmActor.Actor_id);
                        var id = filmActor.Actor_id;
                        var actor = db.Actors.FirstOrDefault(d => d.id == id);
                        if (i == 1)
                        {
                            return actor.avatar;
                        }
                        i++;
                    }
                }
                return "";
            }
        }

        public string thirdActorImage
        {
            get
            {
                using (var db = new WeMovieEntities())
                {
                    var filmActors = db.Film_Actor
                                        .Where(fd => fd.Film_id == _film.id)
                                        .ToList();
                    int i = 0;
                    foreach (var filmActor in filmActors)
                    {
                        Debug.WriteLine("actor id " + filmActor.Actor_id);
                        var id = filmActor.Actor_id;
                        var actor = db.Actors.FirstOrDefault(d => d.id == id);
                        if (i == 2)
                        {
                            return actor.avatar;
                        }
                        i++;
                    }
                }
                return "";
            }
        }

        public string firstActorBio
        {
            get
            {
                using (var db = new WeMovieEntities())
                {
                    var filmActors = db.Film_Actor
                                        .Where(fd => fd.Film_id == _film.id)
                                        .ToList();
                    int i = 0;
                    foreach (var filmActor in filmActors)
                    {
                        Debug.WriteLine("actor id " + filmActor.Actor_id);
                        var id = filmActor.Actor_id;
                        var actor = db.Actors.FirstOrDefault(d => d.id == id);
                        if (i == 0)
                        {
                            return actor.biography;
                        }
                        i++;
                    }
                }
                return "";
            }
        }

        public string secondActorBio
        {
            get
            {
                using (var db = new WeMovieEntities())
                {
                    var filmActors = db.Film_Actor
                                        .Where(fd => fd.Film_id == _film.id)
                                        .ToList();
                    int i = 0;
                    foreach (var filmActor in filmActors)
                    {
                        Debug.WriteLine("actor id " + filmActor.Actor_id);
                        var id = filmActor.Actor_id;
                        var actor = db.Actors.FirstOrDefault(d => d.id == id);
                        if (i == 1)
                        {
                            return actor.biography;
                        }
                        i++;
                    }
                }
                return "";
            }
        }

        public string thirdActorBio
        {
            get
            {
                using (var db = new WeMovieEntities())
                {
                    var filmActors = db.Film_Actor
                                        .Where(fd => fd.Film_id == _film.id)
                                        .ToList();
                    int i = 0;
                    foreach (var filmActor in filmActors)
                    {
                        Debug.WriteLine("actor id " + filmActor.Actor_id);
                        var id = filmActor.Actor_id;
                        var actor = db.Actors.FirstOrDefault(d => d.id == id);
                        if (i == 2)
                        {
                            return actor.biography;
                        }
                        i++;
                    }
                }
                return "";
            }
        }


        public string publishedYear
        {
            get
            {
                return _film.publishedYear.Value.Date.ToString("MM/dd/yyyy");
            }
        }
        public string plotSummary
        {
            get
            {
                return _film.plotSummary;
            }
        }

        public ObservableCollection<ShowTimeDTO> Showtimes { get; set; } = new ObservableCollection<ShowTimeDTO>();

        private void GenerateShowtimes()
        {
            using (var db = new WeMovieEntities())
            {
                var showtimes = db.Showtimes.Where(s => s.Film == _film.id).ToList();
                foreach (var showtime in showtimes)
                {
                    Debug.WriteLine("check " + showtime.time);
                    Showtimes.Add(new ShowTimeDTO { time = showtime.time.ToString(), id = showtime.id, filmDetail = this });
                }
            }
        }

        public void NavigateToBooking()
        {
            ICommand BookingNavigateCommand = new NavigateCommand(new Services.NavigationService(App._navigationStore, () => { return new TicketBookingViewModel(); }));
            BookingNavigateCommand.Execute(this);
        }

        public FilmDetailViewModel(Film film)
        {
            _film = film;
            GenerateShowtimes();
            HomeNavigateCommand = new NavigateCommand(new Services.NavigationService(App._navigationStore, () => { return new HomePageViewModel(); }));
        }

        public class ShowTimeDTO
        {
            public string time { get; set; }
            public int id { get; set; }

            public FilmDetailViewModel filmDetail { get; set; }

            public RelayCommand ShowTimeClickedCommand => new RelayCommand(execute =>
            {
                App.showId = id;
                filmDetail.NavigateToBooking();
            }, canExecute => { return true; });
        }
    }
}
