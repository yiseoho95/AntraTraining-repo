using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {// why do i use an abstract class. abstract class allows me to start the statement 


            Menu m = new Menu();
            int choice = m.Print();
            CustomerFactory customerFactory = new CustomerFactory();
            BaseCustomer baseCustomer =  customerFactory.GetObject(choice);
            baseCustomer.LogInfo();


            //BaseCustomer baseCustomer = new Visitor();
            //baseCustomer.LogInfo();
        }
    }
}
