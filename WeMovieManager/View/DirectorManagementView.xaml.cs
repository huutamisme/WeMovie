﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeMovieManager.View
{
    /// <summary>
    /// Interaction logic for DirectorManagementView.xaml
    /// </summary>
    public partial class DirectorManagementView : UserControl
    {
        public DirectorManagementView()
        {
            InitializeComponent();
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DetailDirector df = new DetailDirector();
            df.Show();
        }
    }
}
