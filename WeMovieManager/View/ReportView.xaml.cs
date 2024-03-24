﻿using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeMovieManager.View
{
    /// <summary>
    /// Interaction logic for ReportView.xaml
    /// </summary>
    public partial class ReportView : UserControl
    {


        private Dictionary<string, int> movieDictionary = new Dictionary<string, int>
        {
            { "Phim 1", 10 },
            { "Phim 2", 20 },
            { "Phim 3", 15 },
            { "Phim 4", 25 },
            { "Phim 5", 18 },
            { "Phim 6", 12 },
            { "Phim 7", 30 },
            { "Phim 8", 22 },
            { "Phim 9", 17 },
            { "Phim 10", 28 },
            { "Phim 11", 13 },
            { "Phim 12", 23 },
            { "Phim 13", 19 },
            { "Phim 14", 27 },
            { "Phim 15", 16 },
            { "Phim 16", 21 },
            { "Phim 17", 24 },
            { "Phim 18", 14 },
            { "Phim 19", 29 },
            { "Phim 20", 26 },
            { "Phim 21", 11 },
            { "Phim 22", 31 },
            { "Phim 23", 36 },
            { "Phim 24", 40 },
            { "Phim 25", 35 },
            { "Phim 26", 39 },
            { "Phim 27", 33 },
            { "Phim 28", 37 },
            { "Phim 29", 34 },
            { "Phim 30", 38 }
        };
        public ReportView()
        {
            InitializeComponent();
            LoadListBox();
            UpdatePieChart();
        }



        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void LoadListBox()
        {
            foreach (string movieName in movieDictionary.Keys)
            {
                phimListBox.Items.Add(movieName);
            }
        }

        private void UpdatePieChart()
        {
            pieChart.Series = new SeriesCollection();

            foreach (string selectedMovie in phimListBox.SelectedItems)
            {
                if (movieDictionary.ContainsKey(selectedMovie))
                {
                    pieChart.Series.Add(new PieSeries
                    {
                        Title = selectedMovie,
                        Values = new ChartValues<int> { movieDictionary[selectedMovie] }
                    });
                }
            }
        }

        private void phimListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdatePieChart();
        }
    }
}
