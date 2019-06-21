namespace EF6WithMiniProfiler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(),
                        BlogDescription = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InternalBlogs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Title = c.String(),
                        BloggerName = c.String(maxLength: 50),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdate = c.DateTime(nullable: false),
                        blogDetail_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogDetails", t => t.blogDetail_Id)
                .Index(t => t.blogDetail_Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Content = c.String(),
                        Rating = c.Int(nullable: false),
                        BlogId = c.Int(nullable: false),
                        Updatedby_Id = c.Int(),
                        Createdby_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InternalBlogs", t => t.BlogId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Updatedby_Id)
                .ForeignKey("dbo.People", t => t.Createdby_Id)
                .Index(t => t.Rating)
                .Index(t => t.BlogId)
                .Index(t => t.Updatedby_Id)
                .Index(t => t.Createdby_Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        URL = c.String(),
                        Post_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .Index(t => t.Post_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Passports",
                c => new
                    {
                        PassportNumber = c.Int(nullable: false),
                        IssuingContry = c.String(nullable: false, maxLength: 128),
                        Issued = c.DateTime(nullable: false),
                        Expires = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.PassportNumber, t.IssuingContry });
            
            CreateTable(
                "dbo.PassportStamps",
                c => new
                    {
                        PassportNumber = c.Int(nullable: false),
                        IssuingCountry = c.String(maxLength: 128),
                        StampId = c.Int(nullable: false, identity: true),
                        Stamped = c.DateTime(nullable: false),
                        StampingCountry = c.String(),
                    })
                .PrimaryKey(t => t.StampId)
                .ForeignKey("dbo.Passports", t => new { t.PassportNumber, t.IssuingCountry })
                .Index(t => new { t.PassportNumber, t.IssuingCountry });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PassportStamps", new[] { "PassportNumber", "IssuingCountry" }, "dbo.Passports");
            DropForeignKey("dbo.Posts", "Createdby_Id", "dbo.People");
            DropForeignKey("dbo.Posts", "Updatedby_Id", "dbo.People");
            DropForeignKey("dbo.Comments", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Posts", "BlogId", "dbo.InternalBlogs");
            DropForeignKey("dbo.InternalBlogs", "blogDetail_Id", "dbo.BlogDetails");
            DropIndex("dbo.PassportStamps", new[] { "PassportNumber", "IssuingCountry" });
            DropIndex("dbo.Comments", new[] { "Post_Id" });
            DropIndex("dbo.Posts", new[] { "Createdby_Id" });
            DropIndex("dbo.Posts", new[] { "Updatedby_Id" });
            DropIndex("dbo.Posts", new[] { "BlogId" });
            DropIndex("dbo.Posts", new[] { "Rating" });
            DropIndex("dbo.InternalBlogs", new[] { "blogDetail_Id" });
            DropTable("dbo.PassportStamps");
            DropTable("dbo.Passports");
            DropTable("dbo.People");
            DropTable("dbo.Comments");
            DropTable("dbo.Posts");
            DropTable("dbo.InternalBlogs");
            DropTable("dbo.BlogDetails");
        }
    }
}
