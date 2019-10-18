namespace Dating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedthedistancepropertyinindetifymodelandmovedittotheSexualpreferencetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SexualPreferences", "Miles", c => c.Int(nullable: false));
            DropColumn("dbo.Identifies", "Miles");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Identifies", "Miles", c => c.Int(nullable: false));
            DropColumn("dbo.SexualPreferences", "Miles");
        }
    }
}
