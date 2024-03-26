using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeMovieManager.Commands;

namespace WeMovieManager.Model
{
    public class FilmDirector
    {
        public string FilmName { get; set; }
        public string DirectorName { get; set; }
        public int Id { get; set; } 
        public string Bio {  get; set; }

        public RelayCommand editButtonCommand => new RelayCommand(execute =>
        {
            EditDirector editDirector = new EditDirector(this);
            editDirector.Show();
        }, canExecute => { return true; });
    }
}
