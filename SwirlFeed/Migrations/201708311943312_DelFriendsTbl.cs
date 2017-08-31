namespace SwirlFeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelFriendsTbl : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Friends", "User1Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friends", "User2_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Friends", new[] { "User1Id" });
            DropIndex("dbo.Friends", new[] { "User2_Id" });
            DropTable("dbo.Friends");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        User1Id = c.String(nullable: false, maxLength: 128),
                        User2Id = c.String(nullable: false, maxLength: 128),
                        User2_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.User1Id, t.User2Id });
            
            CreateIndex("dbo.Friends", "User2_Id");
            CreateIndex("dbo.Friends", "User1Id");
            AddForeignKey("dbo.Friends", "User2_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Friends", "User1Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
