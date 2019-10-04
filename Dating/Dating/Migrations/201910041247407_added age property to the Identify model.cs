namespace Dating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedagepropertytotheIdentifymodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Identifies", "Age", c => c.Int(nullable: false));
            DropColumn("dbo.People", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Age", c => c.Int(nullable: false));
            DropColumn("dbo.Identifies", "Age");
        }
    }
}
