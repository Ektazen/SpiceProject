﻿namespace Food.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Shopadded : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Categories",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Coupons",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false),
            //            CouponType = c.String(nullable: false),
            //            Discount = c.Double(nullable: false),
            //            MinimumAmount = c.Double(nullable: false),
            //            Picture = c.Binary(),
            //            IsActive = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.MenuItems",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false),
            //            Description = c.String(),
            //            Spicyness = c.String(),
            //            Image = c.String(),
            //            CategoryId = c.Int(),
            //            SubCategoryId = c.Int(),
            //            Price = c.Double(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Categories", t => t.CategoryId)
            //    .ForeignKey("dbo.SubCategories", t => t.SubCategoryId)
            //    .Index(t => t.CategoryId)
            //    .Index(t => t.SubCategoryId);
            
            //CreateTable(
            //    "dbo.SubCategories",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false),
            //            CategoryId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
            //    .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        AppUserId = c.String(),
                        MenuItemId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartId)
                .ForeignKey("dbo.MenuItems", t => t.MenuItemId, cascadeDelete: true)
                .Index(t => t.MenuItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "MenuItemId", "dbo.MenuItems");
            //DropForeignKey("dbo.MenuItems", "SubCategoryId", "dbo.SubCategories");
            //DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            //DropForeignKey("dbo.MenuItems", "CategoryId", "dbo.Categories");
            DropIndex("dbo.ShoppingCarts", new[] { "MenuItemId" });
            //DropIndex("dbo.SubCategories", new[] { "CategoryId" });
            //DropIndex("dbo.MenuItems", new[] { "SubCategoryId" });
            //DropIndex("dbo.MenuItems", new[] { "CategoryId" });
            DropTable("dbo.ShoppingCarts");
            //DropTable("dbo.SubCategories");
            //DropTable("dbo.MenuItems");
            //DropTable("dbo.Coupons");
            //DropTable("dbo.Categories");
        }
    }
}
