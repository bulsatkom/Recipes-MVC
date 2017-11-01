namespace Recepts.MVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Date_To_Recept_For_day : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReceptForDays", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ReceptForDays", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.ReceptForDays", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.ReceptForDays", "Descrption", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ReceptForDays", "Descrption", c => c.String());
            AlterColumn("dbo.ReceptForDays", "Image", c => c.String());
            AlterColumn("dbo.ReceptForDays", "Title", c => c.String());
            DropColumn("dbo.ReceptForDays", "Date");
        }
    }
}
