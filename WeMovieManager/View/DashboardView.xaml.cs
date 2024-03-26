using System;
using System.Windows;
using System.Windows.Controls;
using WeMovieManager.ViewModels;

namespace WeMovieManager.View
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : UserControl
    {
        private DashboardViewModel viewModel;
        public DashboardView()
        {
            InitializeComponent();

            // Initialize the viewModel instance
            viewModel = new DashboardViewModel();

            // Set the initial DataContext
            DataContext = viewModel;
        }

        private void Filter_By_Day(object sender, RoutedEventArgs e)
        {
            DateTime startDate = DateTime.Today.AddDays(-1);
            DateTime endDate = DateTime.Today;

            viewModel.calculateTotalFilms(startDate, endDate);
            viewModel.calculateTotalShowtimes(startDate, endDate);
            viewModel.getMostGrossingFilms(startDate, endDate);
            // viewModel.getProfit(startDate, endDate);
        }

        private void Filter_By_Week(object sender, RoutedEventArgs e)
        {
            DateTime startDate = DateTime.Today.AddDays(-7);
            DateTime endDate = DateTime.Today;

            viewModel.calculateTotalFilms(startDate, endDate);
            viewModel.calculateTotalShowtimes(startDate, endDate);
            viewModel.getMostGrossingFilms(startDate, endDate);
            // viewModel.getProfit(startDate, endDate);
        }

        private void Filter_By_Month(object sender, RoutedEventArgs e)
        {
            DateTime startDate = DateTime.Today.AddDays(-30);
            DateTime endDate = DateTime.Today;

            viewModel.calculateTotalFilms(startDate, endDate);
            viewModel.calculateTotalShowtimes(startDate, endDate);
            viewModel.getMostGrossingFilms(startDate, endDate);
            // viewModel.getProfit(startDate, endDate);
        }

        private void Filter_By_Year(object sender, RoutedEventArgs e)
        {
            DateTime startDate = DateTime.Today.AddYears(-1);
            DateTime endDate = DateTime.Today;

            viewModel.calculateTotalFilms(startDate, endDate);
            viewModel.calculateTotalShowtimes(startDate, endDate);
            viewModel.getMostGrossingFilms(startDate, endDate);
            // viewModel.getProfit(startDate, endDate);
        }
    }
}
