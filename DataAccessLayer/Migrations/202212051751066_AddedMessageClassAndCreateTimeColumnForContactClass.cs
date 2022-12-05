namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMessageClassAndCreateTimeColumnForContactClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "CreatedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "CreatedAt");
        }
    }
}
