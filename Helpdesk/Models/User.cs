using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public int Department_id { get; set; }
        public int Roles_id { get; set; }
        public virtual List<Department> Departments { get; set; }
        public virtual List<Role> Roles { get; set; }
    }
    public class Department
    {
        public int Id { get; set; }
        public string Department_Name { get; set; }
    }
    public class Role
    {
        public int Id { get; set; }
        public string Roles { get; set; }
        public virtual List<User> Users { get; set; }
    }

    public class Subcategory
    {
        public int Id { get; set; }
        public string Subcategory_Name { get; set; }
        public int subcategory_id { get; set; }
        public virtual List<Subcategory> Subcategories { get; set; }
    }

    public class Holiday
    {
        public int Id { get; set; }
        public DateTime Dates { get; set; }
        public string Description { get; set; }
    }
    public class Ticket
    {
        public int Id { get; set; }
        public int Type_id { get; set; }
        public string Description { get; set; }
        public DateTime Dtm_Crt { get; set; }
        public string L1 { get; set; }
        public DateTime Duedate { get; set; }
        public DateTime Last_update { get; set; }
        public DateTime Onprogressdate { get; set; }
        public DateTime Onwaitingdate { get; set; }
        public DateTime Onholddate { get; set; }
        public DateTime Resolvedtime { get; set; }
        public DateTime Closedtime { get; set; }
        public DateTime Technician { get; set; }
        public DateTime Status { get; set; }
        public DateTime User_id { get; set; }
        public DateTime Category_id { get; set; }
        public DateTime Subcategory_id { get; set; }
        public virtual List<Type> Types { get; set; }
        public virtual List<User> Users{ get; set; }
        public virtual List<Category> Categories { get; set; }
        public virtual List<Subcategory> Subcategories { get; set; }
    }
    public class Type
    {
        public int Id { get; set; }
        public int Interval { get; set; }
    }
    public class Category
    {
        public int Id { get; set; }
        public string Category_Name { get; set; }
    }
}
