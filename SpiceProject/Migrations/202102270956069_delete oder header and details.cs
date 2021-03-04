namespace SpiceProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteoderheaderanddetails : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderHeaders", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.OrderHeaders");
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.OrderHeaders", new[] { "UserId" });
            DropTable("dbo.OrderDetails");
            DropTable("dbo.OrderHeaders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderHeaders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        OrderDate = c.DateTime(nullable: false),
                        OrderTotalOriginal = c.Double(nullable: false),
                        OrderTotal = c.Double(nullable: false),
                        PickUpTime = c.DateTime(nullable: false),
                        CouponCode = c.String(),
                        CouponCodeDiscount = c.Double(nullable: false),
                        Status = c.String(),
                        PaymentStatus = c.String(),
                        Comments = c.String(),
                        PickupName = c.String(),
                        PhoneNumber = c.String(),
                        TransactionId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        MenuItemId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.OrderHeaders", "UserId");
            CreateIndex("dbo.OrderDetails", "OrderId");
            AddForeignKey("dbo.OrderDetails", "OrderId", "dbo.OrderHeaders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderHeaders", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
