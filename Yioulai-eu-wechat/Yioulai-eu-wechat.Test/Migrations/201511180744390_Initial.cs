namespace Yioulaieuwechat.Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        OfferId = c.String(),
                        UpdateTime = c.DateTime(),
                        CreatedTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OfferId = c.Guid(),
                        SharerId = c.Guid(),
                        WeChatUserId = c.Guid(),
                        UpdateTime = c.DateTime(),
                        CreatedTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WeChatUsers", t => t.WeChatUserId)
                .ForeignKey("dbo.WeChatUsers", t => t.SharerId)
                .ForeignKey("dbo.Offers", t => t.OfferId)
                .Index(t => t.OfferId)
                .Index(t => t.SharerId)
                .Index(t => t.WeChatUserId);
            
            CreateTable(
                "dbo.WeChatUsers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OpenId = c.String(),
                        NickName = c.String(),
                        Gender = c.Int(nullable: false),
                        Language = c.String(),
                        City = c.String(),
                        Province = c.String(),
                        Country = c.String(),
                        Headimgurl = c.String(),
                        CustomerId = c.String(),
                        Mail = c.String(),
                        UpdateTime = c.DateTime(),
                        CreatedTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "OfferId", "dbo.Offers");
            DropForeignKey("dbo.Orders", "SharerId", "dbo.WeChatUsers");
            DropForeignKey("dbo.Orders", "WeChatUserId", "dbo.WeChatUsers");
            DropIndex("dbo.Orders", new[] { "WeChatUserId" });
            DropIndex("dbo.Orders", new[] { "SharerId" });
            DropIndex("dbo.Orders", new[] { "OfferId" });
            DropTable("dbo.WeChatUsers");
            DropTable("dbo.Orders");
            DropTable("dbo.Offers");
        }
    }
}
