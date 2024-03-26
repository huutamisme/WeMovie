using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace LoginForm.View
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : UserControl
    {
        public string backImagePath { get; set; }
        public string nextImagePath { get; set; }
        public string durationImagePath { get; set; }
        public string ageImagePath { get; set; }
        public string genreImagePath { get; set; }

        public HomePage()
        {
            InitializeComponent();
            backImagePath = $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Images/Film helper/back.png";
            nextImagePath = $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Images/Film helper/next.png";
            durationImagePath = $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Images/Film helper/clock.png";
            ageImagePath = $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Images/Film helper/age.png";
            genreImagePath = $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Images/Film helper/genre.png";
            List<string> field_to_sort = new List<string>
            {
                "Showtime",
                "Price",
                "Premiere",
            };
            filterCombobox.ItemsSource = field_to_sort;
            filterCombobox.SelectedIndex = 0;
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
                StackPanel filmAgeText = FindVisualChild<StackPanel>(filmGrid, "FilmAgeText");
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
                filmAgeText.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);
                filmGenreText.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);

                overlayRectangle.Visibility = Visibility.Visible;
                filmTitleText.Visibility = Visibility.Visible;
                filmDurationText.Visibility = Visibility.Visible;
                filmAgeText.Visibility = Visibility.Visible;
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
                StackPanel filmAgeText = FindVisualChild<StackPanel>(filmGrid, "FilmAgeText");
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
                filmAgeText.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);

                overlayRectangle.Visibility = Visibility.Hidden;
                filmTitleText.Visibility = Visibility.Hidden;
                filmDurationText.Visibility = Visibility.Hidden;
                filmGenreText.Visibility = Visibility.Hidden;
                filmAgeText.Visibility = Visibility.Hidden;

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

        private void ScrollToTop_Click(object sender, MouseButtonEventArgs e)
        {
            scrollView.ScrollToTop();
        }
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // thực hiện search
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            // thực hiện search
        }


    }
}
