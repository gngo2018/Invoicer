namespace Invoicer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataCleanUp : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.InvoiceTransaction", "GrandTotal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InvoiceTransaction", "GrandTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
