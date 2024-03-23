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
using System.Windows.Shapes;

namespace LoginForm
{
    public partial class VoucherManagement : Window
    {
        public ObservableCollection<Voucher> VoucherList { get; set; }

        public VoucherManagement()
        {
            InitializeComponent();
            DataContext = this;
            // Example data
            VoucherList = new ObservableCollection<Voucher>()
            {

                new Voucher { Code = "Voucher001", ReleasePeriod = "Holiday", Quantity = 100, Denomination = "$50" },
                new Voucher { Code = "Voucher002", ReleasePeriod = "Birthday", Quantity = 150, Denomination = "$100" },
                new Voucher { Code = "Voucher003", ReleasePeriod = "Anniversary", Quantity = 120, Denomination = "$75" },
            };
        }
    }

    public class Voucher
    {
        public string Code { get; set; }
        public string ReleasePeriod { get; set; }
        public int Quantity { get; set; }
        public string Denomination { get; set; }
    }
}

