using System.Windows.Controls;
using System.Windows.Input;
using WeMovieManager.ViewModels;

namespace WeMovieManager.View
{
    /// <summary>
    /// Interaction logic for FilmManagementView.xaml
    /// </summary>
    public partial class FilmManagementView : UserControl
    {
        public FilmManagementView()
        {
            InitializeComponent();
            // Initialize your MovieList

        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Retrieve the selected movie
            FilmsManagementViewModel.Movie selectedMovie = (FilmsManagementViewModel.Movie)MovieListView.SelectedItem;

            if (selectedMovie != null)
            {
                // Open the detail film view with the selected movie
                DetailFilm df = new DetailFilm(selectedMovie);
                df.Show();
            }
        }
    }


}
