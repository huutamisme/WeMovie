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
                Trace.WriteLine(value.Time);
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ShowTimeManagementViewModel()
        {
            // Initialize your MovieList

            ShowTimeList = new ObservableCollection<Showtime>();

            using (var db = new WeMovieEntities())
            {
                var showtimes = db.Showtimes.ToList();
                foreach (var showtime in showtimes)
                {
                    var film = db.Films.FirstOrDefault(f => f.id == showtime.Film);
                    if (film != null)
                    {
                        ShowTimeList.Add(new Showtime
                        {
                            Time = (TimeSpan)showtime.time,
                            FilmName = film.name,
                            Duration = (int)film.duration
                        });
                    }
                }
            }


            Debug.Write("showtime " + ShowTimeList.Count);

            // Set the DataContext to this instance (for binding)
        }

        public class Showtime
        {
            public TimeSpan Time { get; set; }
            public string FilmName { get; set; }
            public int Duration { get; set; }

            public RelayCommand editButtonCommand => new RelayCommand(execute =>
            {
                Trace.WriteLine("Edit " + Time);
            }, canExecute => { return true; });
        }
    }
}
