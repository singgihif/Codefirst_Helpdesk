namespace Helpdesk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRoles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Subcategories", "Subcategory_Id", "dbo.Subcategories");
            DropIndex("dbo.Categories", new[] { "Ticket_Id" });
            DropIndex("dbo.Departments", new[] { "User_Id" });
            DropIndex("dbo.Users", new[] { "Ticket_Id" });
            DropIndex("dbo.Subcategories", new[] { "Subcategory_Id" });
            DropIndex("dbo.Subcategories", new[] { "Ticket_Id" });
            DropIndex("dbo.Types", new[] { "Ticket_Id" });
            DropIndex("dbo.UserRoles", new[] { "User_Id" });
            DropIndex("dbo.UserRoles", new[] { "Role_Id" });
            RenameColumn(table: "dbo.Users", name: "User_Id", newName: "Departments_Id");
            RenameColumn(table: "dbo.Tickets", name: "Ticket_Id", newName: "Categories_Id");
            RenameColumn(table: "dbo.Tickets", name: "Ticket_Id", newName: "Subcategories_Id");
            RenameColumn(table: "dbo.Tickets", name: "Ticket_Id", newName: "Types_Id");
            RenameColumn(table: "dbo.Tickets", name: "Ticket_Id", newName: "Users_Id");
            AddColumn("dbo.Subcategories", "Categories_Id", c => c.Int());
            AlterColumn("dbo.Users", "Roles_Id", c => c.Int());
            CreateIndex("dbo.Subcategories", "Categories_Id");
            CreateIndex("dbo.Users", "Departments_Id");
            CreateIndex("dbo.Users", "Roles_Id");
            CreateIndex("dbo.Tickets", "Categories_Id");
            CreateIndex("dbo.Tickets", "Subcategories_Id");
            CreateIndex("dbo.Tickets", "Types_Id");
            CreateIndex("dbo.Tickets", "Users_Id");
            AddForeignKey("dbo.Subcategories", "Categories_Id", "dbo.Categories", "Id");
            AddForeignKey("dbo.Users", "Roles_Id", "dbo.Roles", "Id");
            DropColumn("dbo.Categories", "Ticket_Id");
            DropColumn("dbo.Departments", "User_Id");
            DropColumn("dbo.Users", "Ticket_Id");
            DropColumn("dbo.Subcategories", "Subcategory_Id");
            DropColumn("dbo.Subcategories", "Ticket_Id");
            DropColumn("dbo.Types", "Ticket_Id");
            DropTable("dbo.UserRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Role_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Role_Id });
            
            AddColumn("dbo.Types", "Ticket_Id", c => c.Int());
            AddColumn("dbo.Subcategories", "Ticket_Id", c => c.Int());
            AddColumn("dbo.Subcategories", "Subcategory_Id", c => c.Int());
            AddColumn("dbo.Users", "Ticket_Id", c => c.Int());
            AddColumn("dbo.Departments", "User_Id", c => c.Int());
            AddColumn("dbo.Categories", "Ticket_Id", c => c.Int());
            DropForeignKey("dbo.Users", "Roles_Id", "dbo.Roles");
            DropForeignKey("dbo.Subcategories", "Categories_Id", "dbo.Categories");
            DropIndex("dbo.Tickets", new[] { "Users_Id" });
            DropIndex("dbo.Tickets", new[] { "Types_Id" });
            DropIndex("dbo.Tickets", new[] { "Subcategories_Id" });
            DropIndex("dbo.Tickets", new[] { "Categories_Id" });
            DropIndex("dbo.Users", new[] { "Roles_Id" });
            DropIndex("dbo.Users", new[] { "Departments_Id" });
            DropIndex("dbo.Subcategories", new[] { "Categories_Id" });
            AlterColumn("dbo.Users", "Roles_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Subcategories", "Categories_Id");
            RenameColumn(table: "dbo.Tickets", name: "Users_Id", newName: "Ticket_Id");
            RenameColumn(table: "dbo.Tickets", name: "Types_Id", newName: "Ticket_Id");
            RenameColumn(table: "dbo.Tickets", name: "Subcategories_Id", newName: "Ticket_Id");
            RenameColumn(table: "dbo.Tickets", name: "Categories_Id", newName: "Ticket_Id");
            RenameColumn(table: "dbo.Users", name: "Departments_Id", newName: "User_Id");
            CreateIndex("dbo.UserRoles", "Role_Id");
            CreateIndex("dbo.UserRoles", "User_Id");
            CreateIndex("dbo.Types", "Ticket_Id");
            CreateIndex("dbo.Subcategories", "Ticket_Id");
            CreateIndex("dbo.Subcategories", "Subcategory_Id");
            CreateIndex("dbo.Users", "Ticket_Id");
            CreateIndex("dbo.Departments", "User_Id");
            CreateIndex("dbo.Categories", "Ticket_Id");
            AddForeignKey("dbo.Subcategories", "Subcategory_Id", "dbo.Subcategories", "Id");
            AddForeignKey("dbo.UserRoles", "Role_Id", "dbo.Roles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserRoles", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
