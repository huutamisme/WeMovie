using LoginForm.Commands;
using LoginForm.Models;
using LoginForm.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace LoginForm.View
{
    /// <summary>
    /// Interaction logic for PaymentView.xaml
    /// </summary>
    public partial class PaymentView : UserControl
    {
        public Payment payment { get; set; }
        public PaymentView()
        {
            InitializeComponent();
            PopulateListBoxWithSampleData();
        }

        ObservableCollection<Voucher1> sampleData = new ObservableCollection<Voucher1>();

        private void PopulateListBoxWithSampleData()
        {
            payment = App.payment;
            string packUri = "pack://application:,,,/LoginForm;component" + payment.poster;
            imgToBind.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
            sampleData.Add(new Voucher1 { Code = "KHLS1GG30H", VoucherInfoStr = "(Discount 30000)" });
            sampleData.Add(new Voucher1 { Code = "KHLS1GG40H", VoucherInfoStr = "(Discount 40000)" });
            listBox.ItemsSource = sampleData;
            filmNameToBind.Text = payment.filmName;
            foreach (var item in payment.seats)
            {
                Trace.WriteLine("In payment: " + item);
            }
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
                listBox.Items.Add(new Voucher1 { Code = voucherId, VoucherInfoStr = "(Discount 10000)" });
                VoucherTextBox.Text = "";
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigateCommand BookingNavigateCommand = new NavigateCommand(new Services.NavigationService(App._navigationStore, () => { return new TicketBookingViewModel(); }));
            BookingNavigateCommand.Execute(this);
        }
    }

    public class Voucher1
    {
        public string Code { get; set; }
        public string VoucherInfoStr { get; set; }
    }
}
