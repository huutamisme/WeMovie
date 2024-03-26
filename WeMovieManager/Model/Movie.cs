using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeMovieManager.Commands;

namespace WeMovieManager.Model
{
    public class Movie
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public string DirectorName { get; set; }
        public List<string> Actors { get; set; }
        public string ActorNames { get; set; }
        public DateTime PublishedYear { get; set; }
        public string Summary { get; set; }

        public int Rating { get; set; }

        public int Id { get; set; }

        public string Cert {  get; set; }

        public RelayCommand editButtonCommand => new RelayCommand(execute =>
        {
            EditFilm editFilm = new EditFilm(this);
            editFilm.Show();
        }, canExecute => { return true; });
    }
}
