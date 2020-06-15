namespace GameStore.Migrations.GameContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class purchases : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Purchases", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Purchases", "Person");
            DropColumn("dbo.Purchases", "GameId");
            DropColumn("dbo.Purchases", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Purchases", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Purchases", "GameId", c => c.Int(nullable: false));
            AddColumn("dbo.Purchases", "Person", c => c.String());
            AlterColumn("dbo.Purchases", "Email", c => c.String());
            DropColumn("dbo.Purchases", "Total");
        }
    }
}
