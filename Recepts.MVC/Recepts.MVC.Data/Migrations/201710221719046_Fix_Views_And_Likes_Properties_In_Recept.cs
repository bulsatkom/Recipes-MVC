namespace Recepts.MVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix_Views_And_Likes_Properties_In_Recept : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recepts", "Views", c => c.Int(nullable: false));
            AlterColumn("dbo.Recepts", "Likes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recepts", "Likes", c => c.Int());
            AlterColumn("dbo.Recepts", "Views", c => c.Int());
        }
    }
}
