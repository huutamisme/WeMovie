using LoginForm.Commands;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Linq.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace LoginForm.ViewModels
{

    public class HomePageViewModel : ViewModelBase
    {
        public ObservableCollection<Film> FilmList_BomTan { get; set; }
        private ObservableCollection<Film> _filmListDisplayed_BomTan;
        public ObservableCollection<Film> FilmListDisplayed_BomTan
        {
            get
            {
                return _filmListDisplayed_BomTan;
            }
            set
            {
                _filmListDisplayed_BomTan = value;
                OnPropertyChanged(nameof(FilmListDisplayed_BomTan));
            }
        }

        public ObservableCollection<Film> FilmList_GioVang { get; set; }
        public ObservableCollection<Film> _filmListDisplayed_GioVang;
        public ObservableCollection<Film> FilmListDisplayed_GioVang
        {
            get
            {
                return _filmListDisplayed_GioVang;
            }
            set
            {
                _filmListDisplayed_GioVang = value;
                OnPropertyChanged(nameof(FilmListDisplayed_GioVang));
            }
        }

        public string _searchText { get; set; }
        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(FilmListDisplayed_GioVang));
            }
        }

        private int currentIndex_BomTan = 0;
        private int currentIndex_GioVang = 0;
        public string backImagePath { get; set; }
        public string nextImagePath { get; set; }
        public string durationImagePath { get; set; }
        public string ageImagePath { get; set; }
        public string genreImagePath { get; set; }

        private Film _selectedItem;
        public Film SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                navigateToFilmDetail();
            }
        }

        private void navigateToFilmDetail()
        {
            NavigateCommand filmDetailNavigateCommand = new NavigateCommand(new Services.NavigationService(App._navigationStore, () => { return new FilmDetailViewModel(SelectedItem); }));
            filmDetailNavigateCommand.Execute(this);
        }

        public HomePageViewModel()
        {
            _filmListDisplayed_BomTan = new ObservableCollection<Film>();
            FilmList_BomTan = new ObservableCollection<Film>();
            _filmListDisplayed_GioVang = new ObservableCollection<Film>();
            FilmList_GioVang = new ObservableCollection<Film>();
            InitializeFilms_BomTan();
            InitializeFilms_GioVang();
            UpdateDisplayedFilms_BomTan();
            UpdateDisplayedFilms_GioVang();

            backImagePath = $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Images/Film helper/back.png";
            nextImagePath = $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Images/Film helper/next.png";
            durationImagePath = $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Images/Film helper/clock.png";
            ageImagePath = $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Images/Film helper/age.png";
            genreImagePath = $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Images/Film helper/genre.png";
        }

        private void InitializeFilms_BomTan()
        {
            using (var db = new WeMovieEntities())
            {
                var films = db.Films.Where(film => film.id % 2 == 0).ToList();
                foreach (var film in films)
                {
                    FilmList_BomTan.Add(film);
                }
            }

            // Set the data context to the MainWindow instance itself
        }
        private void UpdateDisplayedFilms_BomTan()
        {
            int startIndex = currentIndex_BomTan;
            FilmListDisplayed_BomTan = new ObservableCollection<Film>(FilmList_BomTan.Skip(startIndex).Take(4));
        }


        public RelayCommand nextButtonBomTanCommand => new RelayCommand(execute =>
        {
            if (currentIndex_BomTan < FilmList_BomTan.Count - 4)
            {
                currentIndex_BomTan++;
                UpdateDisplayedFilms_BomTan();
            }
        }, canExecute => { return true; });

        public RelayCommand backButtonBomTanCommand => new RelayCommand(execute =>
        {
            if (currentIndex_BomTan > 0)
            {
                currentIndex_BomTan--;
                UpdateDisplayedFilms_BomTan();
            }
        }, canExecute => { return true; });

        private void InitializeFilms_GioVang()
        {
            using (var db = new WeMovieEntities())
            {
                var films = db.Films.Where(film => film.id % 2 == 1).ToList();
                foreach (var film in films)
                {
                    FilmList_GioVang.Add(film);
                }
            }


            // Set the data context to the MainWindow instance itself
        }
        private void UpdateDisplayedFilms_GioVang()
        {
            int startIndex = currentIndex_GioVang;
            FilmListDisplayed_GioVang = new ObservableCollection<Film>(FilmList_GioVang.Skip(startIndex).Take(4));
        }

        public RelayCommand nextButtonGioVangCommand => new RelayCommand(execute =>
        {
            if (currentIndex_GioVang < FilmList_GioVang.Count - 4)
            {
                currentIndex_GioVang++;
                UpdateDisplayedFilms_GioVang();
            }
        }, canExecute => { return true; });

        public RelayCommand backButtonGioVangCommand => new RelayCommand(execute =>
        {
            if (currentIndex_GioVang > 0)
            {
                currentIndex_GioVang--;
                UpdateDisplayedFilms_GioVang();
            }
        }, canExecute => { return true; });

        public RelayCommand SearchCommand => new RelayCommand(execute =>
        {
            Trace.WriteLine(SearchText);
            // search bomtan
            var resultsBomTan = from f in App.WeMovieDb.Films
                          where f.name.Contains(SearchText) && f.id % 2 == 0
                          select f;
            currentIndex_BomTan = 0;
            FilmList_BomTan.Clear();
            foreach (var film in resultsBomTan)
            {
                FilmList_BomTan.Add(film);
            }
            // search by actors
            // get numbers of film in the database
            var resultsBomTan2 = from f in App.WeMovieDb.Films
                                 where f.id % 2 == 0
                                 select f;
            foreach (var film in resultsBomTan2)
            {
                var resultsActorIds = from a in App.WeMovieDb.Film_Actor
                                     where a.Film_id == film.id
                                     select a;
                foreach(var a in resultsActorIds)
                {
                    Trace.WriteLine(a.Actor_id);
                }
                break;
            }
            UpdateDisplayedFilms_BomTan();
            // search gio vang
            var resultsGioVang = from f in App.WeMovieDb.Films
                                where f.name.Contains(SearchText) && f.id % 2 == 1
                                select f;
            currentIndex_GioVang = 0;
            FilmList_GioVang.Clear();
            foreach (var film in resultsGioVang)
            {
                FilmList_GioVang.Add(film);
            }
            UpdateDisplayedFilms_GioVang();

        }, canExecute => { return true; });
    }
}
