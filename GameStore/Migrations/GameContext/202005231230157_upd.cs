namespace GameStore.Migrations.GameContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Games", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Games", "LicenseKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "LicenseKey", c => c.String());
            AlterColumn("dbo.Games", "Price", c => c.Int(nullable: false));
        }
    }
}
