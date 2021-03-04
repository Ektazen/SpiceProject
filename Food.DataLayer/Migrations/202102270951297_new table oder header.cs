namespace Food.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtableoderheader : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderHeaders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OrderHeaders");
        }
    }
}
