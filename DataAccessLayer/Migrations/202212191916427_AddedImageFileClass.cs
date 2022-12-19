namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageFileClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageFiles",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Path = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ImageId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ImageFiles");
        }
    }
}
