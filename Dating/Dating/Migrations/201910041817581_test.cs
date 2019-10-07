namespace Dating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "Person_Id", "dbo.People");
            DropIndex("dbo.People", new[] { "Person_Id" });
            DropColumn("dbo.People", "Person_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Person_Id", c => c.Int());
            CreateIndex("dbo.People", "Person_Id");
            AddForeignKey("dbo.People", "Person_Id", "dbo.People", "Id");
        }
    }
}
