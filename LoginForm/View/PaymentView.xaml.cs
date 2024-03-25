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
using System.Windows.Media.Media3D;
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
        public static float totalDiscount;
        public static ObservableCollection<Voucher1> sampleData = new ObservableCollection<Voucher1>();

        private void PopulateListBoxWithSampleData()
        {
            payment = App.payment;
            string packUri = "pack://application:,,,/LoginForm;component" + payment.poster;
            imgToBind.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
            listBox.ItemsSource = sampleData;
            filmNameToBind.Text = payment.filmName;
            foreach (var item in payment.seats)
            {
                Trace.WriteLine("In payment: " + item);
            }
            seatToBind.Text = payment.seats.Count.ToString();
            dateToBind.Content = payment.showDate;
            timeToBind.Content = payment.showTime;
            totalBeforeToBind.Content = payment.total;
            totalAfterToBind.Content = payment.total;
            priceToBind.Content = payment.price;
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void AddVoucher_Click(object sender, RoutedEventArgs e)
        {
            string voucherCode = VoucherTextBox.Text;

            if (string.IsNullOrEmpty(voucherCode))
            {
                new MessageBoxCustom("Error", "Please input your Voucher", MessageType.Error, MessageButtons.OK).ShowDialog();
            }
            else
            {
                var query = from voucher in App.WeMovieDb.Vouchers where voucher.code == voucherCode select voucher;
                // check invalid voucher
                var result = query.ToList();
                if (result.Count == 0)
                {
                    new MessageBoxCustom("Error", "No matching voucher", MessageType.Error, MessageButtons.OK).ShowDialog();
                }
                else
                {
                    bool isExists = false;
                    foreach (Voucher1 item in sampleData)
                    {
                        if (item.Code.Trim().ToLower().Equals(voucherCode.Trim().ToLower()))
                        {
                            isExists = true;
                            break;
                        }
                    }
                    if (isExists)
                    {
                        new MessageBoxCustom("Error", "Already applied this voucher", MessageType.Error, MessageButtons.OK).ShowDialog();
                    }
                    else
                    {
                        totalDiscount += (float)result[0].denomination;
                        sampleData.Add(new Voucher1 { Code = result[0].code, VoucherInfoStr = "Discount " + result[0].denomination + "%", discount = (float)result[0].denomination, view = this });
                        totalAfterToBind.Content = payment.total * (100 - totalDiscount) / 100;
                    }
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigateCommand BookingNavigateCommand = new NavigateCommand(new Services.NavigationService(App._navigationStore, () => { return new TicketBookingViewModel(); }));
            BookingNavigateCommand.Execute(this);
        }

        public void substractDiscount()
        {
            totalAfterToBind.Content = payment.total * (100 - totalDiscount) / 100;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (int item in payment.seats)
            {
                var query = from seat in App.WeMovieDb.Seats where seat.id == item select seat;
                var result = query.Single();
                result.status = "Taken";
                App.WeMovieDb.SaveChanges();
            }
            new MessageBoxCustom("Success", "Ticket booked", MessageType.Success, MessageButtons.OK).ShowDialog();
            NavigateCommand BookingNavigateCommand = new NavigateCommand(new Services.NavigationService(App._navigationStore, () => { return new TicketBookingViewModel(); }));
            BookingNavigateCommand.Execute(this);
        }
    }

    public class Voucher1
    {
        public RelayCommand delVoucherCommand => new RelayCommand(execute =>
        {
            PaymentView.sampleData.Remove(this);
            PaymentView.totalDiscount -= discount;
            view.substractDiscount();
        }, canExecute => { return true; });
        public string Code { get; set; }
        public string VoucherInfoStr { get; set; }
        public float discount;
        public PaymentView view;
    }
}
