using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeMovieManager.Services;
using WeMovieManager.Stores;
using WeMovieManager.Commands;
using System.Windows.Input;

namespace WeMovieManager.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel => NavigationStore.CurrentViewModel;
        public NavigationStore NavigationStore;

        public ICommand DashboardNavigateCommand { get; }
        public ICommand FilmManagementNavigateCommand { get; }
        public ICommand ShowTimeManagementNavigateCommand { get; }
        public ICommand VoucherNavigateCommand { get; }
        public ICommand CastNavigateCommand { get; }
        public ICommand DirectorNavigateCommand { get; }
        public ICommand ReportNavigateCommand { get; }


        public MainViewModel(NavigationStore navigationStore)
        {
            NavigationStore = navigationStore;
            NavigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            DashboardNavigateCommand = new NavigateCommand(new NavigationService(App._navigationStore, () => { return new DashboardViewModel(); }));
            FilmManagementNavigateCommand = new NavigateCommand(new NavigationService(App._navigationStore, () => { return new FilmsManagementViewModel(); }));
            ShowTimeManagementNavigateCommand = new NavigateCommand(new NavigationService(App._navigationStore, () => { return new ShowTimeManagementViewModel(); }));
            VoucherNavigateCommand = new NavigateCommand(new NavigationService(App._navigationStore, () => { return new VoucherManagementViewModel(); }));
            CastNavigateCommand = new NavigateCommand(new NavigationService(App._navigationStore, () => { return new CastManagementViewModel(); }));
            DirectorNavigateCommand = new NavigateCommand(new NavigationService(App._navigationStore, () => { return new DirectorManagementViewModel(); }));
            ReportNavigateCommand = new NavigateCommand(new NavigationService(App._navigationStore, () => { return new ReportViewModel(); }));
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
