using LoginForm.Commands;
using LoginForm.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoginForm.ViewModels
{

    public class HomePageViewModel : ViewModelBase
    {
        public ObservableCollection<Film> FilmList_BomTan { get; set; }
        public ObservableCollection<Film> _filmListDisplayed_BomTan;
        public ObservableCollection<Film> FilmListDisplayed_BomTan
        {
            get
            {
                return _filmListDisplayed_BomTan;
            }
            set
            {
                Trace.WriteLine("HERE");
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
            FilmList_BomTan = new ObservableCollection<Film>
            {
                new Film
                {
                    ThumbnailPath = $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Images/Film/Avatar.jpg",
                    FilmTitle= "Avatar",
                    Duration = "192'",
                    Genre = "Khoa học viễn tưởng",

                },
                new Film
                {
                    ThumbnailPath = $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Images/Film/Avengers.jpg",
                    FilmTitle= "Avengers",
                    Duration = "149'",
                    Genre = "Hành động, khoa học viễn tưởng",

                },
                new Film
                {
                    ThumbnailPath = $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Images/Film/Black Panther.jpg",
                    FilmTitle= "Black Panther",
                    Duration = "134'",
                    Genre = "Hành động, khoa học viễn tưởng",

                },
                new Film
                {
                    ThumbnailPath = $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Images/Film/Captain America.jpg",
                    FilmTitle = "Captain America",
                    Duration = "136'",
                    Genre = "Hành động, khoa học viễn tưởng",

                },

                new Film
                {
                    ThumbnailPath = $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Images/Film/Fast and Furious 9.jpg",
                    FilmTitle = "Fast and Furious 9",
                    Duration = "143'",
                    Genre = "Hành động, thám hiểm, tội phạm",

                },
                new Film
                {
                    ThumbnailPath = $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Images/Film/Finding Dory.jpg",
                    FilmTitle = "Finding Dory",
                    Duration = "97'",
                    Genre = "Hoạt hình, phiêu lưu, hài hước",

                },
                new Film
                {
                    ThumbnailPath = $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Images/Film/Harry Potter.jpg",
                    FilmTitle = "Harry Potter",
                    Duration = "130'",
                    Genre = "Phép thuật, hành động, phiêu lưu",

                },
                new Film
                {
                    ThumbnailPath = $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Images/Film/Incredibles 2.jpg",
                    FilmTitle = "Incredibles 2",
                    Duration = "118'",
                    Genre = "Hoạt hình, hành động, phiêu lưu",

                }
            };
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

        public RelayCommand backButtonBomTanCommand => new RelayCommand(execute => {
            if (currentIndex_BomTan > 0)
            {
                currentIndex_BomTan--;
                UpdateDisplayedFilms_BomTan();
            }
        }, canExecute => { return true; });

        private void InitializeFilms_GioVang()
        {
            FilmList_GioVang = new ObservableCollection<Film>
            {
                new Film
                {
                    ThumbnailPath = $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Images/Film/Avatar.jpg",
                    FilmTitle= "Avatar",
                    Duration = "192'",
                    Genre = "Khoa học viễn tưởng",

                },
                new Film
                {
                    ThumbnailPath = $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Images/Film/Avengers.jpg",
                    FilmTitle= "Avengers",
                    Duration = "149'",
                    Genre = "Hành động, khoa học viễn tưởng",

                },
                new Film
                {
                    ThumbnailPath = $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Images/Film/Black Panther.jpg",
                    FilmTitle= "Black Panther",
                    Duration = "134'",
                    Genre = "Hành động, khoa học viễn tưởng",

                },
                new Film
                {
                    ThumbnailPath = $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Images/Film/Captain America.jpg",
                    FilmTitle = "Captain America",
                    Duration = "136'",
                    Genre = "Hành động, khoa học viễn tưởng",

                },

                new Film
                {
                    ThumbnailPath = $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Images/Film/Fast and Furious 9.jpg",
                    FilmTitle = "Fast and Furious 9",
                    Duration = "143'",
                    Genre = "Hành động, thám hiểm, tội phạm",

                },
                new Film
                {
                    ThumbnailPath = $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Images/Film/Finding Dory.jpg",
                    FilmTitle = "Finding Dory",
                    Duration = "97'",
                    Genre = "Hoạt hình, phiêu lưu, hài hước",

                },
                new Film
                {
                    ThumbnailPath = $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Images/Film/Harry Potter.jpg",
                    FilmTitle = "Harry Potter",
                    Duration = "130'",
                    Genre = "Phép thuật, hành động, phiêu lưu",

                },
                new Film
                {
                    ThumbnailPath = $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Images/Film/Incredibles 2.jpg",
                    FilmTitle = "Incredibles 2",
                    Duration = "118'",
                    Genre = "Hoạt hình, hành động, phiêu lưu",

                }
            };
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
    }
}
