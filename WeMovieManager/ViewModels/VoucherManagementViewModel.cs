using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using WeMovieManager.Commands;

namespace WeMovieManager.ViewModels
{
    public class VoucherManagementViewModel : ViewModelBase
    {
        public ObservableCollection<Voucher> VoucherList { get; set; }

        private Voucher _selectedItem;
        public Voucher SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                Trace.WriteLine(value.Code);
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public VoucherManagementViewModel()
        {
            // Initialize your MovieList


            var query = from voucher in App.WeMovieDb.Vouchers
                        select new Voucher
                        {
                            Code = voucher.code,
                            ReleasedPeriod = voucher.releasePeriod,
                            Quantities = (int)voucher.quantities,
                            Denomination = (int)voucher.denomination
                        };

            // Add some example movies
            VoucherList = new ObservableCollection<Voucher>(query.ToList());

            // Set the DataContext to this instance (for binding)
        }

        public class Voucher
        {
            public string Code { get; set; }
            public string ReleasedPeriod { get; set; }
            public int Quantities { get; set; }
            public int Denomination { get; set; }

            public RelayCommand editButtonCommand => new RelayCommand(execute =>
            {
                Trace.WriteLine("Edit " + Code);
            }, canExecute => { return true; });
        }
    }
}
