﻿namespace ResturantFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingResturant : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Restaurants", "ContactInfo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "ContactInfo", c => c.Int(nullable: false));
        }
    }
}
