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

namespace LoginForm.View
{
    /// <summary>
    /// Interaction logic for TicketBookingView.xaml
    /// </summary>
    public partial class TicketBookingView : UserControl
    {
        public TicketBookingView()
        {
            InitializeComponent();
            DataContext = this;
            PopulateSeatList();
        }

        public ObservableCollection<Seat> ListSeat1 { get; set; } = new ObservableCollection<Seat>();

        private void PopulateSeatList()
        {
            char row = 'A';
            for (int i = 0; i < 8; i++)
            {
                for (int j = 1; j <= 14; j++)
                {
                    string seatPosition = $"{row}{j}";
                    ListSeat1.Add(new Seat { SeatPosition = seatPosition });
                }
                row++;
            }
        }
    }
    public class Seat
    {
        public string SeatPosition { get; set; }
    }
}
