namespace TravelPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newitinitem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Itinerary", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Itinerary", "Budget_BudgetID", c => c.Int());
            CreateIndex("dbo.Itinerary", "Budget_BudgetID");
            AddForeignKey("dbo.Itinerary", "Budget_BudgetID", "dbo.Budget", "BudgetID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Itinerary", "Budget_BudgetID", "dbo.Budget");
            DropIndex("dbo.Itinerary", new[] { "Budget_BudgetID" });
            DropColumn("dbo.Itinerary", "Budget_BudgetID");
            DropColumn("dbo.Itinerary", "Type");
        }
    }
}
