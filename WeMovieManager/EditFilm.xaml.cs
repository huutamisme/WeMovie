using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WeMovieManager
{
    /// <summary>
    /// Interaction logic for EditFilm.xaml
    /// </summary>
    public partial class EditFilm : Window
    {

        public ObservableCollection<string> ListActor { get; set; }
        public ObservableCollection<string> ListDirector { get; set; }
        public EditFilm()
        {
            InitializeComponent();

            DataContext = this;

            // Khởi tạo danh sách ListActor
            ListActor = new ObservableCollection<string>();

            // Thêm dữ liệu mẫu cho ComboBox
            actorList.Items.Add("Actor 1");
            actorList.Items.Add("Actor 2");
            actorList.Items.Add("Actor 3");

            // Khởi tạo danh sách ListActor
            ListDirector = new ObservableCollection<string>();

            // Thêm dữ liệu mẫu cho ComboBox
            directorList.Items.Add("Director 1");
            directorList.Items.Add("Director 2");
            directorList.Items.Add("Director 3");
        }

        private void actorList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Thêm mục đã chọn từ ComboBox vào ListBox

            string selectedActor = actorList.SelectedItem as string;
            if (selectedActor != null)
            {
                ListActor.Add(selectedActor);
            }
        }

        private void RemoveActor_Click(object sender, RoutedEventArgs e)
        {
            // Xóa mục đã chọn khỏi ListBox
            string actorToRemove = (sender as FrameworkElement).DataContext as string;
            if (actorToRemove != null)
            {
                ListActor.Remove(actorToRemove);
            }
        }

        private void directorList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Thêm mục đã chọn từ ComboBox vào ListBox

            string selectedDirector = directorList.SelectedItem as string;
            if (selectedDirector != null)
            {
                ListDirector.Add(selectedDirector);
            }
        }

        private void RemoveDirector_Click(object sender, RoutedEventArgs e)
        {
            // Xóa mục đã chọn khỏi ListBox
            string directorToRemove = (sender as FrameworkElement).DataContext as string;
            if (directorToRemove != null)
            {
                ListDirector.Remove(directorToRemove);
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private static readonly Regex _regex = new Regex("[^0-9]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }


        private void _movieGenre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
            }
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
