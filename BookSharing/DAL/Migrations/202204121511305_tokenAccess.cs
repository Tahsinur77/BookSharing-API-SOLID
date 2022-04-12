namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tokenAccess : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TokenAccesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Token = c.String(nullable: false),
                        Createdat = c.DateTime(nullable: false),
                        Expiredat = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.TokenAccesses", new[] { "UserId" });
            DropForeignKey("dbo.TokenAccesses", "UserId", "dbo.Users");
            DropTable("dbo.TokenAccesses");
        }
    }
}
