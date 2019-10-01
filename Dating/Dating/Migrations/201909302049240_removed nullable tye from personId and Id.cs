namespace Dating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removednullabletyefrompersonIdandId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Identifies", "PersonId", "dbo.People");
            DropIndex("dbo.Identifies", new[] { "PersonId" });
            AlterColumn("dbo.Identifies", "PersonId", c => c.Int(nullable: false));
            CreateIndex("dbo.Identifies", "PersonId");
            AddForeignKey("dbo.Identifies", "PersonId", "dbo.People", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Identifies", "PersonId", "dbo.People");
            DropIndex("dbo.Identifies", new[] { "PersonId" });
            AlterColumn("dbo.Identifies", "PersonId", c => c.Int());
            CreateIndex("dbo.Identifies", "PersonId");
            AddForeignKey("dbo.Identifies", "PersonId", "dbo.People", "Id");
        }
    }
}
