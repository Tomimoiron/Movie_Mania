using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace Movie_Mania_2.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio"), MaxLength(50, ErrorMessage = "Maxima cantidad de caracteres 50")]
        public String Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio"), MaxLength(500, ErrorMessage = "Maxima cantidad de caracteres 500")]
        public String Sinopsis { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio (Formato DD/MM/YYYY)")]
        public DateTime Estreno { get; set; }
    }
}