using System.Windows;

namespace LoginForm
{
    /// <summary>
    /// Interaction logic for TestDB.xaml
    /// </summary>
    public partial class TestDB : Window
    {
        public TestDB()
        {
            // InitializeComponent();
        }
        private void load()
        {
            //CinemaEntities db = new CinemaEntities();
            //MoviesDataGrid.ItemsSource = db.movies.ToList();
        }
        private void add()
        {

        }
        private void delete()
        {

        }
        private void edit()
        {

        }

        private void ButtonShow_Click(object sender, RoutedEventArgs e)
        {
            load();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            add();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            delete();
        }

        private void ButtonAlter_Click(object sender, RoutedEventArgs e)
        {
            edit();
        }
    }
}
