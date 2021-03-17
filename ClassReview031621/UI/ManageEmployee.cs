using System;
using System.Collections.Generic;
using System.Text;
using ClassReview031621.Utility;
using ClassReview031621.Data.Models;
using ClassReview031621.Data.Repositories;

namespace ClassReview031621.UI
{
    class ManageEmployee
    {
        IRepository<Employee> employeeRepository;

        public ManageEmployee()
        {
            employeeRepository = new EmployeeRepository();
        }
        void PrintAllEmployee()
        {
            List<Employee> empCollection = employeeRepository.GetAll();
            int length = empCollection.Count;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(empCollection[i].Id + "\t" + empCollection[i].FirstName + "\t"
+ empCollection[i].LastName + "\t" + empCollection[i].EmailId + "\t" + empCollection[i].Age);
            }
        }
        void DeleteEmployee()
        {
            Console.Write("Enter Id => ");
            int id = Convert.ToInt32(Console.ReadLine());
            employeeRepository.Delete(id);
            Console.WriteLine("Employee deleted successuflly");
        }
        void UpdateEmployee()
        {
            Employee employee = new Employee();

            Console.Write("Enter Id => ");
            employee.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter FirstName => ");
            employee.FirstName = Console.ReadLine();

            Console.Write("Enter LastName => ");
            employee.LastName = Console.ReadLine();

            Console.Write("Enter EmailId => ");
            employee.EmailId = Console.ReadLine();

            Console.Write("Enter Age => ");
            employee.Age = Convert.ToInt32(Console.ReadLine());

            employeeRepository.Update(employee);
            Console.WriteLine("Employee updated successuflly");
        }
        void InsertEmployee()
        {
            try
            {
                Employee employee = new Employee();
                Console.Write("Enter Id => ");
                employee.Id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter FirstName => ");
                employee.FirstName = Console.ReadLine();

                Console.Write("Enter LastName => ");
                employee.LastName = Console.ReadLine();

                Console.Write("Enter EmailId => ");
                employee.EmailId = Console.ReadLine();

                Console.Write("Enter Age => ");
                int age = Convert.ToInt32(Console.ReadLine());
                if (age < 18 || age > 2000)
                {
                    Console.WriteLine("Invalid Age");
                    return;
                }
                else if (age < 0)
                {
                    Console.WriteLine("Invalid Age");
                    return;
                }
                else
                {
                    employee.Age = age;
                }


                employeeRepository.Insert(employee);
                Console.WriteLine("Employee added successfully");
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Only numbers are allowed");
            }
            catch (StackOverflowException oe)
            {
                Console.WriteLine("Value must be in between 1 to " + int.MaxValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Some errors have been occured. Contact the admin department");
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
                        InsertEmployee();
                        break;
                    case (int)MenuOptions.Delete:
                        DeleteEmployee();
                        break;
                    case (int)MenuOptions.Print:
                        PrintAllEmployee();
                        break;
                    case (int)MenuOptions.Update:
                        UpdateEmployee();
                        break;
                    case (int)MenuOptions.Exit:
                        Console.WriteLine("Thanks for visit. Please Visit Again!!!!");
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
                Console.WriteLine("Press Enter to continue......");
                Console.ReadLine();
                Console.Clear();
            } while (choice != (int)MenuOptions.Exit);
        }
    }
}
