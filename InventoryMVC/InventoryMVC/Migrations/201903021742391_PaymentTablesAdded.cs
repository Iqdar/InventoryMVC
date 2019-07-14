namespace InventoryMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentTablesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientPayments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        amountPaid = c.Double(nullable: false),
                        datePaid = c.DateTime(nullable: false),
                        Clients_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Clients", t => t.Clients_id)
                .Index(t => t.Clients_id);
            
            CreateTable(
                "dbo.VendorPayments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        amountPaid = c.Double(nullable: false),
                        datePaid = c.DateTime(nullable: false),
                        Vendors_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Vendors", t => t.Vendors_id)
                .Index(t => t.Vendors_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VendorPayments", "Vendors_id", "dbo.Vendors");
            DropForeignKey("dbo.ClientPayments", "Clients_id", "dbo.Clients");
            DropIndex("dbo.VendorPayments", new[] { "Vendors_id" });
            DropIndex("dbo.ClientPayments", new[] { "Clients_id" });
            DropTable("dbo.VendorPayments");
            DropTable("dbo.ClientPayments");
        }
    }
}
