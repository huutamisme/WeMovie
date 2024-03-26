using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using WeMovieManager.Commands;

namespace WeMovieManager.ViewModels
{
    public class FilmsManagementViewModel : ViewModelBase
    {
        public ObservableCollection<Movie> MovieList { get; set; }

        private Movie _selectedItem;
        public Movie SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                Trace.WriteLine(value.Name);
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public FilmsManagementViewModel()
        {
            using (var db = new WeMovieEntitiesManager())
            {
                // Initialize your MovieList
                var query = from film in db.Films
                            select new Movie
                            {
                                Name = film.name,
                                Duration = (int)film.duration,
                                Genre = film.genre,
                                DirectorName = (from fd in db.Film_Director
                                                join director in db.Directors on fd.Director_id equals director.id
                                                where fd.Film_id == film.id
                                                select director.name).FirstOrDefault(),
                                Actors = (from fa in db.Film_Actor
                                          join actor in db.Actors on fa.Actor_id equals actor.id
                                          where fa.Film_id == film.id
                                          select actor.name).ToList(),
                                PublishedYear = ((DateTime)film.publishedYear),
                                Summary = film.plotSummary,
                            };

                // Add some example movies
                MovieList = new ObservableCollection<Movie>(query.ToList());

                foreach (var movie in MovieList)
                {
                    movie.ActorNames = string.Join(", ", movie.Actors);
                }

                // Trim the last comma if it exists
                foreach (var movie in MovieList)
                {
                    if (movie.ActorNames.EndsWith(","))
                    {
                        movie.ActorNames = movie.ActorNames.Remove(movie.ActorNames.Length - 1);
                    }
                }
            }
        }

        public class Movie
        {
            public string Name { get; set; }
            public int Duration { get; set; }
            public string Genre { get; set; }
            public string DirectorName { get; set; }
            public List<string> Actors { get; set; }
            public string ActorNames { get; set; }
            public DateTime PublishedYear { get; set; }
            public string Summary { get; set; }

            public RelayCommand editButtonCommand => new RelayCommand(execute =>
            {
                Trace.WriteLine("Edit " + Name);
            }, canExecute => { return true; });
        }
    }
}
