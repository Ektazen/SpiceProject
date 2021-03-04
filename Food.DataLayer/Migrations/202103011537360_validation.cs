namespace Food.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderHeaders", "PickUpDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OrderHeaders", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderHeaders", "UserId", c => c.String(nullable: false));
            DropColumn("dbo.OrderHeaders", "PickUpDate");
        }
    }
}
