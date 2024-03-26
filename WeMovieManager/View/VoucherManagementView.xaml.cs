using System.Windows.Controls;
using System.Windows.Input;

namespace WeMovieManager.View
{
    /// <summary>
    /// Interaction logic for VoucherManagementView.xaml
    /// </summary>
    public partial class VoucherManagementView : UserControl
    {
        // public ObservableCollection<Voucher2> VoucherList { get; set; }
        public VoucherManagementView()
        {
            InitializeComponent();

            //DataContext = this;
            //// Example data
            //VoucherList = new ObservableCollection<Voucher2>()
            //{

            //    new Voucher2 { Code = "Voucher001", ReleasePeriod = "Holiday", Quantity = 100, Denomination = "$50" },
            //    new Voucher2 { Code = "Voucher002", ReleasePeriod = "Birthday", Quantity = 150, Denomination = "$100" },
            //    new Voucher2 { Code = "Voucher003", ReleasePeriod = "Anniversary", Quantity = 120, Denomination = "$75" },
            //};
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DetailVoucher df = new DetailVoucher();
            df.Show();
        }
    }
    //public class Voucher2
    //{
    //    public string Code { get; set; }
    //    public string ReleasePeriod { get; set; }
    //    public int Quantity { get; set; }
    //    public string Denomination { get; set; }
    //}
}
