using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using WeMovieManager.Commands;
using WeMovieManager.Model;

namespace WeMovieManager.ViewModels
{
    public class ShowTimeManagementViewModel : ViewModelBase
    {
        public ObservableCollection<ShowtimeDTO> ShowTimeList { get; set; }

        private ShowtimeDTO _selectedItem;
        public ShowtimeDTO SelectedItem
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

            ShowTimeList = new ObservableCollection<ShowtimeDTO>();

            using (var db = new WeMovieEntities())
            {
                var showtimes = db.Showtimes.ToList();
                foreach (var showtime in showtimes)
                {
                    var film = db.Films.FirstOrDefault(f => f.id == showtime.Film);
                    if (film != null)
                    {
                        ShowTimeList.Add(new ShowtimeDTO
                        {
                            Id = showtime.id,
                            Time = (TimeSpan)showtime.time,
                            FilmName = film.name,
                            Duration = (int)film.duration,
                            Price = (int)showtime.price,
                        });;
                    }
                }
            }


            Debug.Write("showtime " + ShowTimeList.Count);

            // Set the DataContext to this instance (for binding)
        }
    }
}
