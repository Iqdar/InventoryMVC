namespace InventoryMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VendorOrderTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VendorOrders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        quantity = c.Int(nullable: false),
                        bill = c.Double(nullable: false),
                        date = c.DateTime(nullable: false),
                        Items_id = c.Int(),
                        Vendors_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Items", t => t.Items_id)
                .ForeignKey("dbo.Vendors", t => t.Vendors_id)
                .Index(t => t.Items_id)
                .Index(t => t.Vendors_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VendorOrders", "Vendors_id", "dbo.Vendors");
            DropForeignKey("dbo.VendorOrders", "Items_id", "dbo.Items");
            DropIndex("dbo.VendorOrders", new[] { "Vendors_id" });
            DropIndex("dbo.VendorOrders", new[] { "Items_id" });
            DropTable("dbo.VendorOrders");
        }
    }
}
