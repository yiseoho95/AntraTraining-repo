using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        //Sync
        int Insert(T item);
        int Update(T item);
        int Delete(int id);
        IEnumerable<T> GetAll();
        T GetById(int id);

        //Async
        Task<int> InsertAsync(T item);
        Task<int> UpdateAsync(T item);
        Task<int> DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
