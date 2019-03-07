namespace Invoicer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ITOwnerId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvoiceTransaction", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InvoiceTransaction", "OwnerId");
        }
    }
}
