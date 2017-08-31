namespace SwirlFeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFKinPostTbl : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Posts", name: "Posted_By_Id", newName: "Posted_ById");
            RenameColumn(table: "dbo.Posts", name: "User_To_Id", newName: "User_ToId");
            RenameIndex(table: "dbo.Posts", name: "IX_Posted_By_Id", newName: "IX_Posted_ById");
            RenameIndex(table: "dbo.Posts", name: "IX_User_To_Id", newName: "IX_User_ToId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Posts", name: "IX_User_ToId", newName: "IX_User_To_Id");
            RenameIndex(table: "dbo.Posts", name: "IX_Posted_ById", newName: "IX_Posted_By_Id");
            RenameColumn(table: "dbo.Posts", name: "User_ToId", newName: "User_To_Id");
            RenameColumn(table: "dbo.Posts", name: "Posted_ById", newName: "Posted_By_Id");
        }
    }
}
