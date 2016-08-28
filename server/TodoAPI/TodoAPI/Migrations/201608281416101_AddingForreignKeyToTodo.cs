namespace TodoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingForreignKeyToTodo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Todoes", "GroupRefId", "dbo.Groups");
            DropIndex("dbo.Todoes", new[] { "GroupRefId" });
            AddColumn("dbo.Groups", "TodoRefId", c => c.Int(nullable: false));
            CreateIndex("dbo.Groups", "TodoRefId");
            AddForeignKey("dbo.Groups", "TodoRefId", "dbo.Todoes", "Id", cascadeDelete: true);
            DropColumn("dbo.Todoes", "GroupRefId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Todoes", "GroupRefId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Groups", "TodoRefId", "dbo.Todoes");
            DropIndex("dbo.Groups", new[] { "TodoRefId" });
            DropColumn("dbo.Groups", "TodoRefId");
            CreateIndex("dbo.Todoes", "GroupRefId");
            AddForeignKey("dbo.Todoes", "GroupRefId", "dbo.Groups", "GroupId", cascadeDelete: true);
        }
    }
}
