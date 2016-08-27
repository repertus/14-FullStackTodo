namespace TodoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesToDataContext : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Todoes", "Task", c => c.String(nullable: false));
            AlterColumn("dbo.Todoes", "Priority", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Todoes", "Priority", c => c.String());
            AlterColumn("dbo.Todoes", "Task", c => c.String());
        }
    }
}
