namespace Recepts.MVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_CommentsForNovini_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommentsForNovinis",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Content = c.String(nullable: false, maxLength: 500),
                        Author = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        NoviniId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CommentsForNovinis");
        }
    }
}
