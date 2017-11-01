namespace Recepts.MVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_SomeProperties_ToReceptTable_And_Add_Comment_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Content = c.String(nullable: false, maxLength: 500),
                        ReceptId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recepts", t => t.ReceptId, cascadeDelete: true)
                .Index(t => t.ReceptId);
            
            AddColumn("dbo.Recepts", "Views", c => c.Int());
            AddColumn("dbo.Recepts", "Likes", c => c.Int());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ReceptId", "dbo.Recepts");
            DropIndex("dbo.Comments", new[] { "ReceptId" });
            DropColumn("dbo.Recepts", "Likes");
            DropColumn("dbo.Recepts", "Views");
            DropTable("dbo.Comments");
        }
    }
}
