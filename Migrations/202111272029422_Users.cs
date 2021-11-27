namespace Movie_Mania_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Users : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Usuario = c.String(),
                        tipo_Usuario = c.Int(nullable: false),
                        Mail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "User_Id", c => c.Int());
            CreateIndex("dbo.Movies", "User_Id");
            AddForeignKey("dbo.Movies", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "User_Id", "dbo.Users");
            DropIndex("dbo.Movies", new[] { "User_Id" });
            DropColumn("dbo.Movies", "User_Id");
            DropTable("dbo.Users");
        }
    }
}
