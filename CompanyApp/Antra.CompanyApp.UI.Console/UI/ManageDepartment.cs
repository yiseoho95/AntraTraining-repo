using System;
using System.Collections.Generic;
using System.Text;
using Antra.CompanyApp.Data.Models;
using Antra.CompanyApp.Services;

namespace Antra.CompanyApp.UI.ConsoleApp.UI
{
    class ManageDepartment
    {
        DeptService deptService;
        public ManageDepartment()
        {
            deptService = new DeptService();
        }

        void AddDepartment()
        {

            Dept d = new Dept();
            Console.Write("Enter Id Number = ");
            d.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Name = ");
            d.DName = Console.ReadLine();
            Console.Write("Enter Location = ");
            d.Loc = Console.ReadLine();

            if (deptService.AddDepartment(d) > 0)
                Console.WriteLine("Department Added");
            else
            {
                Console.WriteLine("Some error");
            }
        }

        void UpdateDepartment()
        {
            Dept d = new Dept();
            Console.Write("Enter Id = ");
            d.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Name = ");
            d.DName = Console.ReadLine();
            Console.Write("Enter Location = ");
            d.Loc = Console.ReadLine();

            if (deptService.UpdateDepartment(d) > 0)
                Console.WriteLine("Department Updated");
            else
            {
                Console.WriteLine("Some error");
            }
        }

        void DeleteDepartment()
        {
            Dept d = new Dept();

            Console.Write("Enter Name = ");
            d.DName = Console.ReadLine();

            if (deptService.DeleteDepartment(d.Id) > 0)
                Console.WriteLine("Department Deleted");
            else
            {
                Console.WriteLine("Some error");
            }
        }

        void PrintAll()
        {
            IEnumerable<Dept> deptCollection = deptService.GetAll();
            foreach (Dept item in deptCollection)
            {
                Console.WriteLine(item.Id + " \t " + item.DName+ " \t "+ item.Loc);
            }
        }

        public void Run()
        {
            //AddDepartment();
            UpdateDepartment();
            // DeleteDepartment();
            //PrintAll();
        }
    }
}
