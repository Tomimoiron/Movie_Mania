namespace Movie_Mania_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_model_modification_1 : DbMigration
    {
        public override void Up()
        {


            AddColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Movies", "Nombre", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Movies", "Sinopsis", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Users", "Nombre", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "Apellido", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "Usuario", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "Mail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Mail", c => c.String());
            AlterColumn("dbo.Users", "Usuario", c => c.String());
            AlterColumn("dbo.Users", "Apellido", c => c.String());
            AlterColumn("dbo.Users", "Nombre", c => c.String());
            AlterColumn("dbo.Movies", "Sinopsis", c => c.String());
            AlterColumn("dbo.Movies", "Nombre", c => c.String());
        }
    }
}
