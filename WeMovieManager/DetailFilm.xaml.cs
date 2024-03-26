using System.Windows;
using WeMovieManager.ViewModels;

namespace WeMovieManager
{
    /// <summary>
    /// Interaction logic for DetailFilm.xaml
    /// </summary>
    public partial class DetailFilm : Window
    {
        // Receive the selected film from FilmManagementView
        private FilmsManagementViewModel.Movie selectedFilm;

        public DetailFilm(FilmsManagementViewModel.Movie selectedMovie)
        {
            InitializeComponent();

            // Set the selected film as DataContext
            selectedFilm = selectedMovie;
            DataContext = selectedFilm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
