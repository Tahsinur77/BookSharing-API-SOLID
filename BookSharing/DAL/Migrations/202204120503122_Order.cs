namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Order : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShopChangeRequests", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.ShopChangeRequests", "ShopNumber", c => c.String(nullable: false));
            AlterColumn("dbo.ShopChangeRequests", "ShopDocuments", c => c.String(nullable: false));
            AlterColumn("dbo.ShopChangeRequests", "Location", c => c.String(nullable: false));
            AlterColumn("dbo.ShopChangeRequests", "Status", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShopChangeRequests", "Status", c => c.String());
            AlterColumn("dbo.ShopChangeRequests", "Location", c => c.String());
            AlterColumn("dbo.ShopChangeRequests", "ShopDocuments", c => c.String());
            AlterColumn("dbo.ShopChangeRequests", "ShopNumber", c => c.String());
            AlterColumn("dbo.ShopChangeRequests", "Name", c => c.String());
        }
    }
}
