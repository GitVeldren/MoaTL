namespace MoaTL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCharacterWithName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "PlayerName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Characters", "PlayerName");
        }
    }
}
