namespace Recepts.MVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_UniqueID_To_Recept_For_day : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ReceptForDays", "Id", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.ReceptForDays", new[] { "Id" });
        }
    }
}
