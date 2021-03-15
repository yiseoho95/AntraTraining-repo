using System;
using System.Collections.Generic;
using System.Text;
using WeekendWork.entities;

namespace WeekendWork.Repositories
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
                e.Id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Name = ");
                e.FullName = Console.ReadLine();

                Console.Write("Enter Mobile = ");
                e.Mobile = Console.ReadLine();

                Console.Write("Enter Salary = ");
                e.Salary = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Enter Department Name = ");
                e.DepartmentName = Console.ReadLine();

                empCollection[i] = e;
                Console.WriteLine("Employee no" + (i+1) +"is Added");
            }
        }

        void PrintEmployee()
        {
            int length = empCollection.Length;
            Console.WriteLine();
        }
    }
}
