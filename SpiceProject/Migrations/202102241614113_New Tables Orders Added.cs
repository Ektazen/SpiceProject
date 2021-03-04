namespace SpiceProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTablesOrdersAdded : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderHeaders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "StreetAddress", c => c.String());
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "State", c => c.String());
            AddColumn("dbo.AspNetUsers", "PostalCode", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.OrderHeaders");
            DropForeignKey("dbo.OrderHeaders", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.OrderHeaders", new[] { "UserId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropColumn("dbo.AspNetUsers", "PostalCode");
            DropColumn("dbo.AspNetUsers", "State");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "StreetAddress");
            DropColumn("dbo.AspNetUsers", "Name");
            DropTable("dbo.OrderHeaders");
            DropTable("dbo.OrderDetails");
        }
    }
}
