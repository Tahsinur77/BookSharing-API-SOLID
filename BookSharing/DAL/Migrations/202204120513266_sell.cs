namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sell : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sells",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            AddColumn("dbo.OrderDetails", "Status", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropIndex("dbo.Sells", new[] { "OrderId" });
            DropForeignKey("dbo.Sells", "OrderId", "dbo.Orders");
            DropColumn("dbo.OrderDetails", "Status");
            DropTable("dbo.Sells");
        }
    }
}
