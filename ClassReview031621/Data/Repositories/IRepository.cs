using System;
using System.Collections.Generic;
using System.Text;

namespace ClassReview031621.Data.Repositories
{
    interface IRepository<T> where T : class
    {
        void Insert(T item);
        void Update(T item);
        T GetById(int id);
        List<T> GetAll();
        void Delete(int id);
    }
}
