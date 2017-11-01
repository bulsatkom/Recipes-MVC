namespace Recepts.MVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix_Recept_And_Clear_ReceptForDay : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ReceptForDays", new[] { "Id" });
            AddColumn("dbo.Recepts", "ReceptForDay", c => c.DateTime());
            DropTable("dbo.ReceptForDays");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ReceptForDays",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Image = c.String(nullable: false),
                        Descrption = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Type = c.String(nullable: false),
                        Kitchen = c.String(nullable: false),
                        CookingTime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Recepts", "ReceptForDay");
            CreateIndex("dbo.ReceptForDays", "Id", unique: true);
        }
    }
}
