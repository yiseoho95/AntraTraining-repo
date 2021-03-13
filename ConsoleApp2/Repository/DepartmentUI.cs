using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp2.Entities;

namespace ConsoleApp2.Repository
{
    class DepartmentUI
    {
        public void Demo()
        {
            Department[] departmentCollection = new Department[3];
            Department d = new Department();
            d.Id = 1;
            d.DepartmentName = "IT";
            d.Location = "Sterling";

            departmentCollection[0] = d;

            Department d2 = new Department();
            d2.Id = 2;
            d2.DepartmentName = "QA";
            d2.Location = "Leesburg";

            departmentCollection[1] = d2;

            Department d3 = new Department();
            d3.Id = 3;
            d3.DepartmentName = "HR";
            d3.Location = "Tysons";

            departmentCollection[2] = d3;

            int length = departmentCollection.Length;
            Console.WriteLine("Id\tName\tLocation");
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(departmentCollection[i].Id + "\t" + departmentCollection[i].DepartmentName + "\t" + departmentCollection[i].Location);
            }
        }
    }
}
