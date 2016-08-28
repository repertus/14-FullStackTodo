namespace TodoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncludedCompleteOption : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Todoes", "complete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Todoes", "complete");
        }
    }
}
