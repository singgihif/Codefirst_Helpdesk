namespace Helpdesk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HelpdeskDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category_Name = c.String(),
                        Ticket_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tickets", t => t.Ticket_Id)
                .Index(t => t.Ticket_Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Department_Name = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Holidays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dates = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Roles = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Phone = c.Int(nullable: false),
                        Email = c.String(),
                        Department_id = c.Int(nullable: false),
                        Roles_id = c.Int(nullable: false),
                        Ticket_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tickets", t => t.Ticket_Id)
                .Index(t => t.Ticket_Id);
            
            CreateTable(
                "dbo.Subcategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subcategory_Name = c.String(),
                        subcategory_id = c.Int(nullable: false),
                        Subcategory_Id = c.Int(),
                        Ticket_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subcategories", t => t.Subcategory_Id)
                .ForeignKey("dbo.Tickets", t => t.Ticket_Id)
                .Index(t => t.Subcategory_Id)
                .Index(t => t.Ticket_Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type_id = c.Int(nullable: false),
                        Description = c.String(),
                        Dtm_Crt = c.DateTime(nullable: false),
                        L1 = c.String(),
                        Duedate = c.DateTime(nullable: false),
                        Last_update = c.DateTime(nullable: false),
                        Onprogressdate = c.DateTime(nullable: false),
                        Onwaitingdate = c.DateTime(nullable: false),
                        Onholddate = c.DateTime(nullable: false),
                        Resolvedtime = c.DateTime(nullable: false),
                        Closedtime = c.DateTime(nullable: false),
                        Technician = c.DateTime(nullable: false),
                        Status = c.DateTime(nullable: false),
                        User_id = c.DateTime(nullable: false),
                        Category_id = c.DateTime(nullable: false),
                        Subcategory_id = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Interval = c.Int(nullable: false),
                        Ticket_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tickets", t => t.Ticket_Id)
                .Index(t => t.Ticket_Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Role_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Role_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Role_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Ticket_Id", "dbo.Tickets");
            DropForeignKey("dbo.Types", "Ticket_Id", "dbo.Tickets");
            DropForeignKey("dbo.Subcategories", "Ticket_Id", "dbo.Tickets");
            DropForeignKey("dbo.Categories", "Ticket_Id", "dbo.Tickets");
            DropForeignKey("dbo.Subcategories", "Subcategory_Id", "dbo.Subcategories");
            DropForeignKey("dbo.UserRoles", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Departments", "User_Id", "dbo.Users");
            DropIndex("dbo.UserRoles", new[] { "Role_Id" });
            DropIndex("dbo.UserRoles", new[] { "User_Id" });
            DropIndex("dbo.Types", new[] { "Ticket_Id" });
            DropIndex("dbo.Subcategories", new[] { "Ticket_Id" });
            DropIndex("dbo.Subcategories", new[] { "Subcategory_Id" });
            DropIndex("dbo.Users", new[] { "Ticket_Id" });
            DropIndex("dbo.Departments", new[] { "User_Id" });
            DropIndex("dbo.Categories", new[] { "Ticket_Id" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Types");
            DropTable("dbo.Tickets");
            DropTable("dbo.Subcategories");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Holidays");
            DropTable("dbo.Departments");
            DropTable("dbo.Categories");
        }
    }
}
