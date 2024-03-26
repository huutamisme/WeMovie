using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WeMovieManager.View
{
    /// <summary>
    /// Interaction logic for ReportView.xaml
    /// </summary>
    public partial class ReportView : UserControl
    {
        private Dictionary<string, int> movieDictionary;
        private static WeMovieEntities db = new WeMovieEntities();

        public static readonly DependencyProperty NumberOfFilmsProperty =
        DependencyProperty.Register("NumberOfFilms", typeof(int), typeof(ReportView), new PropertyMetadata(0));

        public int numberOfFilms
        {
            get { return (int)GetValue(NumberOfFilmsProperty); }
            set { SetValue(NumberOfFilmsProperty, value); }
        }

        //private Dictionary<string, int> movieDictionary = new Dictionary<string, int>
        //{
        //    { "Phim 1", 10 },
        //    { "Phim 2", 20 },
        //    { "Phim 3", 15 },
        //    { "Phim 4", 25 },
        //    { "Phim 5", 18 },
        //    { "Phim 6", 12 },
        //    { "Phim 7", 30 },
        //    { "Phim 8", 22 },
        //    { "Phim 9", 17 },
        //    { "Phim 10", 28 },
        //    { "Phim 11", 13 },
        //    { "Phim 12", 23 },
        //    { "Phim 13", 19 },
        //    { "Phim 14", 27 },
        //    { "Phim 15", 16 },
        //    { "Phim 16", 21 },
        //    { "Phim 17", 24 },
        //    { "Phim 18", 14 },
        //    { "Phim 19", 29 },
        //    { "Phim 20", 26 },
        //    { "Phim 21", 11 },
        //    { "Phim 22", 31 },
        //    { "Phim 23", 36 },
        //    { "Phim 24", 40 },
        //    { "Phim 25", 35 },
        //    { "Phim 26", 39 },
        //    { "Phim 27", 33 },
        //    { "Phim 28", 37 },
        //    { "Phim 29", 34 },
        //    { "Phim 30", 38 }
        //};

        public void LoadMovieDictionary(string filter)
        {
            DateTime startDate;
            DateTime endDate = DateTime.Today;

            switch (filter)
            {
                case "Day":
                    startDate = DateTime.Today.AddDays(-1); // From yesterday till now
                    break;
                case "Week":
                    startDate = DateTime.Today.AddDays(-7); // Last 7 days till now
                    break;
                case "Month":
                    startDate = DateTime.Today.AddDays(-30); // Last 30 days till now
                    break;
                case "Year":
                    startDate = DateTime.Today.AddYears(-1); // Last year till now
                    break;
                default:
                    startDate = DateTime.MinValue; // Load all data
                    break;
            }

            numberOfFilms = db.Films.Count();
            Debug.WriteLine("number " + numberOfFilms);

            movieDictionary = (from film in db.Films
                               join showtime in db.Showtimes on film.id equals showtime.Film
                               where showtime.date >= startDate && showtime.date <= endDate
                               group showtime by film.name into filmGroup
                               select new
                               {
                                   FilmName = filmGroup.Key,
                                   ShowtimeCount = filmGroup.Count()
                               })
                          .ToDictionary(item => item.FilmName, item => item.ShowtimeCount);
        }

        public ReportView()
        {
            InitializeComponent();

            DataContext = this;

            LoadListBox();
            UpdatePieChart();
        }



        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void LoadListBox()
        {
            LoadMovieDictionary("");

            foreach (string movieName in movieDictionary.Keys)
            {
                phimListBox.Items.Add(movieName);
            }
        }

        private void UpdatePieChart()
        {
            pieChart.Series = new SeriesCollection();

            foreach (string selectedMovie in phimListBox.SelectedItems)
            {
                if (movieDictionary.ContainsKey(selectedMovie))
                {
                    pieChart.Series.Add(new PieSeries
                    {
                        Title = selectedMovie,
                        Values = new ChartValues<int> { movieDictionary[selectedMovie] }
                    });
                }
            }
        }

        private void phimListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdatePieChart();
        }

        private void Filter_By_Day(object sender, RoutedEventArgs e)
        {
            LoadMovieDictionary("Day");
            UpdatePieChart();
        }

        private void Filter_By_Week(object sender, RoutedEventArgs e)
        {
            LoadMovieDictionary("Week");
            UpdatePieChart();
        }

        private void Filter_By_Month(object sender, RoutedEventArgs e)
        {
            LoadMovieDictionary("Month");
            UpdatePieChart();
        }

        private void Filter_By_Year(object sender, RoutedEventArgs e)
        {
            LoadMovieDictionary("Year");
            UpdatePieChart();
        }
    }
}
