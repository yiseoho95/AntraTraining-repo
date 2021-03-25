using System;
using System.Collections.Generic;
using System.Text;
using Antra.CompanyApp.Data.Models;
using Antra.CompanyApp.Data.Repository;


namespace Antra.CompanyApp.Services
{

    public class EmployeeService
    {
        IRepository<Employee> empRepository;
        public EmployeeService()
        {
            empRepository = new EmpRepository();
        }

        public int AddEmployee(Employee item)
        {
            return empRepository.Insert(item);
        }

        public int DeleteEmployee(int id)
        {
            return empRepository.Delete(id);
        }

        public int UpdateEmployee(Employee item)
        {
            return empRepository.Update(item);
        }

        public IEnumerable<Employee> GetAll()
        {
            return empRepository.GetAll();
        }

        public Employee GetById(int id)
        {
            return empRepository.GetById(id);
        }
    }
}
