namespace Recepts.MVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Product_And_Recept_Table_And_Fix_ReceptForDay : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Quantity = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        ReceptId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recepts", t => t.ReceptId, cascadeDelete: true)
                .Index(t => t.Id, unique: true)
                .Index(t => t.ReceptId);
            
            CreateTable(
                "dbo.Recepts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Image = c.String(nullable: false),
                        Descrption = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Type = c.String(nullable: false),
                        Kitchen = c.String(nullable: false),
                        CookingTime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id, unique: true);
            
            AddColumn("dbo.ReceptForDays", "Type", c => c.String(nullable: false));
            AddColumn("dbo.ReceptForDays", "Kitchen", c => c.String(nullable: false));
            AddColumn("dbo.ReceptForDays", "CookingTime", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ReceptId", "dbo.Recepts");
            DropIndex("dbo.Recepts", new[] { "Id" });
            DropIndex("dbo.Products", new[] { "ReceptId" });
            DropIndex("dbo.Products", new[] { "Id" });
            DropColumn("dbo.ReceptForDays", "CookingTime");
            DropColumn("dbo.ReceptForDays", "Kitchen");
            DropColumn("dbo.ReceptForDays", "Type");
            DropTable("dbo.Recepts");
            DropTable("dbo.Products");
        }
    }
}
