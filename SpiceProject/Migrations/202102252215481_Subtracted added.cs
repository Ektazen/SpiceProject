namespace SpiceProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Subtractedadded : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ShoppingCarts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(),
                        MenuItemId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
