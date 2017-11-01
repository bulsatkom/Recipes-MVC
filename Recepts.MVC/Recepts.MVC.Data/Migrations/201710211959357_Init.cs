namespace Recepts.MVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReceptForDays",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Image = c.String(),
                        Descrption = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ReceptForDays");
        }
    }
}
