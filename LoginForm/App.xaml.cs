using LoginForm.Stores;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LoginForm
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static NavigationStore _navigationStore;
        public App()
        {
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //_navigationStore.CurrentViewModel = new DashboardViewModel();

            //MainWindow = new MainWindow()
            //{
            //    DataContext = new MainViewModel(_navigationStore)
            //};
            //Login login = new Login(MainWindow);
            //login.Show();

        }
    }
}
