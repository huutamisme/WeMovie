using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeMovieManager.Commands;
using WeMovieManager.Services;
using WeMovieManager.ViewModels;

namespace WeMovieManager.Model
{

    public class VoucherDTO
    {
        public string Code { get; set; }
        public string ReleasedPeriod { get; set; }
        public int Quantities { get; set; }
        public int Denomination { get; set; }
        public DateTime ReleaseDate { get; set; }   

        public RelayCommand editButtonCommand => new RelayCommand(execute =>
        {
            EditVoucher editVoucher = new EditVoucher(this);
            editVoucher.Show();
        }, canExecute => { return true; });

        public RelayCommand deleteButtonCommand => new RelayCommand(execute =>
        {
            App.WeMovieDb.Database.ExecuteSqlCommand("DELETE FROM Voucher WHERE code = {0}", this.Code.Trim());
            ICommand VoucherNavigateCommand = new NavigateCommand(new NavigationService(App._navigationStore, () => { return new VoucherManagementViewModel(); }));
            VoucherNavigateCommand.Execute(this);
        }, canExecute => { return true; });
    }
}
