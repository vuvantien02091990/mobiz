namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateshipadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ShipAddress", c => c.String(maxLength: 50));
            AlterColumn("dbo.OrderDetails", "Price", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderDetails", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Orders", "ShipAddress");
        }
    }
}
