using System;
using Antra.CompanyApp.UI.ConsoleApp.UI;

namespace Antra.CompanyApp.UI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //ManageDepartment manageDepartment = new ManageDepartment();
            //manageDepartment.Run();

            ManageEmployee manageEmployee = new ManageEmployee();
            manageEmployee.Run();
        }
    }
}
