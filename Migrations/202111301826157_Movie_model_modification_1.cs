namespace Movie_Mania_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Movie_model_modification_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Genero", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Genero");
        }
    }
}
