using System;
using System.Collections.Generic;
using System.Text;
using Company.Data.Models;
using Company.Data.Repository;
using System.Threading.Tasks;

namespace Company.Data.Services
{
    public class MovieService
    {
        IRepository<Movie> movieRepository;
        public MovieService()
        {
            movieRepository = new MovieRepository();
        }

        public int AddMovie(Movie item)
        {
            return movieRepository.Insert(item);
        }

        public int UpdateMovie(Movie item)
        {
            return movieRepository.Update(item);
        }

        public int DeleteMovie(int id)
        {
            return movieRepository.Delete(id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return movieRepository.GetAll();
        }

        public Movie GetById(int id)
        {
            return movieRepository.GetById(id);
        }

        #region async

        public async Task<int> AddMovieAsync(Movie item)
        {
            return await movieRepository.InsertAsync(item);
        }

        public async Task<int> UpdateMovieAsync(Movie item)
        {
            return await movieRepository.UpdateAsync(item);
        }

        public async Task<int> DeleteMovieAsync(int id)
        {
            return await movieRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Movie>> GetAllMovieAsync()
        {
            return await movieRepository.GetAllAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await movieRepository.GetByIdAsync(id);
        }

        #endregion
    }
}
