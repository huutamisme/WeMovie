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

namespace WeMovieManager.View
{
    /// <summary>
    /// Interaction logic for FilmManagementView.xaml
    /// </summary>
    public partial class FilmManagementView : UserControl
    {
        public ObservableCollection<Movie> MovieList { get; set; }
        public FilmManagementView()
        {
            InitializeComponent();
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
            DataContext = this;
        }

        private void PencilIcon_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
        }


        private void TrashIcon_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Handle trash icon click event here
        }
    }

    public class Movie
    {
        public string DisplayName { get; set; }
        public string MovieType { get; set; }
        public string Country { get; set; }
        public int RunningTime { get; set; }
    }
}
