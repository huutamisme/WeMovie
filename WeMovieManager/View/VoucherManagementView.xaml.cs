using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for VoucherManagementView.xaml
    /// </summary>
    public partial class VoucherManagementView : UserControl
    {
        public ObservableCollection<Voucher2> VoucherList { get; set; }
        public VoucherManagementView()
        {
            InitializeComponent();

            DataContext = this;
            // Example data
            VoucherList = new ObservableCollection<Voucher2>()
            {

                new Voucher2 { Code = "Voucher001", ReleasePeriod = "Holiday", Quantity = 100, Denomination = "$50" },
                new Voucher2 { Code = "Voucher002", ReleasePeriod = "Birthday", Quantity = 150, Denomination = "$100" },
                new Voucher2 { Code = "Voucher003", ReleasePeriod = "Anniversary", Quantity = 120, Denomination = "$75" },
            };
        }
    }
    public class Voucher2
    {
        public string Code { get; set; }
        public string ReleasePeriod { get; set; }
        public int Quantity { get; set; }
        public string Denomination { get; set; }
    }
}
