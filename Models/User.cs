using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Movie_Mania_2.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public String Nombre { get; set; }
        [Required]
        public String Apellido { get; set; }
        [Required]
        public String Usuario { get; set; }
        [Required]
        public User_Type tipo_Usuario { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")] 
        public String Mail { get; set; }
        
        [Required]
        [DisplayName("Constraseña")]
        public String Password { get; set; }

        [Required]
        public List<Movie> Peliculas_Favoritas { get; set; }
    }
}