namespace App.Model.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Files", "Extention", c => c.String());
            AddColumn("dbo.Files", "OriginPath", c => c.String());
            AddColumn("dbo.Images", "Extention", c => c.String());
            AddColumn("dbo.Images", "OriginPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "OriginPath");
            DropColumn("dbo.Images", "Extention");
            DropColumn("dbo.Files", "OriginPath");
            DropColumn("dbo.Files", "Extention");
        }
    }
}
