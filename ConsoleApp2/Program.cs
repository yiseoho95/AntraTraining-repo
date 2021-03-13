using System;
using ConsoleApp2.Entities; // to use departments I need to notify it.
using ConsoleApp2.Repository;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            DepartmentUI departmentUI = new DepartmentUI();
            departmentUI.Demo();


            EmployeeUI employeeUI = new EmployeeUI();
            employeeUI.Run();
            //ArrayExample arrayExample = new ArrayExample();
            //arrayExample.Demo();
        }
    }
}
