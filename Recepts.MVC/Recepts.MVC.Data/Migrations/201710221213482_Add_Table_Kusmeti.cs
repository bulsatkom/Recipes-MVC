namespace Recepts.MVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Table_Kusmeti : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kusmetis",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Kusmet = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Kusmetis");
        }
    }
}
