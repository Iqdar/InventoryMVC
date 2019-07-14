namespace InventoryMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datatypesUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ClientOrders", "bill", c => c.Int(nullable: false));
            AlterColumn("dbo.Items", "sellingPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.ClientPayments", "amountPaid", c => c.Int(nullable: false));
            AlterColumn("dbo.VendorOrders", "bill", c => c.Int(nullable: false));
            AlterColumn("dbo.Vendors", "balance", c => c.Int(nullable: false));
            AlterColumn("dbo.VendorPayments", "amountPaid", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VendorPayments", "amountPaid", c => c.Double(nullable: false));
            AlterColumn("dbo.Vendors", "balance", c => c.Double(nullable: false));
            AlterColumn("dbo.VendorOrders", "bill", c => c.Double(nullable: false));
            AlterColumn("dbo.ClientPayments", "amountPaid", c => c.Double(nullable: false));
            AlterColumn("dbo.Items", "sellingPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.ClientOrders", "bill", c => c.Double(nullable: false));
        }
    }
}
