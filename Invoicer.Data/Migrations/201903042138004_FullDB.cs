namespace Invoicer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FullDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvoiceTransaction",
                c => new
                    {
                        InvoiceTransactionId = c.Int(nullable: false, identity: true),
                        InvoiceId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceTransactionId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        ProductPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Product");
            DropTable("dbo.InvoiceTransaction");
        }
    }
}
