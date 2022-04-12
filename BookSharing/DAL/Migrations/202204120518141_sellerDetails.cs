namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sellerDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SellerDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SellerId = c.Int(nullable: false),
                        Nid = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        ShopNumber = c.String(nullable: false),
                        ShopDocuments = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.SellerId, cascadeDelete: true)
                .Index(t => t.SellerId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.SellerDetails", new[] { "SellerId" });
            DropForeignKey("dbo.SellerDetails", "SellerId", "dbo.Users");
            DropTable("dbo.SellerDetails");
        }
    }
}
