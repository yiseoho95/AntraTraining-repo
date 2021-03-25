using System;
using System.Collections.Generic;
using System.Text;
using Company.Data.Models;
using Company.Data.Repository;
using System.Threading.Tasks;

namespace Company.Data.Services
{
    public class CastService
    {
        IRepository<Cast> castRepository;
        public CastService()
        {
            castRepository = new CastRepository();
        }

        public int AddCast(Cast item)
        {
            return castRepository.Insert(item);
        }

        public int UpdateCast(Cast item)
        {
            return castRepository.Update(item);
        }

        public int DeleteCast(int id)
        {
            return castRepository.Delete(id);
        }

        public IEnumerable<Cast> GetAll()
        {
            return castRepository.GetAll();
        }

        public Cast GetById(int id)
        {
            return castRepository.GetById(id);
        }
        //AddGenre UpdateGenre DeleteGenre GetAll GetById

        #region async
        public async Task<int> AddCastAsync(Cast item)
        {
            return await castRepository.InsertAsync(item);
        }

        public async Task<int> UpdateCastAsync(Cast item)
        {
            return await castRepository.UpdateAsync(item);
        }

        public async Task<int> DeleteCastAsync(int id)
        {
            return await castRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Cast>> GetAllCastAsync()
        {
            return await castRepository.GetAllAsync();
        }

        public async Task<Cast> GetGenreByIdAsync(int id)
        {
            return await castRepository.GetByIdAsync(id);
        }

        #endregion
    }
}
