namespace Invoicer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionTotals : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvoiceTransaction", "ProductTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.InvoiceTransaction", "GrandTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InvoiceTransaction", "GrandTotal");
            DropColumn("dbo.InvoiceTransaction", "ProductTotal");
        }
    }
}
