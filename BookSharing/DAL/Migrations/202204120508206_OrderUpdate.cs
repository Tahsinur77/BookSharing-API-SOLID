namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        SellerId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        price = c.String(nullable: false),
                        ShopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Shops", t => t.ShopId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.SellerId, cascadeDelete: false)
                .Index(t => t.BookId)
                .Index(t => t.OrderId)
                .Index(t => t.ShopId)
                .Index(t => t.SellerId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.OrderDetails", new[] { "SellerId" });
            DropIndex("dbo.OrderDetails", new[] { "ShopId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.OrderDetails", new[] { "BookId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropForeignKey("dbo.OrderDetails", "SellerId", "dbo.Users");
            DropForeignKey("dbo.OrderDetails", "ShopId", "dbo.Shops");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "BookId", "dbo.Books");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
        }
    }
}
