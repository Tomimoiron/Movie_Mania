namespace Movie_Mania_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_PrimaryKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "User_Id", "dbo.Users");
            DropIndex("dbo.Movies", new[] { "User_Id" });
            RenameColumn(table: "dbo.Movies", name: "User_Id", newName: "User_Usuario");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Movies", "User_Usuario", c => c.String(maxLength: 20));
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Users", "Usuario");
            CreateIndex("dbo.Movies", "User_Usuario");
            AddForeignKey("dbo.Movies", "User_Usuario", "dbo.Users", "Usuario");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "User_Usuario", "dbo.Users");
            DropIndex("dbo.Movies", new[] { "User_Usuario" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Movies", "User_Usuario", c => c.Int());
            AddPrimaryKey("dbo.Users", "Id");
            RenameColumn(table: "dbo.Movies", name: "User_Usuario", newName: "User_Id");
            CreateIndex("dbo.Movies", "User_Id");
            AddForeignKey("dbo.Movies", "User_Id", "dbo.Users", "Id");
        }
    }
}
