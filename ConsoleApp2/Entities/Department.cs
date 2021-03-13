using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Entities
    // Namespace indicates the folder the class is nested in.
{
    class Department
    {
        // id, departmentname, location

        private int id;
        private string departmentName;
        private string location;


        public int Id
        {
            get {
                return id;
            }
            set {
                id = value;
            }
        }

        public string DepartmentName
        {
            get
            {
                return departmentName;
            }
            set
            {
                departmentName = value;
            }
        }

        public string Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        }
    }
}
