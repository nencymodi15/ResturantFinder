namespace ResturantFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingrows : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "ReviewsDes", c => c.String());
            DropColumn("dbo.Reviews", "ReviewsData");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "ReviewsData", c => c.Int(nullable: false));
            DropColumn("dbo.Reviews", "ReviewsDes");
        }
    }
}
