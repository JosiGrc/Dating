namespace Dating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedgeocodemodelwiththeneededprprtiesalsoaddedlatitudeandlogitudepropertestopersonmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "longitute", c => c.Double(nullable: false));
            AddColumn("dbo.People", "latitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "latitude");
            DropColumn("dbo.People", "longitute");
        }
    }
}
