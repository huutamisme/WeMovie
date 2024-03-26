using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using WeMovieManager.Model;
namespace WeMovieManager.ViewModels
{
    public class VoucherManagementViewModel : ViewModelBase
    {
        public ObservableCollection<VoucherDTO> VoucherList { get; set; }

        private VoucherDTO _selectedItem;
        public VoucherDTO SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public VoucherManagementViewModel()
        {
            // Initialize your MovieList


            var query = from voucher in App.WeMovieDb.Vouchers
                        select new VoucherDTO
                        {
                            Code = voucher.code,
                            ReleasedPeriod = voucher.releasePeriod,
                            Quantities = (int)voucher.quantities,
                            Denomination = (int)voucher.denomination,
                            ReleaseDate = (System.DateTime)voucher.releaseDate,
                        };

            // Add some example movies
            VoucherList = new ObservableCollection<VoucherDTO>(query.ToList());
        }
    }
}
