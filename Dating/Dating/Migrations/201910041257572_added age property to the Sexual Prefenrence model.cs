namespace Dating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedagepropertytotheSexualPrefenrencemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SexualPreferences", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SexualPreferences", "Age");
        }
    }
}
