using System;
using System.Collections.Generic;
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

using System.Windows.Shapes;
using WeMovieManager.Commands;
using WeMovieManager.Model;
using WeMovieManager.Services;
using WeMovieManager.ViewModels;

namespace WeMovieManager
{
    /// <summary>
    /// Interaction logic for EditVoucher.xaml
    /// </summary>
    public partial class EditVoucher : Window
    {
        VoucherDTO voucher;

        public EditVoucher(VoucherDTO voucher)
        {
            this.voucher = voucher;
            InitializeComponent();
            codeToBind.Text = voucher.Code;
            denomToBind.Text  = voucher.Denomination.ToString();
            quantityToBind.Text = voucher.Quantities.ToString();
            releasePeriodToBind.Text = voucher.ReleasedPeriod;
            _movieDate.DisplayDateStart = voucher.ReleaseDate;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var query = from vouch in App.WeMovieDb.Vouchers where vouch.code == voucher.Code.Trim() select vouch;
            var result = query.Single();
            Trace.WriteLine(result.code);
            result.code = voucher.Code;
            result.denomination = Int32.Parse(denomToBind.Text);
            result.releasePeriod = releasePeriodToBind.Text;
            result.quantities = Int32.Parse(quantityToBind.Text);
            if(_movieDate.Text.Length > 0)
            {
                result.releaseDate = _movieDate.DisplayDate;
            }
            App.WeMovieDb.SaveChanges();

            ICommand VoucherNavigateCommand = new NavigateCommand(new NavigationService(App._navigationStore, () => { return new VoucherManagementViewModel(); }));
            VoucherNavigateCommand.Execute(this);
            this.Close();
        }
    }
}
