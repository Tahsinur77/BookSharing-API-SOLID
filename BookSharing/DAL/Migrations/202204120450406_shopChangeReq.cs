namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shopChangeReq : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShopChangeRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Name = c.String(),
                        ShopNumber = c.String(),
                        ShopDocuments = c.String(),
                        Location = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ShopChangeRequests", new[] { "UserId" });
            DropForeignKey("dbo.ShopChangeRequests", "UserId", "dbo.Users");
            DropTable("dbo.ShopChangeRequests");
        }
    }
}
