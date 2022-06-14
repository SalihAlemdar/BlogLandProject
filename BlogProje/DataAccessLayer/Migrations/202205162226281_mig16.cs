namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "AuthorStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Authors", "CategoryStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authors", "CategoryStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Authors", "AuthorStatus");
        }
    }
}
