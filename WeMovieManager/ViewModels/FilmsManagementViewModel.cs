using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeMovieManager.Commands;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
                Trace.WriteLine(value.DisplayName);
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public FilmsManagementViewModel()
        {
            // Initialize your MovieList
            

            var query = from film in App.WeMovieDb.Films
                        select new Movie { DisplayName = film.name, MovieType = film.genre, Country = "Ko co", RunningTime = (int)film.duration };

            // Add some example movies
            MovieList = new ObservableCollection<Movie>(query.ToList());

            // Set the DataContext to this instance (for binding)
        }

        public class Movie
        {
            public string DisplayName { get; set; }
            public string MovieType { get; set; }
            public string Country { get; set; }
            public int RunningTime { get; set; }

            public RelayCommand editButtonCommand => new RelayCommand(execute =>
            {
                Trace.WriteLine("Edit " + DisplayName);
            }, canExecute => { return true; });
        }
    }
}
