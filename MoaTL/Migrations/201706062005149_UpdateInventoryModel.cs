namespace MoaTL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInventoryModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InventoryModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CharacterId = c.Int(nullable: false),
                        Owner = c.String(),
                        Item = c.String(),
                        Value = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InventoryModels");
        }
    }
}
