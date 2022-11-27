namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangecolumnName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "IsEnabled", c => c.Boolean(nullable: false));
            DropColumn("dbo.Products", "IsEnable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "IsEnable", c => c.Boolean(nullable: false));
            DropColumn("dbo.Products", "IsEnabled");
        }
    }
}
