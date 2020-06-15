namespace GameStore.Migrations.GameContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class drop : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Games", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "Description", c => c.String());
        }
    }
}
