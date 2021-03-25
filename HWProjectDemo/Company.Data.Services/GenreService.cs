using System;
using System.Collections.Generic;
using System.Text;
using Company.Data.Models;
using Company.Data.Repository;
using System.Threading.Tasks;

namespace Company.Data.Services
{
    public class GenreService
    {
        IRepository<Genre> genreRepository;
        public GenreService()
        {
            genreRepository = new GenreRepository();
        }
        #region sync
        public int AddGenre(Genre item)
        {
            return genreRepository.Insert(item);
        }

        public int UpdateGenre(Genre item)
        {
            return genreRepository.Update(item);
        }

        public int DeleteGenre(int id)
        {
            return genreRepository.Delete(id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return genreRepository.GetAll();
        }

        public Genre GetById(int id)
        {
            return genreRepository.GetById(id);
        }
        #endregion

        #region async
        public async Task<int> AddGenreAsync(Genre item)
        {
            return await genreRepository.InsertAsync(item);
        }

        public async Task<int> UpdateGenreAsync(Genre item)
        {
            return await genreRepository.UpdateAsync(item);
        }

        public async Task<int> DeleteGenreAsync(int id)
        {
            return await genreRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Genre>> GetAllGenreAsync()
        {
            return await genreRepository.GetAllAsync();
        }

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
            return await genreRepository.GetByIdAsync(id);
        }
        #endregion
    }
}
