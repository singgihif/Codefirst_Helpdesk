using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpdesk.Models;
using Helpdesk.Controllers;

namespace Helpdesk.Controllers
{
    class RolesController
    {
        baseContext _context = new baseContext();
        int input;
        public void Menu()
        {
            System.Console.WriteLine("=====================");
            System.Console.WriteLine("1. Get All");
            System.Console.WriteLine("2. Get By Id");
            System.Console.WriteLine("3. Insert");
            System.Console.WriteLine("4. Update");
            System.Console.WriteLine("5. Delete");
            System.Console.WriteLine("=====================");
            System.Console.Write("pilihan kalian : ");
            int choice = Convert.ToInt32(System.Console.ReadLine());
            switch (choice)
            {
                case 1:
                    GetAll();
                    System.Console.Read();
                    break;
                case 2:
                    System.Console.Write("Masukkan Id yang ingin di cari : ");
                    input = Convert.ToInt32(System.Console.ReadLine());
                    GetById(input);
                    System.Console.Read();
                    break;
                case 3:
                    Insert();
                    System.Console.Read();
                    break;
                case 4:
                    System.Console.Write("Masukkan Id yang ingin di ubah : ");
                    input = Convert.ToInt32(System.Console.ReadLine());
                    Update(input);
                    System.Console.Read();
                    break;
                case 5:
                    System.Console.Write("Masukkan Id yang ingin hapus : ");
                    input = Convert.ToInt32(System.Console.ReadLine());
                    Delete(input);
                    System.Console.Read();
                    break;
                default:
                    System.Console.Write("Periksa kembali");
                    System.Console.Read();
                    break;

            }
        }

        public void Insert()
        {
            Console.Clear();
            System.Console.Write("Masukkan Nama Departemen : ");
            string Nama_Rules = System.Console.ReadLine();
            System.Console.Write("Masukkan Id Departemen : ");
            int Id_rules = Convert.ToInt32(System.Console.ReadLine());
            var getdept = _context.Roles.Find(Id_rules);
            Role rules = new Role()
            {
                Id = Id_rules,
                Roles = Nama_Rules
            };
            try
            {
                _context.Roles.Add(rules);
                var result = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.InnerException);
            }
        }

        public int Update(int input)
        {
            System.Console.WriteLine("Masukkan Nama Roles : ");
            string Nama_Rules = System.Console.ReadLine();
            Role rule = GetById(input);
            department.Roles = Nama_Rules;
            _context.Entry(department).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return input;
        }


        public List<Department> GetAll()
        {
            var getall = _context.Departments.ToList();
            foreach (Department department in getall)
            {
                System.Console.WriteLine("================");
                System.Console.WriteLine("Id : " + department.Id);
                System.Console.WriteLine("Nama Departemen : " + department.Department_Name);
                System.Console.WriteLine("================");
            }
            return getall;
        }

        public void Delete(int input)
        {
            var department = _context.Departments.FirstOrDefault(x => x.Id == input);
            try
            {
                if (department == null)
                {
                    System.Console.WriteLine("Id Tidak Tersedia");
                }
                else
                {
                    var x = (from y in _context.Departments
                             where y.Id == input
                             select y).FirstOrDefault();
                    _context.Departments.Remove(x);
                    _context.SaveChanges();
                    System.Console.WriteLine("Hapus Data Sukses");
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.InnerException);
            }
        }

        public Department GetById(int input)
        {
            var department = _context.Departments.FirstOrDefault(x => x.Id == input);
            if (department == null)
            {
                System.Console.WriteLine("Id tersebut tidak ada");
            }
            else if (department.Id == input)
            {
                Console.WriteLine("Kode Departemen : " + department.Id);
                Console.WriteLine("Nama Siswa : " + department.Department_Name);
            }
            return department;
        }
    }
}
