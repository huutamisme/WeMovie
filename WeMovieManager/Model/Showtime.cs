using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeMovieManager.Commands;

namespace WeMovieManager.Model
{
    public class ShowtimeDTO
    {
        public TimeSpan Time { get; set; }
        public string FilmName { get; set; }
        public int Duration { get; set; }
        public int Id { get; set; }

        public int Price { get; set; }

        public RelayCommand editButtonCommand => new RelayCommand(execute =>
        {
            EditShowtime editShowtime = new EditShowtime(this);
            editShowtime.Show();
        }, canExecute => { return true; });
    }
}
