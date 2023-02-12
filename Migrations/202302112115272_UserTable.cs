namespace ResturantFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserTables",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        EmailId = c.String(),
                        BirthdayDate = c.DateTime(nullable: false),
                        Nationality = c.String(),
                        Type = c.String(),
                        Gender = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserTables");
        }
    }
}
