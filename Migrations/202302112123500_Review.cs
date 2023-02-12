namespace ResturantFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Review : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        ResturantName = c.String(),
                        RatingFood = c.Int(nullable: false),
                        RatingAsthetics = c.Int(nullable: false),
                        RatingFeeling = c.Int(nullable: false),
                        ReviewsData = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reviews");
        }
    }
}
