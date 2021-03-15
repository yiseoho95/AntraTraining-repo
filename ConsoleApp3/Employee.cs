using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    class  Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        
        public string Mobile { get; set; }
        public string Email { get; set; }

        public virtual void AddEmployee()
        {
            Console.Write("Enter Id => ");
            Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter FullName => ");
            FullName = Console.ReadLine();

            Console.Write("Enter Mobile => ");
            Mobile = Console.ReadLine();

            Console.Write("Enter Email => ");
            Email = Console.ReadLine();
        }

        public virtual void Print()
        {
            Console.WriteLine("Id = "+Id);
            Console.WriteLine("FullName = "+FullName);
            Console.WriteLine("Mobile = "+Mobile);
            Console.WriteLine("Email = " + Email);
        }

        // with the addition of virtual keyword and the override keyord even if i make a variable using upcasting 
        // the upcasting doesn't work and the branch method is called.
    }
    class FullTimeEmployee : Employee
    {
        public decimal Salary { get; set; }
        public string Benefits { get; set; }
        public override void AddEmployee()//AddFullTimeEmployee()
        {
            //base.AddEmployee(); // Base. denotes information coming from the parent class.
            base.AddEmployee();
            Console.Write("Enter Salary = >");
            Salary = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Benefits => ");
            Benefits = Console.ReadLine();
        }

        public override void Print()//PrintFullTimeEmployee()
        {
            base.Print(); // or base.Print();
            Console.WriteLine("Salary = "+ Salary);
            Console.WriteLine( "Benefits = " + Benefits);
        }

    }

    class PartTimeEmployee : Employee
    {
        public decimal HourlySalary { get; set; }
        public string Employer { get; set; }
        
        public override void AddEmployee()//AddPartTimeEmployee()
        {
            base.AddEmployee();
            Console.Write("Enter Hourly Salary = > ");
            HourlySalary = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Employer Name => ");
            Employer = Console.ReadLine();
        }

        public override void Print() //PrintPartTimeEmployee()
        {
            base.Print();
            Console.WriteLine("Hourly Salary = "+HourlySalary);
            Console.WriteLine("Employer = "+Employer);
        }
    }
}
