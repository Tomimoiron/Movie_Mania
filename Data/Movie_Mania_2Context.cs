using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Movie_Mania_2.Data
{
    public class Movie_Mania_2Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Movie_Mania_2Context() : base("name=Movie_Mania_2Context")
        {
        }

        public System.Data.Entity.DbSet<Movie_Mania_2.Models.Movie> Movies { get; set; }

        public System.Data.Entity.DbSet<Movie_Mania_2.Models.User> Users { get; set; }
    }
}
