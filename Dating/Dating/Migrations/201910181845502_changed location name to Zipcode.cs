namespace Dating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedlocationnametoZipcode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Zipcode", c => c.Int(nullable: false));
            DropColumn("dbo.People", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Location", c => c.Int(nullable: false));
            DropColumn("dbo.People", "Zipcode");
        }
    }
}
