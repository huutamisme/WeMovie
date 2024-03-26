using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeMovieManager.Commands;

namespace WeMovieManager.Model
{
    public class FilmActor
    {
        public string FilmName { get; set; }
        public string ActorName { get; set; }

        public int Id { get; set; }
        public string Bio { get; set; }
        public RelayCommand editButtonCommand => new RelayCommand(execute =>
        {
            EditCast editCast = new EditCast(this);
            editCast.Show();
        }, canExecute => { return true; });
    }
}
