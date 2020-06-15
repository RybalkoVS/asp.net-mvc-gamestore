namespace GameStore.Migrations.GameContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upd2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchases", "UserId");
        }
    }
}
