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


        public MainViewModel(NavigationStore navigationStore)
        {
            NavigationStore = navigationStore;
            NavigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            DashboardNavigateCommand = new NavigateCommand(new NavigationService(App._navigationStore, () => { return new DashboardViewModel(); }));
            FilmManagementNavigateCommand = new NavigateCommand(new NavigationService(App._navigationStore, () => { return new FilmsManagementViewModel(); }));
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
