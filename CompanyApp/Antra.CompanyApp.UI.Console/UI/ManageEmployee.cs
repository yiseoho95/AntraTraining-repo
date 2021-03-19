using System;
using System.Collections.Generic;
using System.Text;
using Antra.CompanyApp.Data.Models;
using Antra.CompanyApp.Services;

namespace Antra.CompanyApp.UI.ConsoleApp.UI
{
    class ManageEmployee
    {
        EmployeeService employeeService;

        public ManageEmployee()
        {
            employeeService  = new EmployeeService();
        }

        void AddNewEmp()
        {
            Employee e = new Employee();
            Console.Write("Enter Id = ");
            e.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Name = ");
            e.EName = Console.ReadLine();

            Console.Write("Enter Salary = ");
            e.Salary = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Department Id = ");
            e.DeptId = Convert.ToInt32(Console.ReadLine());

            if(employeeService.AddEmployee(e)>0)
                Console.WriteLine("Employee Added");
            else
                Console.WriteLine("Some Error has Occurred");
        }

        void DeleteExistingEmp()
        {
            Console.Write("Enter Id => ");
            int id = Convert.ToInt32(Console.ReadLine());
            if(employeeService.DeleteEmployee(id)>0)
                Console.WriteLine("Employee deleted");
            else
            {
                Console.WriteLine("Some Error has Occurred");
            }
        }

        void UpdateEmp()
        {
            Employee e = new Employee();
            Console.Write("Enter Id => ");
            e.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Name = ");
            e.EName = Console.ReadLine();

            Console.Write("Enter Salary = ");
            e.Salary = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Department Id = ");
            e.DeptId = Convert.ToInt32(Console.ReadLine());

            if (employeeService.AddEmployee(e) > 0)
                Console.WriteLine("Employee Updated");
            else
                Console.WriteLine("Some Error has Occurred");
        }

        public void Run()
        {
            //AddNewEmp();
            // DeleteExistingEmp();
            UpdateEmp();
        }
    }
}
