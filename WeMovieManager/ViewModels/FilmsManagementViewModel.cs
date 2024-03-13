using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            MovieList = new ObservableCollection<Movie>();

            // Add some example movies
            MovieList.Add(new Movie { DisplayName = "Movie 1", MovieType = "Type 1", Country = "Country 1", RunningTime = 120 });
            MovieList.Add(new Movie { DisplayName = "Movie 2", MovieType = "Type 2", Country = "Country 2", RunningTime = 90 });
            MovieList.Add(new Movie { DisplayName = "Movie 3", MovieType = "Type 3", Country = "Country 3", RunningTime = 150 });
            MovieList.Add(new Movie { DisplayName = "Movie 3", MovieType = "Type 3", Country = "Country 3", RunningTime = 150 });
            MovieList.Add(new Movie { DisplayName = "Movie 3", MovieType = "Type 3", Country = "Country 3", RunningTime = 150 });
            MovieList.Add(new Movie { DisplayName = "Movie 3", MovieType = "Type 3", Country = "Country 3", RunningTime = 150 });
            MovieList.Add(new Movie { DisplayName = "Movie 3", MovieType = "Type 3", Country = "Country 3", RunningTime = 150 });
            MovieList.Add(new Movie { DisplayName = "Movie 3", MovieType = "Type 3", Country = "Country 3", RunningTime = 150 });
            MovieList.Add(new Movie { DisplayName = "Movie 3", MovieType = "Type 3", Country = "Country 3", RunningTime = 150 });
            MovieList.Add(new Movie { DisplayName = "Movie 3", MovieType = "Type 3", Country = "Country 3", RunningTime = 150 });

            // Set the DataContext to this instance (for binding)
        }

        public class Movie
        {
            public string DisplayName { get; set; }
            public string MovieType { get; set; }
            public string Country { get; set; }
            public int RunningTime { get; set; }
        }
    }
}
