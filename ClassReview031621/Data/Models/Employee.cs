using System;
using System.Collections.Generic;
using System.Text;

namespace ClassReview031621.Data.Models
{
    class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public int Age { get; set; } // No under 18 no over 56
    }
}
