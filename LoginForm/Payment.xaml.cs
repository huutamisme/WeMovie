using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LoginForm
{
    /// <summary>
    /// Interaction logic for Payment.xaml
    /// </summary>
    public partial class Payment : Window
    {
        public Payment()
        {
            InitializeComponent();
            PopulateListBoxWithSampleData();
        }

        ObservableCollection<voucher> sampleData = new ObservableCollection<voucher>();

        private void PopulateListBoxWithSampleData()
        {

            sampleData.Add(new voucher { Code = "KHLS1GG30H", VoucherInfoStr = "(Discount 30000)" });
            sampleData.Add(new voucher { Code = "KHLS1GG40H", VoucherInfoStr = "(Discount 40000)" });
            listBox.ItemsSource = sampleData;
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void AddVoucher_Click(object sender, RoutedEventArgs e)
        {
            string voucherId = VoucherTextBox.Text;

            if (string.IsNullOrEmpty(voucherId))
            {
                new MessageBoxCustom("Error", "Please input your Voucher kjdchjhaksdjhsajksadh", MessageType.Error, MessageButtons.OK).ShowDialog();
            }
            else
            {
                // check invalid voucher
                listBox.Items.Add(new voucher { Code = voucherId, VoucherInfoStr = "(Discount 10000)" });
                VoucherTextBox.Text = "";
            }

        }

    }

    public class voucher
    {
        public string Code { get; set; }
        public string VoucherInfoStr { get; set; }
    }
}
