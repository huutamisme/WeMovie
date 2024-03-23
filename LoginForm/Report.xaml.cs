using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace LoginForm
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        public Report()
        {
            InitializeComponent();

            DataContext = this;

            MovieData = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Phim 1",
                    Values = new ChartValues<int> { 10 } // Số lượng xuất chiếu của Phim 1
                },
                new PieSeries
                {
                    Title = "Phim 2",
                    Values = new ChartValues<int> { 20 } // Số lượng xuất chiếu của Phim 2
                },
                new PieSeries
                {
                    Title = "Phim 1",
                    Values = new ChartValues<int> { 10 } // Số lượng xuất chiếu của Phim 1
                },
                new PieSeries
                {
                    Title = "Phim 1",
                    Values = new ChartValues<int> { 10 } // Số lượng xuất chiếu của Phim 1
                },
                new PieSeries
                {
                    Title = "Phim 1",
                    Values = new ChartValues<int> { 10 } // Số lượng xuất chiếu của Phim 1
                },
                new PieSeries
                {
                    Title = "Phim 1",
                    Values = new ChartValues<int> { 10 } // Số lượng xuất chiếu của Phim 1
                },
                new PieSeries
                {
                    Title = "Phim 1",
                    Values = new ChartValues<int> { 10 } // Số lượng xuất chiếu của Phim 1
                },
                new PieSeries
                {
                    Title = "Phim 1",
                    Values = new ChartValues<int> { 10 } // Số lượng xuất chiếu của Phim 1
                },
                new PieSeries
                {
                    Title = "Phim 1",
                    Values = new ChartValues<int> { 10 } // Số lượng xuất chiếu của Phim 1
                },
                new PieSeries
                {
                    Title = "Phim 1",
                    Values = new ChartValues<int> { 10 } // Số lượng xuất chiếu của Phim 1
                },
                new PieSeries
                {
                    Title = "Phim 1",
                    Values = new ChartValues<int> { 10 } // Số lượng xuất chiếu của Phim 1
                },
                new PieSeries
                {
                    Title = "Phim 1",
                    Values = new ChartValues<int> { 10 } // Số lượng xuất chiếu của Phim 1
                },
                new PieSeries
                {
                    Title = "Phim 1",
                    Values = new ChartValues<int> { 10 } // Số lượng xuất chiếu của Phim 1
                },
                new PieSeries
                {
                    Title = "Phim 1",
                    Values = new ChartValues<int> { 10 } // Số lượng xuất chiếu của Phim 1
                },
                new PieSeries
                {
                    Title = "Phim 1",
                    Values = new ChartValues<int> { 10 } // Số lượng xuất chiếu của Phim 1
                },
                new PieSeries
                {
                    Title = "Phim 1",
                    Values = new ChartValues<int> { 10 } // Số lượng xuất chiếu của Phim 1
                },
                new PieSeries
                {
                    Title = "Phim 2",
                    Values = new ChartValues<int> { 20 } // Số lượng xuất chiếu của Phim 2
                },
                new PieSeries
                {
                    Title = "Phim 1",
                    Values = new ChartValues<int> { 10 } // Số lượng xuất chiếu của Phim 1
                },
                new PieSeries
                {
                    Title = "Phim 1",
                    Values = new ChartValues<int> { 10 } // Số lượng xuất chiếu của Phim 1
                },
                new PieSeries
                {
                    Title = "Phim 1",
                    Values = new ChartValues<int> { 10 } // Số lượng xuất chiếu của Phim 1
                },
                new PieSeries
                {
                    Title = "Phim 1",
                    Values = new ChartValues<int> { 10 } // Số lượng xuất chiếu của Phim 1
                },
                new PieSeries
                {
                    Title = "Phim 1",
                    Values = new ChartValues<int> { 10 } // Số lượng xuất chiếu của Phim 1
                },
                new PieSeries
                {
                    Title = "Phim 1",
                    Values = new ChartValues<int> { 10 } // Số lượng xuất chiếu của Phim 1
                },
                new PieSeries
                {
                    Title = "Phim 1",
                    Values = new ChartValues<int> { 10 } // Số lượng xuất chiếu của Phim 1
                },
                new PieSeries
                {
                    Title = "Phim 1",
                    Values = new ChartValues<int> { 10 } // Số lượng xuất chiếu của Phim 1
                },
                new PieSeries
                {
                    Title = "Phim 1",
                    Values = new ChartValues<int> { 10 } // Số lượng xuất chiếu của Phim 1
                },
                new PieSeries
                {
                    Title = "Phim 1",
                    Values = new ChartValues<int> { 10 } // Số lượng xuất chiếu của Phim 1
                },
                new PieSeries
                {
                    Title = "Phim 1",
                    Values = new ChartValues<int> { 10 } // Số lượng xuất chiếu của Phim 1
                },
                new PieSeries
                {
                    Title = "Phim 1",
                    Values = new ChartValues<int> { 10 } // Số lượng xuất chiếu của Phim 1
                },
                new PieSeries
                {
                    Title = "Phim 1",
                    Values = new ChartValues<int> { 10 } // Số lượng xuất chiếu của Phim 1
                },
            };
        }

        public SeriesCollection MovieData { get; set; }

        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }


    }
}
