using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using WeMovieManager.Commands;

namespace WeMovieManager.ViewModels
{
    public class DirectorManagementViewModel : ViewModelBase
    {
        public ObservableCollection<FilmDirector> FilmDirectorList { get; set; }
        private FilmDirector _selectedItem;
        public FilmDirector SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                Trace.WriteLine(value.DirectorName);
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public DirectorManagementViewModel()
        {
            FilmDirectorList = new ObservableCollection<FilmDirector>();

            using (var db = new WeMovieEntities())
            {
                var filmDirectors = db.Film_Director.ToList();
                foreach (var filmDirector in filmDirectors)
                {
                    // lấy phim và diễn viên sao cho id cùng nhau trùng với id film_Director
                    var film = db.Films.FirstOrDefault(f => f.id == filmDirector.Film_id);
                    var Director = db.Directors.FirstOrDefault(a => a.id == filmDirector.Director_id);
                    if (film != null && Director != null)
                    {
                        FilmDirectorList.Add(new FilmDirector
                        {
                            FilmName = film.name,
                            DirectorName = Director.name
                        });
                    }
                }
            }

            Debug.WriteLine("showtime " + FilmDirectorList.Count);
        }

        public class FilmDirector
        {
            public string FilmName { get; set; }
            public string DirectorName { get; set; }

            public RelayCommand EditButtonCommand => new RelayCommand(execute =>
            {
                Trace.WriteLine("Edit " + DirectorName);
            }, canExecute => { return true; });
        }
    }
}
