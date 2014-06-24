namespace Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddingConstraints : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Authors", new[] {"Name"}, unique: true);
            CreateIndex("dbo.Authors", new[] { "Email" }, unique: true);
            CreateIndex("dbo.Blogs", new[] { "Name" }, unique: true);
            CreateIndex("dbo.Posts", new[] { "Title" }, unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Authors", new[] { "Name" });
            DropIndex("dbo.Authors", new[] { "Email" });
            DropIndex("dbo.Blogs", new[] { "Name" });
            DropIndex("dbo.Posts", new[] { "Title" });
        }
    }
}
