namespace Movie_Mania_2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Movie_Mania_2.Data.Movie_Mania_2Context>
    {
        public Configuration()
        {
          //  AutomaticMigrationsEnabled = false;
             AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Movie_Mania_2.Data.Movie_Mania_2Context";
        }

        protected override void Seed(Movie_Mania_2.Data.Movie_Mania_2Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
