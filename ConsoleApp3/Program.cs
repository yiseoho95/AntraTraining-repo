using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            //FullTimeEmployee fte = new FullTimeEmployee();
            //fte.AddEmployee();//AddFullTimeEmployee();
            //fte.Print();//PrintFullTimeEmployee();


            //upcasting 위와 다르게 emp 는 employee 즉 base class의 variable이다 그래서 불러오는 데이터는 baseclass 의 데이터만 불러온다.
            //Employee emp = new FullTimeEmployee(); // example of upcasting
            //emp.AddEmployee();
            //emp.Print();

            // because I added the override and virtual keywords in the parent class and the 
            // branch class now the upcasting fails to function.

            Employee emp2 = new PartTimeEmployee();
            emp2.AddEmployee();
            emp2.Print();
        }
    }
}
