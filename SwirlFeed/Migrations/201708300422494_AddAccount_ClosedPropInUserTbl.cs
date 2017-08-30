namespace SwirlFeed.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddAccount_ClosedPropInUserTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Account_Closed", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Account_Closed");
        }
    }
}
