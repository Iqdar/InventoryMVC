namespace InventoryMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemTableUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Storages", "Items_id", "dbo.Items");
            DropIndex("dbo.Storages", new[] { "Items_id" });
            AddColumn("dbo.Items", "quantity", c => c.Int(nullable: false));
            DropTable("dbo.Storages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Storages",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        quantity = c.Int(nullable: false),
                        Items_id = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            DropColumn("dbo.Items", "quantity");
            CreateIndex("dbo.Storages", "Items_id");
            AddForeignKey("dbo.Storages", "Items_id", "dbo.Items", "id");
        }
    }
}
