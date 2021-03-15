using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    /*
     * Abstract method is declared inside the abstract Class
     * Abstract method does not have definition but it is overridden into the derived class
     * Abstract method is by default virtual method. It cannot be marked virtual again.(its already virtual)
     * 
     * Abstract class can have both abstract and non abstract methods
     * Abstract classs can not be instantiated
     * abstract class must be inherited and its abstract methods must be implemented by the derived class
     * Only one abstract class can be inherited at a time by the derived class.
     * Abstract class can have a constructor, variables... etc.
     */
    abstract class BaseCustomer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Mobile { get; set; }

        //Creating Constructor
        //public BaseCustomer()
        //{

        //}
        public abstract void LogInfo();

        public void Welcome()
        {
            Console.WriteLine("Welcome to Electronic Store");
        }
        
    }

    class Customer : BaseCustomer
    {
        public decimal BillAmount { get; set; }
        public decimal Discount { get; set; }
        public override void LogInfo()
        {
            Console.Write("Enter Id = > ");
            Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Name => ");
            Name = Console.ReadLine();

            Console.Write("Enter Email Id => ");
            EmailId = Console.ReadLine();

            Console.Write("Enter Mobile => ");
            Mobile = Console.ReadLine();

            Console.Write("Enter Bill Amount => ");
            BillAmount = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Discount => ");
            Discount = Convert.ToDecimal(Console.ReadLine());
        }
    }

    class Visitor : BaseCustomer
    {
        public string Reason { get; set; }
        public override void LogInfo()
        {
            Console.Write("Enter Id = > ");
            Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Name => ");
            Name = Console.ReadLine();

            Console.Write("Enter Email Id => ");
            EmailId = Console.ReadLine();

            Console.Write("Enter Mobile => ");
            Mobile = Console.ReadLine();
            Console.Write("Enter Reason => ");
            Reason = Console.ReadLine();
        }
    }
}
