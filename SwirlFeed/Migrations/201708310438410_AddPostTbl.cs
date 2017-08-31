namespace SwirlFeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPostTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        User_Closed = c.Boolean(nullable: false),
                        User_Deleted = c.Boolean(nullable: false),
                        Posted_By_Id = c.String(maxLength: 128),
                        User_To_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Posted_By_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_To_Id)
                .Index(t => t.Posted_By_Id)
                .Index(t => t.User_To_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "User_To_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "Posted_By_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "User_To_Id" });
            DropIndex("dbo.Posts", new[] { "Posted_By_Id" });
            DropTable("dbo.Posts");
        }
    }
}
