﻿using LoginForm.Commands;
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
                if (_film.certification != "P")
                {
                    string resultString = Regex.Match(_film.certification, @"\d+").Value;
                    return "Phim dành cho khán giả từ " + resultString + " tuổi trở lên";
                }
                else
                {
                    return "Phim dành cho khán giả mọi lứa tuổi";
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
        public string listActors
        {
            get
            {
                // B1: lấy ra những bảng film_actor có film_id = _film.id
                // B2: lấy ra actor.id của bảng film_actor, sau đó tìm những actor có id = film_actor.id
                string actorsString = "";
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
                        if (actor != null)
                        {
                            actorsString += actor.name + ", ";
                        }
                    }
                }

                return actorsString.Substring(0, actorsString.Length - 2);
            }
        }
        public string listDirectors
        {
            get
            {
                // B1: lấy ra những bảng film_actor có film_id = _film.id
                // B2: lấy ra actor.id của bảng film_actor, sau đó tìm những actor có id = film_actor.id
                string directorsString = "";
                using (var db = new WeMovieEntities())
                {
                    var filmDirectors = db.Film_Director
                                        .Where(fd => fd.Film_id == _film.id)
                                        .ToList();
                    foreach (var filmDirector in filmDirectors)
                    {
                        Debug.WriteLine("actor id " + filmDirector.Director_id);
                        var id = filmDirector.Director_id;
                        var director = db.Directors.FirstOrDefault(d => d.id == id);
                        if (director != null)
                        {
                            directorsString += director.name + ", ";
                        }
                    }
                }

                return directorsString.Substring(0, directorsString.Length - 2);
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
}
