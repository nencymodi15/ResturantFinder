namespace ResturantFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reviewuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reviews", "UserId");
            AddForeignKey("dbo.Reviews", "UserId", "dbo.UserTables", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "UserId", "dbo.UserTables");
            DropIndex("dbo.Reviews", new[] { "UserId" });
            DropColumn("dbo.Reviews", "UserId");
        }
    }
}
