namespace TravelPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Budget",
                c => new
                    {
                        BudgetID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        BudgetTitle = c.String(),
                        Transportation = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Lodging = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FoodCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Activities = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Souvenirs = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BudgetID);
            
            CreateTable(
                "dbo.Itinerary",
                c => new
                    {
                        ItineraryID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        Completed = c.Boolean(nullable: false),
                        ActivityName = c.String(nullable: false),
                        ActivityDescription = c.String(nullable: false),
                        ActivityCost = c.Decimal(precision: 18, scale: 2),
                        ActivityDate = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.ItineraryID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Ticket",
                c => new
                    {
                        TicketID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        TicketTitle = c.String(),
                        Identification = c.String(),
                        TravelTickets = c.String(),
                        ActivityTickets = c.String(),
                        Receipts = c.String(),
                    })
                .PrimaryKey(t => t.TicketID);
            
            CreateTable(
                "dbo.Trip",
                c => new
                    {
                        TripID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        TripName = c.String(nullable: false),
                        DepartDate = c.DateTimeOffset(precision: 7),
                        ReturnDate = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.TripID);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Trip");
            DropTable("dbo.Ticket");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Itinerary");
            DropTable("dbo.Budget");
        }
    }
}
