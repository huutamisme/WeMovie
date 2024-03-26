using LoginForm.Models;
using LoginForm.Stores;
using LoginForm.ViewModels;
using System.Windows;

namespace LoginForm
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static NavigationStore _navigationStore;
        public static WeMovieEntities WeMovieDb = new WeMovieEntities();
        public static bool isLoggedIn = false;
        public static Payment payment;
        public static int showId;
        public static string username;
        public App()
        {
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _navigationStore.CurrentViewModel = new HomePageViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

        }
    }
}