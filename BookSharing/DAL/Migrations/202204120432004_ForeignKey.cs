namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Role = c.String(nullable: false),
                        Picture = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                        ShopNumber = c.String(nullable: false),
                        Location = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.BookDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SellerId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        ShopId = c.Int(nullable: false),
                        BookQuantity = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Shops", t => t.ShopId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.SellerId, cascadeDelete: false)
                .Index(t => t.BookId)
                .Index(t => t.ShopId)
                .Index(t => t.SellerId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        Price = c.String(nullable: false),
                        Edition = c.String(nullable: false),
                        Publisher = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        Language = c.String(nullable: false),
                        NumberOfPages = c.String(nullable: false),
                        Picture = c.String(nullable: false),
                        ISBN = c.String(nullable: false),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Picture = c.String(nullable: false),
                        Details = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropIndex("dbo.BookDetails", new[] { "SellerId" });
            DropIndex("dbo.BookDetails", new[] { "ShopId" });
            DropIndex("dbo.BookDetails", new[] { "BookId" });
            DropIndex("dbo.Shops", new[] { "UserId" });
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.BookDetails", "SellerId", "dbo.Users");
            DropForeignKey("dbo.BookDetails", "ShopId", "dbo.Shops");
            DropForeignKey("dbo.BookDetails", "BookId", "dbo.Books");
            DropForeignKey("dbo.Shops", "UserId", "dbo.Users");
            DropTable("dbo.Authors");
            DropTable("dbo.Books");
            DropTable("dbo.BookDetails");
            DropTable("dbo.Shops");
            DropTable("dbo.Users");
        }
    }
}
