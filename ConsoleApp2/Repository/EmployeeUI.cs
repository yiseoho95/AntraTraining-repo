using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp2.Entities;

namespace ConsoleApp2.Repository
{
    class EmployeeUI
    {
        Employee[] empCollection = new Employee[3];

        void AddEmployee()
        {
            int length = empCollection.Length;
            for (int i = 0; i < length; i++)
            {
                Employee e = new Employee();
                Console.Write("Enter id = ");
                e.Id = Convert.ToInt32( Console.ReadLine());

                Console.Write("Enter Name = ");
                e.FullName= Console.ReadLine();

                Console.Write("Enter Mobile = ");
                e.Mobile = Console.ReadLine();

                Console.Write("Enter Salary = ");
                e.Salary = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Enter Department Name = ");
                e.DepartmentName = Console.ReadLine();

                empCollection[i] = e;
                Console.WriteLine("Employee no" + (i+1) + "isadded");
            }

        }

        void PrintEmployee()
        {
            int length = empCollection.Length;
            Console.WriteLine("Id\tName\tMobile\tSalary\tDepartmentName");

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(empCollection[i].Id+"\t"+empCollection[i].FullName+"\t"+empCollection[i].Mobile+"\t"+empCollection[i].Salary+"\t"+empCollection[i].DepartmentName);
            }
        }


        public void Run()
        {
            AddEmployee();
            PrintEmployee();
        }
    }
}
