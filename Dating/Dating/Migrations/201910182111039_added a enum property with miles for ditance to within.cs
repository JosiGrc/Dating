namespace Dating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedaenumpropertywithmilesforditancetowithin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Identifies", "Miles", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Identifies", "Miles");
        }
    }
}
