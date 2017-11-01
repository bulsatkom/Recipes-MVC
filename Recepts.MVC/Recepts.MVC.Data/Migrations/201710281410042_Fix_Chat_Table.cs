namespace Recepts.MVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix_Chat_Table : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Chats", "Author", c => c.String(nullable: false));
            AlterColumn("dbo.Chats", "Content", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Chats", "Content", c => c.String());
            AlterColumn("dbo.Chats", "Author", c => c.String());
        }
    }
}
