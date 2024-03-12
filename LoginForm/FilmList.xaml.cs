using MahApps.Metro.Controls;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace LoginForm
{
    /// <summary>
    /// Interaction logic for FilmList.xaml
    /// </summary>
    public partial class FilmList : MetroWindow
    {
        public ObservableCollection<Film> FilmList_BomTan { get; set; }
        public ObservableCollection<Film> FilmList_GioVang { get; set; }
        private int currentIndex_BomTan = 0;
        private int currentIndex_GioVang = 0;
        public string backImagePath { get; set; }
        public string nextImagePath { get; set; }
        public string durationImagePath { get; set; }
        public string ageImagePath { get; set; }
        public string genreImagePath { get; set; }
        public FilmList()
        {
            InitializeComponent();

            DataContext = this;

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
            BomTan_FilmListBox.ItemsSource = FilmList_BomTan;
        }
        private void UpdateDisplayedFilms_BomTan()
        {
            int startIndex = currentIndex_BomTan;
            var displayedFilms = FilmList_BomTan.Skip(startIndex).Take(4).ToList();

            BomTan_FilmListBox.ItemsSource = displayedFilms;
        }

        private void BomTan_NextButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (currentIndex_BomTan < FilmList_BomTan.Count - 4)
            {
                currentIndex_BomTan++;
                UpdateDisplayedFilms_BomTan();
            }
        }

        private void BomTan_BackButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (currentIndex_BomTan > 0)
            {
                currentIndex_BomTan--;
                UpdateDisplayedFilms_BomTan();
            }
        }
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
            GioVang_FilmListBox.ItemsSource = FilmList_GioVang;
        }
        private void UpdateDisplayedFilms_GioVang()
        {
            int startIndex = currentIndex_GioVang;
            var displayedFilms = FilmList_GioVang.Skip(startIndex).Take(4).ToList();

            GioVang_FilmListBox.ItemsSource = displayedFilms;
        }

        private void GioVang_NextButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (currentIndex_GioVang < FilmList_GioVang.Count - 4)
            {
                currentIndex_GioVang++;
                UpdateDisplayedFilms_GioVang();
            }
        }
        private void GioVang_BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentIndex_GioVang > 0)
            {
                currentIndex_GioVang--;
                UpdateDisplayedFilms_GioVang();
            }
        }

        private void FilmGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            Grid filmGrid = (Grid)sender;
            ListBoxItem listBoxItem = FindVisualParent<ListBoxItem>(filmGrid);

            if (listBoxItem != null)
            {
                Rectangle overlayRectangle = FindVisualChild<Rectangle>(filmGrid, "OverlayRectangle");
                TextBlock filmTitleText = FindVisualChild<TextBlock>(filmGrid, "FilmTitleText");
                StackPanel filmDurationText = FindVisualChild<StackPanel>(filmGrid, "FilmDurationText");
                StackPanel filmGenreText = FindVisualChild<StackPanel>(filmGrid, "FilmGenreText");
                TextBlock filmTitle = FindVisualChild<TextBlock>(listBoxItem, "FilmTitle");

                Debug.WriteLine("test " + filmTitle);

                // Use DoubleAnimation to animate the opacity property
                DoubleAnimation opacityAnimation = new DoubleAnimation
                {
                    From = 0.0,
                    To = 1.0,
                    Duration = TimeSpan.FromSeconds(0.3)
                };

                SolidColorBrush yellowBrush = new SolidColorBrush(Colors.Yellow);

                overlayRectangle.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);
                filmTitleText.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);
                filmDurationText.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);
                filmGenreText.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);

                overlayRectangle.Visibility = Visibility.Visible;
                filmTitleText.Visibility = Visibility.Visible;
                filmDurationText.Visibility = Visibility.Visible;
                filmGenreText.Visibility = Visibility.Visible;

                // Change the text color to yellow
                filmTitle.Foreground = yellowBrush;
            }
        }

        private void FilmGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            Grid filmGrid = (Grid)sender;
            ListBoxItem listBoxItem = FindVisualParent<ListBoxItem>(filmGrid);

            if (listBoxItem != null)
            {
                Rectangle overlayRectangle = FindVisualChild<Rectangle>(filmGrid, "OverlayRectangle");
                TextBlock filmTitleText = FindVisualChild<TextBlock>(filmGrid, "FilmTitleText");
                StackPanel filmDurationText = FindVisualChild<StackPanel>(filmGrid, "FilmDurationText");
                StackPanel filmGenreText = FindVisualChild<StackPanel>(filmGrid, "FilmGenreText");
                TextBlock filmTitle = FindVisualChild<TextBlock>(listBoxItem, "FilmTitle");

                // Use DoubleAnimation to animate the opacity property
                DoubleAnimation opacityAnimation = new DoubleAnimation
                {
                    From = 1.0,
                    To = 0.0,
                    Duration = TimeSpan.FromSeconds(0.3)
                };

                overlayRectangle.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);
                filmTitleText.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);
                filmDurationText.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);
                filmGenreText.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);

                overlayRectangle.Visibility = Visibility.Hidden;
                filmTitleText.Visibility = Visibility.Hidden;
                filmDurationText.Visibility = Visibility.Hidden;
                filmGenreText.Visibility = Visibility.Hidden;

                // Revert the text color to white
                filmTitle.Foreground = Brushes.White;
            }
        }

        private T FindVisualChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            int count = VisualTreeHelper.GetChildrenCount(parent);

            for (int i = 0; i < count; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);

                if (child is T && ((FrameworkElement)child).Name == childName)
                {
                    return (T)child;
                }

                T childOfChild = FindVisualChild<T>(child, childName);

                if (childOfChild != null)
                {
                    return childOfChild;
                }
            }

            if (parent is Control control && control.Template != null)
            {
                return FindVisualChild<T>(control.Template.LoadContent() as DependencyObject, childName);
            }

            return null;
        }

        private T FindVisualParent<T>(DependencyObject child) where T : DependencyObject
        {
            while ((child != null) && !(child is T))
            {
                child = VisualTreeHelper.GetParent(child);
            }

            return (T)child;
        }
    }
    // Assuming you have a Film class defined like this
    public class Film
    {
        public string ThumbnailPath { get; set; }
        public string FilmTitle { get; set; }
        public string Duration { get; set; }
        public string Genre { get; set; }
        // Add other properties as needed (e.g., Title, Description, etc.)
    }
}
