namespace Recepts.MVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Novini_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Novinis",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Image = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 1000),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Novinis");
        }
    }
}
