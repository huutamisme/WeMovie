﻿using LoginForm.Models;
using LoginForm.Stores;
using LoginForm.ViewModels;
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
        public static WeMovieEntities WeMovieDb = new WeMovieEntities();
        public static bool isLoggedIn = false;
        public static Payment payment;
        public App()
        {
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _navigationStore.CurrentViewModel = new TicketBookingViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

        }
    }
}
