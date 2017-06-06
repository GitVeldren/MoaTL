namespace MoaTL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCharacterItemPartyName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PlayerId = c.String(nullable: false, maxLength: 128),
                        PlayerClass = c.String(),
                        Wealth = c.Int(),
                        PartyId = c.String(),
                        Party_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parties", t => t.Party_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId)
                .Index(t => t.Party_Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Description = c.String(),
                        Type = c.String(),
                        SubType = c.String(),
                        Character_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.Character_Id)
                .Index(t => t.Character_Id);
            
            CreateTable(
                "dbo.Parties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DungeonMaster_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.DungeonMaster_Id)
                .Index(t => t.DungeonMaster_Id);
            
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "PlayerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Characters", "Party_Id", "dbo.Parties");
            DropForeignKey("dbo.Parties", "DungeonMaster_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Items", "Character_Id", "dbo.Characters");
            DropIndex("dbo.Parties", new[] { "DungeonMaster_Id" });
            DropIndex("dbo.Items", new[] { "Character_Id" });
            DropIndex("dbo.Characters", new[] { "Party_Id" });
            DropIndex("dbo.Characters", new[] { "PlayerId" });
            DropColumn("dbo.AspNetUsers", "Name");
            DropTable("dbo.Parties");
            DropTable("dbo.Items");
            DropTable("dbo.Characters");
        }
    }
}
