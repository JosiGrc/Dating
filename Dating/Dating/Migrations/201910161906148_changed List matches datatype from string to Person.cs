namespace Dating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedListmatchesdatatypefromstringtoPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Person_Id", c => c.Int());
            CreateIndex("dbo.People", "Person_Id");
            AddForeignKey("dbo.People", "Person_Id", "dbo.People", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Person_Id", "dbo.People");
            DropIndex("dbo.People", new[] { "Person_Id" });
            DropColumn("dbo.People", "Person_Id");
        }
    }
}
