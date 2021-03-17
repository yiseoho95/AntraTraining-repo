using System;
using System.Collections.Generic;
using System.Text;
using ClassReview031621.Data.Models;

namespace ClassReview031621.Data.Repositories
{
    class EmployeeRepository : IRepository<Employee>
    {
        List<Employee> lstEmployeeCollection = new List<Employee>();
        public void Delete(int id)
        {
            Employee e = GetById(id);
            if (e != null)
            {
                lstEmployeeCollection.Remove(e);
            }
        }

        public List<Employee> GetAll()
        {
            return lstEmployeeCollection;
        }

        public Employee GetById(int id)
        {
            int length = lstEmployeeCollection.Count;
            for (int i = 0; i < length; i++)
            {
                if (lstEmployeeCollection[i].Id == id)
                    return lstEmployeeCollection[i];
            }

            return null;
        }

        public void Insert(Employee item)
        {
            lstEmployeeCollection.Add(item);
        }

        public void Update(Employee item)
        {
            Employee e = GetById(item.Id);
            if(e!=null)
            {
                e.FirstName = item.FirstName;
                e.LastName = item.LastName;
                e.EmailId = item.EmailId;
                e.Age = item.Age;
            }
        }
    }
}
