namespace Invoicer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTransaction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvoiceTransaction", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InvoiceTransaction", "Quantity");
        }
    }
}
