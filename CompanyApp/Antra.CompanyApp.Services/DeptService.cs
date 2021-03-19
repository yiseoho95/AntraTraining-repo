using System;
using System.Collections.Generic;
using System.Text;
using Antra.CompanyApp.Data.Repository;
using Antra.CompanyApp.Data.Models;

namespace Antra.CompanyApp.Services
{
    public class DeptService
    {
        IRepository<Dept> deptRepository;
        public DeptService()
        {
            deptRepository = new DeptRepository();
        }

        public int AddDepartment(Dept item)
        {
            return deptRepository.Insert(item);
        }

        public int UpdateDepartment(Dept item)
        {
            return deptRepository.Update(item);
        }

        public int DeleteDepartment(int id)
        {
            return deptRepository.Delete(id);
        }

        public IEnumerable<Dept> GetAll()
        {
            return deptRepository.GetAll();
        }
    }

}
