using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpdesk.Controllers;

namespace Helpdesk
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("==============================");
            System.Console.WriteLine("1. Role");
            System.Console.WriteLine("2. User");
            System.Console.WriteLine("3. Category");
            System.Console.WriteLine("4. Subcategory");
            System.Console.WriteLine("5. Department");
            System.Console.WriteLine("6. Holiday");
            System.Console.WriteLine("7. Ticket");
            System.Console.WriteLine("=====================");
            System.Console.Write("pilihan kalian : ");
            int pilih = Convert.ToInt32(System.Console.ReadLine());
            switch (pilih)
            {
                case 5:
                    DepartmentController panggildept = new DepartmentController();
                    panggildept.Menu();
                    break;
                
                default:
                    System.Console.Write("Periksa kembali");
                    System.Console.Read();
                    break;

            }
        }
    }
}
