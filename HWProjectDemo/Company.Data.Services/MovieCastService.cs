using System;
using System.Collections.Generic;
using System.Text;
using Company.Data.Models;
using Company.Data.Repository;

namespace Company.Data.Services
{
    public class MovieCastService
    {
        IRepository<MovieCast> movieCastRepository;
        public MovieCastService()
        {
            movieCastRepository = new MovieCastRepository();
        }

        public int AddMovieCast(MovieCast item)
        {
            return movieCastRepository.Insert(item);
        }

        public int UpdateMovieCast(MovieCast item)
        {
            return movieCastRepository.Update(item);
        }

        public int DeleteMovieCast(int id)
        {
            return movieCastRepository.Delete(id);
        }

        public IEnumerable<MovieCast> GetAll()
        {
            return movieCastRepository.GetAll();
        }

        public MovieCast GetById(int id)
        {
            return movieCastRepository.GetById(id);
        }
        //AddGenre UpdateGenre DeleteGenre GetAll GetById
    }
}
