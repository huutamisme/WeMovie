using System.Windows;
using WeMovieManager.Stores;
using WeMovieManager.ViewModels;

namespace WeMovieManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static NavigationStore _navigationStore;
        public static WeMovieEntities WeMovieDb = new WeMovieEntities();
        public App()
        {
            _navigationStore = new NavigationStore();
        }
        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);
        //    _navigationStore.CurrentViewModel = new DashboardViewModel();

        //    MainWindow = new MainWindow()
        //    {
        //        DataContext = new MainViewModel(_navigationStore)
        //    };
        //    Login login = new Login(MainWindow);
        //    login.Show();

        //}
    }
}
