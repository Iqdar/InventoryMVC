namespace InventoryMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClientOrders", "Clients_id", "dbo.Clients");
            DropForeignKey("dbo.ClientOrders", "Items_id", "dbo.Items");
            DropForeignKey("dbo.VendorOrders", "Items_id", "dbo.Items");
            DropForeignKey("dbo.VendorOrders", "Vendors_id", "dbo.Vendors");
            DropForeignKey("dbo.VendorPayments", "Vendors_id", "dbo.Vendors");
            DropIndex("dbo.ClientOrders", new[] { "Clients_id" });
            DropIndex("dbo.ClientOrders", new[] { "Items_id" });
            DropIndex("dbo.VendorOrders", new[] { "Items_id" });
            DropIndex("dbo.VendorOrders", new[] { "Vendors_id" });
            DropIndex("dbo.VendorPayments", new[] { "Vendors_id" });
            RenameColumn(table: "dbo.ClientOrders", name: "Clients_id", newName: "ClientsId");
            RenameColumn(table: "dbo.ClientOrders", name: "Items_id", newName: "ItemsId");
            RenameColumn(table: "dbo.ClientPayments", name: "Clients_id", newName: "ClientsId");
            RenameColumn(table: "dbo.VendorOrders", name: "Items_id", newName: "ItemsId");
            RenameColumn(table: "dbo.VendorOrders", name: "Vendors_id", newName: "VendorsId");
            RenameColumn(table: "dbo.VendorPayments", name: "Vendors_id", newName: "VendorsId");
            RenameIndex(table: "dbo.ClientPayments", name: "IX_Clients_id", newName: "IX_ClientsId");
            AlterColumn("dbo.ClientOrders", "ClientsId", c => c.Int(nullable: false));
            AlterColumn("dbo.ClientOrders", "ItemsId", c => c.Int(nullable: false));
            AlterColumn("dbo.VendorOrders", "ItemsId", c => c.Int(nullable: false));
            AlterColumn("dbo.VendorOrders", "VendorsId", c => c.Int(nullable: false));
            AlterColumn("dbo.VendorPayments", "VendorsId", c => c.Int(nullable: false));
            CreateIndex("dbo.ClientOrders", "ClientsId");
            CreateIndex("dbo.ClientOrders", "ItemsId");
            CreateIndex("dbo.VendorOrders", "ItemsId");
            CreateIndex("dbo.VendorOrders", "VendorsId");
            CreateIndex("dbo.VendorPayments", "VendorsId");
            AddForeignKey("dbo.ClientOrders", "ClientsId", "dbo.Clients", "id", cascadeDelete: true);
            AddForeignKey("dbo.ClientOrders", "ItemsId", "dbo.Items", "id", cascadeDelete: true);
            AddForeignKey("dbo.VendorOrders", "ItemsId", "dbo.Items", "id", cascadeDelete: true);
            AddForeignKey("dbo.VendorOrders", "VendorsId", "dbo.Vendors", "id", cascadeDelete: true);
            AddForeignKey("dbo.VendorPayments", "VendorsId", "dbo.Vendors", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VendorPayments", "VendorsId", "dbo.Vendors");
            DropForeignKey("dbo.VendorOrders", "VendorsId", "dbo.Vendors");
            DropForeignKey("dbo.VendorOrders", "ItemsId", "dbo.Items");
            DropForeignKey("dbo.ClientOrders", "ItemsId", "dbo.Items");
            DropForeignKey("dbo.ClientOrders", "ClientsId", "dbo.Clients");
            DropIndex("dbo.VendorPayments", new[] { "VendorsId" });
            DropIndex("dbo.VendorOrders", new[] { "VendorsId" });
            DropIndex("dbo.VendorOrders", new[] { "ItemsId" });
            DropIndex("dbo.ClientOrders", new[] { "ItemsId" });
            DropIndex("dbo.ClientOrders", new[] { "ClientsId" });
            AlterColumn("dbo.VendorPayments", "VendorsId", c => c.Int());
            AlterColumn("dbo.VendorOrders", "VendorsId", c => c.Int());
            AlterColumn("dbo.VendorOrders", "ItemsId", c => c.Int());
            AlterColumn("dbo.ClientOrders", "ItemsId", c => c.Int());
            AlterColumn("dbo.ClientOrders", "ClientsId", c => c.Int());
            RenameIndex(table: "dbo.ClientPayments", name: "IX_ClientsId", newName: "IX_Clients_id");
            RenameColumn(table: "dbo.VendorPayments", name: "VendorsId", newName: "Vendors_id");
            RenameColumn(table: "dbo.VendorOrders", name: "VendorsId", newName: "Vendors_id");
            RenameColumn(table: "dbo.VendorOrders", name: "ItemsId", newName: "Items_id");
            RenameColumn(table: "dbo.ClientPayments", name: "ClientsId", newName: "Clients_id");
            RenameColumn(table: "dbo.ClientOrders", name: "ItemsId", newName: "Items_id");
            RenameColumn(table: "dbo.ClientOrders", name: "ClientsId", newName: "Clients_id");
            CreateIndex("dbo.VendorPayments", "Vendors_id");
            CreateIndex("dbo.VendorOrders", "Vendors_id");
            CreateIndex("dbo.VendorOrders", "Items_id");
            CreateIndex("dbo.ClientOrders", "Items_id");
            CreateIndex("dbo.ClientOrders", "Clients_id");
            AddForeignKey("dbo.VendorPayments", "Vendors_id", "dbo.Vendors", "id");
            AddForeignKey("dbo.VendorOrders", "Vendors_id", "dbo.Vendors", "id");
            AddForeignKey("dbo.VendorOrders", "Items_id", "dbo.Items", "id");
            AddForeignKey("dbo.ClientOrders", "Items_id", "dbo.Items", "id");
            AddForeignKey("dbo.ClientOrders", "Clients_id", "dbo.Clients", "id");
        }
    }
}
