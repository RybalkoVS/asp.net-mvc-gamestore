namespace GameStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Cart_Id", c => c.Int());
            CreateIndex("dbo.Users", "Cart_Id");
            AddForeignKey("dbo.Users", "Cart_Id", "dbo.Carts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.Users", new[] { "Cart_Id" });
            DropColumn("dbo.Users", "Cart_Id");
            DropTable("dbo.Carts");
        }
    }
}
