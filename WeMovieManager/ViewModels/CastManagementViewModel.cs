using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using WeMovieManager.Commands;

namespace WeMovieManager.ViewModels
{
    public class CastManagementViewModel : ViewModelBase
    {
        public ObservableCollection<FilmActor> FilmActorList { get; set; }
        private FilmActor _selectedItem;
        public FilmActor SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                Trace.WriteLine(value.ActorName);
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public CastManagementViewModel()
        {
            FilmActorList = new ObservableCollection<FilmActor>();

            using (var db = new WeMovieEntities())
            {
                var filmActors = db.Film_Actor.ToList();
                foreach (var filmActor in filmActors)
                {
                    // lấy phim và diễn viên sao cho id cùng nhau trùng với id film_actor
                    var film = db.Films.FirstOrDefault(f => f.id == filmActor.Film_id);
                    var actor = db.Actors.FirstOrDefault(a => a.id == filmActor.Actor_id);
                    if (film != null && actor != null)
                    {
                        FilmActorList.Add(new FilmActor
                        {
                            FilmName = film.name,
                            ActorName = actor.name
                        });
                    }
                }
            }

            Debug.WriteLine("showtime " + FilmActorList.Count);
        }

        public class FilmActor
        {
            public string FilmName { get; set; }
            public string ActorName { get; set; }

            public RelayCommand EditButtonCommand => new RelayCommand(execute =>
            {
                Trace.WriteLine("Edit " + ActorName);
            }, canExecute => { return true; });
        }
    }
}
