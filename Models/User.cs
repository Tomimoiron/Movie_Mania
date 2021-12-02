using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Movie_Mania_2.Data;

namespace Movie_Mania_2.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio"), MaxLength(30,ErrorMessage ="Maxima cantidad de caracteres 30")]

        public String Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio"), MaxLength(50, ErrorMessage = "Maxima cantidad de caracteres 50")]
        public String Apellido { get; set; }
        [Key]
        [Required(ErrorMessage = "Este campo es obligatorio"), MaxLength(20, ErrorMessage = "Maxima cantidad de caracteres 20")]
        public String Usuario { get; set; }

        [Required, DataType(DataType.EmailAddress, ErrorMessage = "El mail ingresado no es valido")] 
        public String Mail { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio"), DataType(DataType.Password), DisplayName("Constraseña")]
        [StringLength(15, ErrorMessage = "La contraseña debe contener entre 8 y 15 caracteres", MinimumLength = 8)]
        public String Password { get; set; }

        /*
        [Required(ErrorMessage = "Este campo es obligatorio"), DataType(DataType.Password), DisplayName("Confirmar Constraseña")]
        [StringLength(15, ErrorMessage = "La contraseña debe contener entre 8 y 15 caracteres", MinimumLength = 8)]
        [System.ComponentModel.DataAnnotations.Compare(User.Password, ErrorMessage = "Las contraseñas no son iguales")]
        [NotMapped]
        public String Confirm_Password { get; set; }
        */
        [DisplayName("Tipo de Usuario")]
        public User_Type tipo_Usuario { get; set; }
        public List<Movie> Peliculas_Favoritas { get; set; }
    }
}