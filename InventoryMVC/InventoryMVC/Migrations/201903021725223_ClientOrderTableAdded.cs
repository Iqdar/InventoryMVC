namespace InventoryMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientOrderTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientOrders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        quantity = c.Int(nullable: false),
                        bill = c.Double(nullable: false),
                        status = c.String(),
                        date = c.DateTime(nullable: false),
                        Clients_id = c.Int(),
                        Items_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Clients", t => t.Clients_id)
                .ForeignKey("dbo.Items", t => t.Items_id)
                .Index(t => t.Clients_id)
                .Index(t => t.Items_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientOrders", "Items_id", "dbo.Items");
            DropForeignKey("dbo.ClientOrders", "Clients_id", "dbo.Clients");
            DropIndex("dbo.ClientOrders", new[] { "Items_id" });
            DropIndex("dbo.ClientOrders", new[] { "Clients_id" });
            DropTable("dbo.ClientOrders");
        }
    }
}
