using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WeMovieManager.Commands;
using WeMovieManager.Model;
using WeMovieManager.Services;
using WeMovieManager.ViewModels;

namespace WeMovieManager
{
    /// <summary>
    /// Interaction logic for EditFilm.xaml
    /// </summary>
    public partial class EditFilm : Window
    {

        public ObservableCollection<string> ListActor { get; set; }
        public ObservableCollection<string> ListAllActor { get; set; }

        public ObservableCollection<string> ListDirector { get; set; }
        public ObservableCollection<string> ListAllDirector { get; set; }

        public Movie Movie { get; set; }

        public EditFilm(Movie movie)
        {
            InitializeComponent();
            Movie = movie;
            DataContext = this;

            _movieName.Text = movie.Name;
            _IMDb.Text = movie.Rating.ToString();
            _genre.Text = movie.Genre;
            _certification.Text = movie.Cert;
            _movieDuration.Text = movie.Duration.ToString();
            _premier.Text = movie.PublishedYear.ToString();
            _plotSummary.Text = movie.Summary;

            // Khởi tạo danh sách ListActor
            ListActor = new ObservableCollection<string>();
            ListAllActor = new ObservableCollection<string>();
            var resultsActor = from a in App.WeMovieDb.Actors
                               join a_m in App.WeMovieDb.Film_Actor on a.id equals a_m.Actor_id
                               where a_m.Film_id == movie.Id
                               select a;

            foreach (var r in resultsActor)
            {
                ListActor.Add(r.name + "'" + r.id);
            }

            var resultsAllActor = from a2 in App.WeMovieDb.Actors
                                  select a2;
            foreach (var a in resultsAllActor)
            {
                ListAllActor.Add(a.name + "'" + a.id);
            }
            actorList.ItemsSource = ListAllActor;
            // Khởi tạo danh sách ListDirector
            ListDirector = new ObservableCollection<string>();
            ListAllDirector = new ObservableCollection<string>();
            var resultsDirector = from a in App.WeMovieDb.Directors
                               join a_m in App.WeMovieDb.Film_Director on a.id equals a_m.Director_id
                               where a_m.Film_id == movie.Id
                               select a;

            foreach (var r in resultsDirector)
            {
                ListDirector.Add(r.name + "'" + r.id);
            }

            var resultsAllDirector = from a2 in App.WeMovieDb.Directors
                                  select a2;
            foreach (var a in resultsAllDirector)
            {
                ListAllDirector.Add(a.name + "'" + a.id);
            }
            directorList.ItemsSource = ListAllDirector;
        }

        private void actorList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Thêm mục đã chọn từ ComboBox vào ListBox

            string selectedActor = actorList.SelectedItem as string;
            if (selectedActor != null && !(ListActor).Contains(selectedActor))
            {
                ListActor.Add(selectedActor);
            }
        }

        private void RemoveActor_Click(object sender, RoutedEventArgs e)
        {
            // Xóa mục đã chọn khỏi ListBox
            string actorToRemove = (sender as FrameworkElement).DataContext as string;
            if (actorToRemove != null)
            {
                ListActor.Remove(actorToRemove);
            }
        }

        private void directorList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Thêm mục đã chọn từ ComboBox vào ListBox

            string selectedDirector = directorList.SelectedItem as string;
            if (selectedDirector != null)
            {
                ListDirector.Clear();
                ListDirector.Add(selectedDirector);
            }
        }

        private void RemoveDirector_Click(object sender, RoutedEventArgs e)
        {
            // Xóa mục đã chọn khỏi ListBox
            string directorToRemove = (sender as FrameworkElement).DataContext as string;
            if (directorToRemove != null)
            {
                ListDirector.Remove(directorToRemove);
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private static readonly Regex _regex = new Regex("[^0-9]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }


        private void _movieGenre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
            }
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var query = from film in App.WeMovieDb.Films where film.id == Movie.Id select film;
            var result = query.Single();
            result.name = _movieName.Text;
            result.rating = Int32.Parse(_IMDb.Text);
            result.genre = _genre.Text;
            result.certification = _certification.Text;
            result.duration = Int32.Parse(_movieDuration.Text);
            result.publishedYear = DateTime.ParseExact(_premier.Text.Trim(), "d/M/yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
            result.plotSummary = _plotSummary.Text;
            App.WeMovieDb.SaveChanges();

            // delete all actor and add it again
            App.WeMovieDb.Database.ExecuteSqlCommand("DELETE FROM Film_Actor WHERE Film_id = {0}", Movie.Id);

            foreach(string actor in ListActor)
            {
                string[] parts = actor.Split('\'');
                App.WeMovieDb.Database.ExecuteSqlCommand("INSERT Film_Actor(Film_id, Actor_id) VALUES({0}, {1})", Movie.Id, parts[1]);
            }

            App.WeMovieDb.Database.ExecuteSqlCommand("DELETE FROM Film_Director WHERE Film_id = {0}", Movie.Id);

            foreach (string director in ListDirector)
            {
                string[] parts = director.Split('\'');
                App.WeMovieDb.Database.ExecuteSqlCommand("INSERT Film_Director(Film_id, Director_id) VALUES({0}, {1})", Movie.Id, parts[1]);
            }

            ICommand FilmManagementNavigateCommand = new NavigateCommand(new NavigationService(App._navigationStore, () => { return new FilmsManagementViewModel(); }));
            FilmManagementNavigateCommand.Execute(this);
            this.Close();
        }
    }
}
