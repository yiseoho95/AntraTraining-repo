using System;
using System.Collections.Generic;
using System.Text;
using ClassReview031621.Utility;
using ClassReview031621.Data.Models;
using ClassReview031621.Data.Repositories;

namespace ClassReview031621.UI
{
    class ManageDepartment
    {
        IRepository<Department> departmentRepository; //upcasting
        public ManageDepartment()
        {
            departmentRepository = new DepartmentRepository();
        }
        void PrintAllDepartment()
        {
            List<Department> deptCollection = departmentRepository.GetAll();
            int length = deptCollection.Count;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(deptCollection[i].Id + " \t " + deptCollection[i].DepartmentName + " \t "+ deptCollection[i].Location);

            }
        }
        void DeleteDepartment()
        {
            Console.Write("Enter Id => ");
            int id = Convert.ToInt32(Console.ReadLine());
            departmentRepository.Delete(id);
            Console.WriteLine("Department deleted successfully");
        }
        void UpdateDepartment()
        {
            Department department = new Department();
            Console.Write("Enter Id => ");
            department.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Name => ");
            department.DepartmentName = Console.ReadLine();

            Console.Write("Enter Location => ");
            department.Location = Console.ReadLine();

            departmentRepository.Update(department);
            Console.WriteLine("Department updated successfully");
        }

        void InsertDepartment()
        {
            try
            {
                Department department = new Department();
                Console.Write("Enter Id => ");
                department.Id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Name => ");
                department.DepartmentName = Console.ReadLine();

                Console.Write("Enter Location => ");
                department.Location = Console.ReadLine();

                departmentRepository.Update(department);
                Console.WriteLine("Department added successfully");
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Only numbers are allowed");
            }
            catch (StackOverflowException oe)
            {
                Console.WriteLine("Value must be in between 1 to "  + int.MaxValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Some errors have occurred. Contact the Admin department");
            }
        }

        public void Run()
        {
            int choice = 0;

            do
            {
                Menu m = new Menu();
                choice = m.Print();
                switch (choice)
                {
                    case (int)MenuOptions.Insert:
                        InsertDepartment();
                        break;
                    case (int)MenuOptions.Delete:
                        DeleteDepartment();
                        break;
                    case (int)MenuOptions.Print:
                        PrintAllDepartment();
                        break;
                    case (int)MenuOptions.Update:
                        UpdateDepartment();
                        break;
                    case (int)MenuOptions.Exit:
                        Console.WriteLine("Thanks for visiting. Please Visit Again!!!");
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
                Console.WriteLine("Press Enter to continue.......");
                Console.ReadLine();
                Console.Clear();
            } while (choice != (int)MenuOptions.Exit);
        }
    }
}
