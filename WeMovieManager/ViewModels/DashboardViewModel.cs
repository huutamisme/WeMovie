using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace WeMovieManager.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        public static WeMovieEntitiesManager db = new WeMovieEntitiesManager();
        public ObservableCollection<GrossingFilm> GrossingFilmList { get; set; }
        public int TotalFilms { get; set; }
        public int TotalShowtimes { get; set; }
        public int TotalRevenue { get; set; }
        public void calculateTotalFilms()
        {
            DateTime today = DateTime.Today;

            TotalFilms = 0;
            var showtimes = db.Showtimes
                .Where(showtime => showtime.date < today)
                .Select(showtime => showtime.Film)
                .Distinct()
                .ToList();

            int total = showtimes.Count();
            Debug.WriteLine("total " + total);
            TotalFilms = total;
        }
        public void calculateTotalShowtimes()
        {
            DateTime today = DateTime.Today;

            int total = db.Showtimes.Count(showtime => showtime.date < today);
            Debug.WriteLine("total " + total);
            TotalShowtimes = total;
        }
        public void getMostGrossingFilms()
        {
            DateTime today = DateTime.Today;

            var query = (from ticket in App.WeMovieDb.Tickets
                         join showtime in App.WeMovieDb.Showtimes on ticket.Showtime equals showtime.id
                         join film in App.WeMovieDb.Films on showtime.Film equals film.id
                         where showtime.date < today
                         group ticket by film.name into filmGroup
                         let totalGross = filmGroup.Sum(ticket => (int)ticket.price)
                         orderby totalGross descending
                         select new GrossingFilm
                         {
                             FilmName = filmGroup.Key,
                             FilmGross = totalGross
                         }).Take(3).ToList();

            GrossingFilmList = new ObservableCollection<GrossingFilm>(query.ToList());

            Debug.WriteLine("grossing film " + GrossingFilmList);
        }

        public void getProfit()
        {
            DateTime today = DateTime.Today;

            int totalRevenue = (int)(from ticket in db.Tickets
                                     join showtime in db.Showtimes on ticket.Showtime equals showtime.id
                                     where showtime.date < today
                                     select ticket.price).Sum();

            TotalRevenue = totalRevenue;
        }
        public DashboardViewModel()
        {
            calculateTotalFilms();
            calculateTotalShowtimes();
            getMostGrossingFilms();
            getProfit();
        }
        public class GrossingFilm
        {
            public string FilmName { get; set; }
            public int FilmGross { get; set; }
        }
    }
}
