using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie_Mania_2.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Sinopsis { get; set; }
        public DateTime Estreno { get; set; }
    }
}