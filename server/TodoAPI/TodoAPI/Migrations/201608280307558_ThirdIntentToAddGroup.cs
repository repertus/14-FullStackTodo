namespace TodoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdIntentToAddGroup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.GroupId);
            
            AddColumn("dbo.Todoes", "GroupRefId", c => c.Int(nullable: false));
            CreateIndex("dbo.Todoes", "GroupRefId");
            AddForeignKey("dbo.Todoes", "GroupRefId", "dbo.Groups", "GroupId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Todoes", "GroupRefId", "dbo.Groups");
            DropIndex("dbo.Todoes", new[] { "GroupRefId" });
            DropColumn("dbo.Todoes", "GroupRefId");
            DropTable("dbo.Groups");
        }
    }
}
