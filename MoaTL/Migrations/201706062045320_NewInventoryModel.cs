namespace MoaTL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewInventoryModel : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.InventoryModels");
        }
        
        public override void Down()
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
    }
}
