namespace Dating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Identifies", "Personality", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Identifies", "Personality", c => c.String());
        }
    }
}
