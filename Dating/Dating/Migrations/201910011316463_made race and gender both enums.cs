namespace Dating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class maderaceandgenderbothenums : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Identifies", "Gender", c => c.Int(nullable: false));
            AddColumn("dbo.Identifies", "Race", c => c.Int(nullable: false));
            DropColumn("dbo.Identifies", "Male");
            DropColumn("dbo.Identifies", "Female");
            DropColumn("dbo.Identifies", "GayMan");
            DropColumn("dbo.Identifies", "GayFemale");
            DropColumn("dbo.Identifies", "Asian");
            DropColumn("dbo.Identifies", "Black");
            DropColumn("dbo.Identifies", "Indigenous");
            DropColumn("dbo.Identifies", "White");
            DropColumn("dbo.Identifies", "Hispanic");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Identifies", "Hispanic", c => c.Boolean(nullable: false));
            AddColumn("dbo.Identifies", "White", c => c.Boolean(nullable: false));
            AddColumn("dbo.Identifies", "Indigenous", c => c.Boolean(nullable: false));
            AddColumn("dbo.Identifies", "Black", c => c.Boolean(nullable: false));
            AddColumn("dbo.Identifies", "Asian", c => c.Boolean(nullable: false));
            AddColumn("dbo.Identifies", "GayFemale", c => c.Boolean(nullable: false));
            AddColumn("dbo.Identifies", "GayMan", c => c.Boolean(nullable: false));
            AddColumn("dbo.Identifies", "Female", c => c.Boolean(nullable: false));
            AddColumn("dbo.Identifies", "Male", c => c.Boolean(nullable: false));
            DropColumn("dbo.Identifies", "Race");
            DropColumn("dbo.Identifies", "Gender");
        }
    }
}
