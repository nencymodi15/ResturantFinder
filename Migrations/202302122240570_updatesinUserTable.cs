namespace ResturantFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatesinUserTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserTables", "BirthdayDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserTables", "BirthdayDate", c => c.DateTime(nullable: false));
        }
    }
}
