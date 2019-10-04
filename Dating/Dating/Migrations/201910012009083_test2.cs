namespace Dating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Identifies", "PersonId", "dbo.People");
            DropIndex("dbo.Identifies", new[] { "PersonId" });
            AddColumn("dbo.Identifies", "ApplicationId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Identifies", "ApplicationId");
            AddForeignKey("dbo.Identifies", "ApplicationId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Identifies", "PersonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Identifies", "PersonId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Identifies", "ApplicationId", "dbo.AspNetUsers");
            DropIndex("dbo.Identifies", new[] { "ApplicationId" });
            DropColumn("dbo.Identifies", "ApplicationId");
            CreateIndex("dbo.Identifies", "PersonId");
            AddForeignKey("dbo.Identifies", "PersonId", "dbo.People", "Id", cascadeDelete: true);
        }
    }
}
