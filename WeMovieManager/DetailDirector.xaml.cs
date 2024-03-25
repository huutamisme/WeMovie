using System.Windows;

namespace WeMovieManager
{
    /// <summary>
    /// Interaction logic for DetailDirector.xaml
    /// </summary>
    public partial class DetailDirector : Window
    {
        public DetailDirector()
        {
            InitializeComponent();
        }
        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            // Close the window
            this.Close();
        }
    }
}
