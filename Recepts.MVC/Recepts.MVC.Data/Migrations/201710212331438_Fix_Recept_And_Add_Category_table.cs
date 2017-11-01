namespace Recepts.MVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix_Recept_And_Add_Category_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id, unique: true);
            
            AddColumn("dbo.Recepts", "CategoryId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Recepts", "CookingTime", c => c.Int(nullable: false));
            CreateIndex("dbo.Recepts", "CategoryId");
            AddForeignKey("dbo.Recepts", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            DropColumn("dbo.Recepts", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recepts", "Type", c => c.String(nullable: false));
            DropForeignKey("dbo.Recepts", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Recepts", new[] { "CategoryId" });
            DropIndex("dbo.Categories", new[] { "Id" });
            AlterColumn("dbo.Recepts", "CookingTime", c => c.String(nullable: false));
            DropColumn("dbo.Recepts", "CategoryId");
            DropTable("dbo.Categories");
        }
    }
}
