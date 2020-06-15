﻿namespace GameStore.Migrations.GameContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upd3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "ProductName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchases", "ProductName");
        }
    }
}
