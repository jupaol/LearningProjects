namespace ForeignKeys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pending : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_CategoryId" });
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Category_CategoryId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            AddForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
            CreateIndex("dbo.Products", "Category_CategoryId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", new[] { "Category_CategoryId" });
            DropForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories");
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AlterColumn("dbo.Products", "Category_CategoryId", c => c.Guid());
            AlterColumn("dbo.Products", "Name", c => c.String());
            CreateIndex("dbo.Products", "Category_CategoryId");
            AddForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
