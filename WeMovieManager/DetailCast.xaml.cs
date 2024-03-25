using System.Windows;

namespace WeMovieManager
{
    /// <summary>
    /// Interaction logic for DetailCast.xaml
    /// </summary>
    public partial class DetailCast : Window
    {
        public DetailCast()
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
