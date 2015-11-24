namespace Yioulaieuwechat.Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offers", "StartDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Offers", "Start_Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Offers", "Start_Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Offers", "StartDate");
        }
    }
}
