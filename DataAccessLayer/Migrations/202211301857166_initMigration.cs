namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        AboutId = c.Int(nullable: false, identity: true),
                        Details1 = c.String(maxLength: 1000),
                        Details2 = c.String(maxLength: 1000),
                        Image1 = c.String(maxLength: 100),
                        Image2 = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.AboutId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Headings",
                c => new
                    {
                        HeadingId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        WriterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HeadingId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Writers", t => t.WriterId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.WriterId);
            
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        ContentId = c.Int(nullable: false, identity: true),
                        Value = c.String(maxLength: 1000),
                        CreatedAt = c.DateTime(nullable: false),
                        HeadingId = c.Int(nullable: false),
                        WriterId = c.Int(),
                    })
                .PrimaryKey(t => t.ContentId)
                .ForeignKey("dbo.Headings", t => t.HeadingId, cascadeDelete: true)
                .ForeignKey("dbo.Writers", t => t.WriterId)
                .Index(t => t.HeadingId)
                .Index(t => t.WriterId);
            
            CreateTable(
                "dbo.Writers",
                c => new
                    {
                        WriterId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        Image = c.String(maxLength: 100),
                        Email = c.String(maxLength: 200),
                        Password = c.String(maxLength: 200),
                        About = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.WriterId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        UserMail = c.String(maxLength: 50),
                        Subject = c.String(maxLength: 50),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.ContactId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Headings", "WriterId", "dbo.Writers");
            DropForeignKey("dbo.Contents", "WriterId", "dbo.Writers");
            DropForeignKey("dbo.Contents", "HeadingId", "dbo.Headings");
            DropForeignKey("dbo.Headings", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Contents", new[] { "WriterId" });
            DropIndex("dbo.Contents", new[] { "HeadingId" });
            DropIndex("dbo.Headings", new[] { "WriterId" });
            DropIndex("dbo.Headings", new[] { "CategoryId" });
            DropTable("dbo.Contacts");
            DropTable("dbo.Writers");
            DropTable("dbo.Contents");
            DropTable("dbo.Headings");
            DropTable("dbo.Categories");
            DropTable("dbo.Abouts");
        }
    }
}
