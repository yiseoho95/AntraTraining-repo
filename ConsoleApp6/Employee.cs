using System;
using System.Collections.Generic;
using System.Text;


namespace ConsoleApp6
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        
    }

    class ManageEmployee
    {
        List<Employee> empCollection = new List<Employee>();
        public void AddEmployees()
        {
            empCollection.Add(new Employee() { Id = 1, Name = "Ryan", Department = "IT"});
            empCollection.Add(new Employee() { Id = 2, Name = "Maria", Department = "IT" });
            empCollection.Add(new Employee() { Id = 3, Name = "john", Department = "IT" });
            empCollection.Add(new Employee() { Id = 4, Name = "Scott", Department = "IT" });
        }
        
        public void Print()
        {
            int length = empCollection.Count;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(empCollection[i].Id+" \t "+ empCollection[i].Name +" \t " + empCollection[i].Department);
            }
        }
    }
    class Student
    {
        List<string> studentCollection = new List<string>();
        public void AddStudent()
        {
            studentCollection.Add("Matthew");
            studentCollection.Add("Adicus");
            studentCollection.Add("Seo Ho");
        }

        public void Print()
        {
            int length = studentCollection.Count;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(studentCollection[i]);
            }
        }

        public void Remove(string name)
        {
            studentCollection.Remove(name);
        }
    }
}
