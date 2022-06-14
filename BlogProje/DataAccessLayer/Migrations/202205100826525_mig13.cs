namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig13 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Authors", "AuthorRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authors", "AuthorRole", c => c.String(maxLength: 1));
        }
    }
}
