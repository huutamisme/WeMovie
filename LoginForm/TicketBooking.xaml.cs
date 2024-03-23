using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace LoginForm
{
    /// <summary>
    /// Interaction logic for TicketBooking.xaml
    /// </summary>
    public partial class TicketBooking : Window
    {
        public static WeMovieEntities db = new WeMovieEntities();
        public TicketBooking()
        {
            InitializeComponent();
            DataContext = this;
            PopulateSeatList();
        }

        public ObservableCollection<Seat> ListSeat1 = new ObservableCollection<Seat>(db.Seats.ToList());
        // public ObservableCollection<Seat> ListSeat1 { get; set; } = new ObservableCollection<Seat>();

        private void PopulateSeatList()
        {
            char row = 'A';
            for (int i = 0; i < 8; i++)
            {
                for (int j = 1; j <= 14; j++)
                {
                    string seatPosition = $"{row}{j}";
                    // ListSeat1.Add(new Seat { SeatPosition = seatPosition });
                }
                row++;
            }
        }
    }

    //public class Seat
    //{
    //    public string SeatPosition { get; set; }
    //}
}
