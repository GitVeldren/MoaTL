namespace MoaTL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePartyDMIsNumberNow : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Parties", "DungeonMaster_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Parties", new[] { "DungeonMaster_Id" });
            AddColumn("dbo.Parties", "DungeonMasterId", c => c.String());
            DropColumn("dbo.Parties", "DungeonMaster_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parties", "DungeonMaster_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Parties", "DungeonMasterId");
            CreateIndex("dbo.Parties", "DungeonMaster_Id");
            AddForeignKey("dbo.Parties", "DungeonMaster_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
