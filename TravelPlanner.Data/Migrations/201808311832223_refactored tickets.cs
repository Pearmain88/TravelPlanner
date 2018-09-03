namespace TravelPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactoredtickets : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ticket", "TicketType", c => c.Int(nullable: false));
            AddColumn("dbo.Ticket", "TicketLink", c => c.String());
            DropColumn("dbo.Ticket", "Identification");
            DropColumn("dbo.Ticket", "TravelTickets");
            DropColumn("dbo.Ticket", "ActivityTickets");
            DropColumn("dbo.Ticket", "Receipts");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ticket", "Receipts", c => c.String());
            AddColumn("dbo.Ticket", "ActivityTickets", c => c.String());
            AddColumn("dbo.Ticket", "TravelTickets", c => c.String());
            AddColumn("dbo.Ticket", "Identification", c => c.String());
            DropColumn("dbo.Ticket", "TicketLink");
            DropColumn("dbo.Ticket", "TicketType");
        }
    }
}
