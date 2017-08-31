namespace SwirlFeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPostsPropInUserTbl : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "Posted_ById", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "Posted_ById" });
            AlterColumn("dbo.Posts", "Posted_ById", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Posts", "Posted_ById");
            AddForeignKey("dbo.Posts", "Posted_ById", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Posted_ById", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "Posted_ById" });
            AlterColumn("dbo.Posts", "Posted_ById", c => c.String(maxLength: 128));
            CreateIndex("dbo.Posts", "Posted_ById");
            AddForeignKey("dbo.Posts", "Posted_ById", "dbo.AspNetUsers", "Id");
        }
    }
}
