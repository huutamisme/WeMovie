using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace WeMovieManager.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        public static WeMovieEntitiesManager db = new WeMovieEntitiesManager();

        private ObservableCollection<GrossingFilm> _grossingFilmList;
        public ObservableCollection<GrossingFilm> GrossingFilmList
        {
            get => _grossingFilmList;
            set
            {
                _grossingFilmList = value;
                OnPropertyChanged(nameof(GrossingFilmList));
            }
        }

        private int _totalFilms;
        public int TotalFilms
        {
            get => _totalFilms;
            set
            {
                _totalFilms = value;
                OnPropertyChanged(nameof(TotalFilms));
            }
        }

        private int _totalShowtimes;
        public int TotalShowtimes
        {
            get => _totalShowtimes;
            set
            {
                _totalShowtimes = value;
                OnPropertyChanged(nameof(TotalShowtimes));
            }
        }

        // public int TotalRevenue { get; set; }
        public void calculateTotalFilms(DateTime startDate, DateTime endDate)
        {
            // DateTime today = DateTime.Today;

            TotalFilms = 0;
            var showtimes = db.Showtimes
                .Where(showtime => showtime.date >= startDate && showtime.date <= endDate)
                .Select(showtime => showtime.Film)
                .Distinct()
                .ToList();

            int total = showtimes.Count();
            Debug.WriteLine("total " + total);
            TotalFilms = total;
        }
        public void calculateTotalShowtimes(DateTime startDate, DateTime endDate)
        {
            // DateTime today = DateTime.Today;

            int total = db.Showtimes.Count(showtime => showtime.date >= startDate && showtime.date <= endDate);
            Debug.WriteLine("total " + total);
            TotalShowtimes = total;
        }
        public void getMostGrossingFilms(DateTime startDate, DateTime endDate)
        {
            // DateTime today = DateTime.Today;

            var query = (from ticket in App.WeMovieDb.Tickets
                         join showtime in App.WeMovieDb.Showtimes on ticket.Showtime equals showtime.id
                         join film in App.WeMovieDb.Films on showtime.Film equals film.id
                         where showtime.date >= startDate && showtime.date <= endDate
                         group ticket by film.name into filmGroup
                         let totalGross = filmGroup.Sum(ticket => (int)ticket.price)
                         orderby totalGross descending
                         select new GrossingFilm
                         {
                             FilmName = filmGroup.Key,
                             FilmGross = totalGross
                         }).Take(3).ToList();

            GrossingFilmList = new ObservableCollection<GrossingFilm>(query.ToList());

            if (GrossingFilmList.Count == 0)
            {
                var newQuery = (from film in App.WeMovieDb.Films
                                select new GrossingFilm
                                {
                                    FilmName = film.name,
                                    FilmGross = 0
                                }).Take(3).ToList();

                GrossingFilmList = new ObservableCollection<GrossingFilm>(newQuery.ToList());
            }
            if (GrossingFilmList.Count == 1)
            {
                var newQuery = (from film in App.WeMovieDb.Films
                                select new GrossingFilm
                                {
                                    FilmName = film.name,
                                    FilmGross = 0
                                }).Take(2);

                foreach (var item in newQuery)
                {
                    GrossingFilmList.Add(item);
                }
            }
            if (GrossingFilmList.Count == 2)
            {
                var newQuery = (from film in App.WeMovieDb.Films
                                select new GrossingFilm
                                {
                                    FilmName = film.name,
                                    FilmGross = 0
                                }).Take(1);

                foreach (var item in newQuery)
                {
                    GrossingFilmList.Add(item);
                }
            }

            // Debug.WriteLine("grossing film " + GrossingFilmList[0].FilmGross);
        }

        //public void getProfit(DateTime startDate, DateTime endDate)
        //{
        //    // DateTime today = DateTime.Today;

        //    int totalRevenue = (int)(from ticket in db.Tickets
        //                             join showtime in db.Showtimes on ticket.Showtime equals showtime.id
        //                             where showtime.date >= startDate && showtime.date <= endDate
        //                             select ticket.price).Sum();

        //    TotalRevenue = totalRevenue;
        //}

        public DashboardViewModel()
        {
            DateTime today = DateTime.Today;

            calculateTotalFilms(today.AddYears(-1), today);
            calculateTotalShowtimes(today.AddYears(-1), today);
            getMostGrossingFilms(today.AddYears(-1), today);
            // getProfit(today.AddYears(-1), today);
        }
        public class GrossingFilm
        {
            public string FilmName { get; set; }
            public int FilmGross { get; set; }
        }
    }
}
