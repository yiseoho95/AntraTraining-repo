using System;
using System.Collections.Generic;
using System.Text;

namespace Antra.CompanyApp.Data.Models
{
    public class Dept
    {
        private List<Employee> _emps = new List<Employee>();
        public int Id { get; set; }
        public string DName { get; set; }
        public string Loc { get; set; }

        public List<Employee> Employees { get { return _emps; } set { _emps = value; } }
    }
}
