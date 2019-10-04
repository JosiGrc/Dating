namespace Dating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedpropertiestoenumaswithdifferentnames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SexualPreferences", "Gender", c => c.Int(nullable: false));
            AddColumn("dbo.SexualPreferences", "Race", c => c.Int(nullable: false));
            AddColumn("dbo.SexualPreferences", "Personality", c => c.Int(nullable: false));
            DropColumn("dbo.SexualPreferences", "Male");
            DropColumn("dbo.SexualPreferences", "Female");
            DropColumn("dbo.SexualPreferences", "GayMale");
            DropColumn("dbo.SexualPreferences", "GayFemale");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SexualPreferences", "GayFemale", c => c.Boolean(nullable: false));
            AddColumn("dbo.SexualPreferences", "GayMale", c => c.Boolean(nullable: false));
            AddColumn("dbo.SexualPreferences", "Female", c => c.Boolean(nullable: false));
            AddColumn("dbo.SexualPreferences", "Male", c => c.Boolean(nullable: false));
            DropColumn("dbo.SexualPreferences", "Personality");
            DropColumn("dbo.SexualPreferences", "Race");
            DropColumn("dbo.SexualPreferences", "Gender");
        }
    }
}
