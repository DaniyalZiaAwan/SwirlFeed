namespace SwirlFeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFriendsTblFor2nd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        User1Id = c.String(nullable: false, maxLength: 128),
                        User2Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.User1Id, t.User2Id })
                .ForeignKey("dbo.AspNetUsers", t => t.User1Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User2Id)
                .Index(t => t.User1Id)
                .Index(t => t.User2Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friends", "User2Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friends", "User1Id", "dbo.AspNetUsers");
            DropIndex("dbo.Friends", new[] { "User2Id" });
            DropIndex("dbo.Friends", new[] { "User1Id" });
            DropTable("dbo.Friends");
        }
    }
}
