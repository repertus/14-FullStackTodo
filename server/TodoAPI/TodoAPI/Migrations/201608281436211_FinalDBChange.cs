namespace TodoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalDBChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Groups", "TodoRefId", "dbo.Todoes");
            DropIndex("dbo.Groups", new[] { "TodoRefId" });
            AddColumn("dbo.Todoes", "GroupRefId", c => c.Int(nullable: false));
            CreateIndex("dbo.Todoes", "GroupRefId");
            AddForeignKey("dbo.Todoes", "GroupRefId", "dbo.Groups", "GroupId", cascadeDelete: true);
            DropColumn("dbo.Groups", "TodoRefId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groups", "TodoRefId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Todoes", "GroupRefId", "dbo.Groups");
            DropIndex("dbo.Todoes", new[] { "GroupRefId" });
            DropColumn("dbo.Todoes", "GroupRefId");
            CreateIndex("dbo.Groups", "TodoRefId");
            AddForeignKey("dbo.Groups", "TodoRefId", "dbo.Todoes", "Id", cascadeDelete: true);
        }
    }
}
