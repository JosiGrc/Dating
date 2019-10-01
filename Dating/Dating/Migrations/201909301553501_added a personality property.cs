namespace Dating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedapersonalityproperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Identifies", "Personality", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Identifies", "Personality");
        }
    }
}
