namespace MoaTL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePartyPutDMAsUserAgain : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Parties", "DungeonMasterId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Parties", "DungeonMasterId");
            AddForeignKey("dbo.Parties", "DungeonMasterId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parties", "DungeonMasterId", "dbo.AspNetUsers");
            DropIndex("dbo.Parties", new[] { "DungeonMasterId" });
            AlterColumn("dbo.Parties", "DungeonMasterId", c => c.String());
        }
    }
}
