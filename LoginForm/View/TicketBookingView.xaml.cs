using LoginForm.Commands;
using LoginForm.Models;
using LoginForm.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using Xceed.Wpf.Toolkit.Primitives;

namespace LoginForm.View
{
    /// <summary>
    /// Interaction logic for TicketBookingView.xaml
    /// </summary>
    public partial class TicketBookingView : UserControl
    {
        public int TotalSeat { get; set; }
        public TicketBookingView()
        {
            InitializeComponent();
            DataContext = this;
            PopulateSeatList();
        }

        public ObservableCollection<Seat> ListSeat1 { get; set; } = new ObservableCollection<Seat>();
        public int showId { get; set; }
        public int filmId { get; set; }
        public string filmName { get; set; }
        public string filmImg {  get; set; }
        public string showDate { get; set; }
        public string showTime { get; set; }
        public int price { get; set; }

        public int total { get; set; }

        private void PopulateSeatList()
        {
            showId = App.showId;
            totalSeats.Content = 0;
            var showQuery = from show in App.WeMovieDb.Showtimes where show.id == showId select show;
            var showResult = showQuery.Single();

            var filmQuery = from film in App.WeMovieDb.Films where film.id == showResult.Film select film;
            var filmResult = filmQuery.Single();

            string packUri = "pack://application:,,,/LoginForm;component" + filmResult.poster;

            imgToBind.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;

            filmId = filmResult.id;
            filmName = filmResult.name;
            filmImg = filmResult.poster;
            showTime = showResult.time.ToString();
            showDate = showResult.date.ToString();


            price = (int)showResult.price;
            filmNameToBind.Content = filmResult.name;
            priceToBind.Content = showResult.price;
            showTimeToBind.Content = showResult.time.ToString() + " " + showResult.date.Value.Date;
            Trace.WriteLine(showResult.time.ToString() + " " + showResult.date.Value.Date);
            var query = from seat in App.WeMovieDb.Seats orderby seat.id where seat.Showtime == showId select new { SeatId = seat.id, IsReserved = seat.status };
            var results = query.ToList();
            char row = 'A';
            int count = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 1; j <= 14; j++)
                {
                    string seatPosition = $"{row}{j}";
                    ListSeat1.Add(new Seat { SeatPosition = seatPosition, SeatId = results[count].SeatId,
                        IsReserved = results[count].IsReserved.Trim() == "NotTaken" ? "False" : "True" });
                    count++;
                }
                row++;
            }
        }

        private void SeatListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TotalSeat = SeatListBox1.SelectedItems.Count;
            totalSeats.Content = TotalSeat;
            totalToBind.Content = TotalSeat * price;
            total = TotalSeat * price;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!App.isLoggedIn)
            {
                Login login = new Login();
                login.Show();
            }
            else
            {
                
                App.payment = new Payment() { showId = showId, filmId = filmId, filmName = filmName, price = price, showDate = showDate , showTime = showTime,
                total = total, poster = filmImg};
                foreach (Seat seat in SeatListBox1.SelectedItems)
                {
                    App.payment.seats.Add(seat.SeatId);
                }
                NavigateCommand PaymentNavigateCommand = new NavigateCommand(new Services.NavigationService(App._navigationStore, () => { return new PaymentViewModel(); }));
                PaymentNavigateCommand.Execute(this);
            }
        }
    }
    public class Seat
    {
        public string SeatPosition { get; set; }
        public int SeatId { get; set; }

        public string IsReserved { get; set; }
    }
}
