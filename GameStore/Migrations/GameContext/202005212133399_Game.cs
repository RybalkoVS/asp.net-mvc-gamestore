﻿namespace GameStore.Migrations.GameContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Game : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "LicenseKey", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "LicenseKey");
        }
    }
}
