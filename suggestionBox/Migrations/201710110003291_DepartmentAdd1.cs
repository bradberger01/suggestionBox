namespace suggestionBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepartmentAdd1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.suggestionModels", "Department", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.suggestionModels", "Department");
        }
    }
}
