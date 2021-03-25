using System;
using System.Collections.Generic;
using System.Text;
using Company.Data.Models;
using Company.Data.Repository;

namespace Company.Data.Services
{
    public class MovieGenreService
    {
        IRepository<MovieGenre> movieGenreRepository;
        public MovieGenreService()
        {
            movieGenreRepository = new MovieGenreRepository();
        }

        public int AddMovieGenre(MovieGenre item)
        {
            return movieGenreRepository.Insert(item);
        }

        public int UpdateMovieGenre(MovieGenre item)
        {
            return movieGenreRepository.Update(item);
        }

        public int DeleteMovieGenre(int id)
        {
            return movieGenreRepository.Delete(id);
        }

        public IEnumerable<MovieGenre> GetAll()
        {
            return movieGenreRepository.GetAll();
        }

        public MovieGenre GetById(int id)
        {
            return movieGenreRepository.GetById(id);
        }
        
    }
}
