namespace Msts.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieAudience : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Audience", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Audience");
        }
    }
}
