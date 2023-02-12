namespace ResturantFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reviewResturant : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Restaurants", "ReviewId", "dbo.Reviews");
            DropIndex("dbo.Restaurants", new[] { "ReviewId" });
            AddColumn("dbo.Reviews", "Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Reviews", "Id");
            AddForeignKey("dbo.Reviews", "Id", "dbo.Restaurants", "Id", cascadeDelete: true);
            DropColumn("dbo.Restaurants", "ReviewId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "ReviewId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Reviews", "Id", "dbo.Restaurants");
            DropIndex("dbo.Reviews", new[] { "Id" });
            DropColumn("dbo.Reviews", "Id");
            CreateIndex("dbo.Restaurants", "ReviewId");
            AddForeignKey("dbo.Restaurants", "ReviewId", "dbo.Reviews", "ReviewId", cascadeDelete: true);
        }
    }
}
