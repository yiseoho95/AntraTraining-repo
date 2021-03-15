using System;
using System.Collections.Generic;

namespace ConsoleApp6
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //EqualityChecker<string> equalityChecker = new EqualityChecker<string>();
            //Console.WriteLine(equalityChecker.CheckEquality("one","one"));

            //List<string> lst = new List<string>();

            //Student st = new Student();
            //st.AddStudent();
            //st.Print();
            //st.Remove("Adicus");
            //Console.WriteLine("--------------");
            //st.Print();

            ManageEmployee emp = new ManageEmployee();
            emp.AddEmployees();
            emp.Print();


        }
    }
}
