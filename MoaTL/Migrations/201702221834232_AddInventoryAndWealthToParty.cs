namespace MoaTL.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddInventoryAndWealthToParty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Party_Id", c => c.Int());
            AddColumn("dbo.Parties", "Wealth", c => c.Double(nullable: false));
            CreateIndex("dbo.Items", "Party_Id");
            AddForeignKey("dbo.Items", "Party_Id", "dbo.Parties", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Party_Id", "dbo.Parties");
            DropIndex("dbo.Items", new[] { "Party_Id" });
            DropColumn("dbo.Parties", "Wealth");
            DropColumn("dbo.Items", "Party_Id");
        }
    }
}
