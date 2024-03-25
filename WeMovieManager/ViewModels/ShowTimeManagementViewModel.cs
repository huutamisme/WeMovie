using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using WeMovieManager.Commands;

namespace WeMovieManager.ViewModels
{
    public class ShowTimeManagementViewModel : ViewModelBase
    {
        public ObservableCollection<Showtime> ShowTimeList { get; set; }

        private Showtime _selectedItem;
        public Showtime SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                Trace.WriteLine(value.time);
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ShowTimeManagementViewModel()
        {
            // Initialize your MovieList


            var query = from showtime in App.WeMovieDb.Showtimes
                        select new Showtime
                        {
                            time = (TimeSpan)showtime.time,
                            date = (DateTime)showtime.date,
                            price = (int)showtime.price,
                            seatQuantities = (int)showtime.seatQuantities,
                            Film = (int)showtime.Film
                        };
            // Add some example movies
            ShowTimeList = new ObservableCollection<Showtime>(query.ToList());

            Debug.Write("showtime " + ShowTimeList.Count);

            // Set the DataContext to this instance (for binding)
        }

        public class Showtime
        {
            public TimeSpan time { get; set; }
            public DateTime date { get; set; }
            public int price { get; set; }
            public int seatQuantities { get; set; }
            public int Film { get; set; }    // ten 

            public RelayCommand editButtonCommand => new RelayCommand(execute =>
            {
                Trace.WriteLine("Edit " + time);
            }, canExecute => { return true; });
        }
    }
}
