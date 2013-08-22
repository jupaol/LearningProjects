namespace ForeignKeys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingForeignKeyPropertyToProductTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "Category_CategoryId", newName: "CategoryId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "Category_CategoryId");
        }
    }
}
