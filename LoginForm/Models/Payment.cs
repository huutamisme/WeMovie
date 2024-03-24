using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.Models
{
    public class Payment
    {
        public int filmId { get; set; }
        public string filmName { get; set; }
        public string showDate { get; set; }
        public string showTime { get; set; }
        public int showId { get; set; } 

        public int price { get; set; }  

        public int total {  get; set; } 
        public string poster {  get; set; }
    }
}
