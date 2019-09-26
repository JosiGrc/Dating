namespace Dating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedsexandsexualpreferencefromPersonmodel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.People", "Sex");
            DropColumn("dbo.People", "SexualOrientation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "SexualOrientation", c => c.String());
            AddColumn("dbo.People", "Sex", c => c.String());
        }
    }
}
