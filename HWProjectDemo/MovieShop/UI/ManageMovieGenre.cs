using System;
using System.Collections.Generic;
using System.Text;
using Company.Data.Models;
using Company.Data.Services;

namespace MovieShop.UI
{
    class ManageMovieGenre
    {
        private readonly MovieGenreService movieGenreService;
        public ManageMovieGenre()
        {
            movieGenreService = new MovieGenreService();
        }

        void DeleteMovieGenre()
        {
            Console.Write("Enter Movie Id = ");
            int id = Convert.ToInt32(Console.ReadLine());
            MovieGenre mg = movieGenreService.GetById(id);

            if (movieGenreService.DeleteMovieGenre(mg.MovieId) > 0)
                Console.WriteLine($"MovieGenre {mg.MovieId} deleted successfully");
            else
                Console.WriteLine("Some error has occurred");
        }

        void PrintAll()
        {
            IEnumerable<MovieGenre> movieGenreCollection = movieGenreService.GetAll();
            foreach (var item in movieGenreCollection)
            {
                Console.WriteLine(item.MovieId + " \t " + item.GenreId );
            }
        }

        void PrintById()
        {
            Console.Write("Enter Movie Id = ");
            int id = Convert.ToInt32(Console.ReadLine());
            MovieGenre mg = movieGenreService.GetById(id);

            if (mg != null)
            {
                Console.WriteLine(mg.MovieId + " \t " + mg.GenreId);
            }
            else
            {
                Console.WriteLine("Cannot find selected MovieCast");
            }
        }

        void AddMovieGenre()
        {
            MovieGenre mg = new MovieGenre();
            Console.Write(" Enter Movie ID = ");
            mg.MovieId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Genre ID = ");
            mg.GenreId = Convert.ToInt32(Console.ReadLine());


            if (movieGenreService.AddMovieGenre(mg) > 0)
                Console.WriteLine("MovieGenre added successfully");
            else
                Console.WriteLine("Some error has occurred");
        }

        void UpdateMovieCast()
        {
            MovieGenre mg = new MovieGenre();
            Console.Write("Enter Movie Id = ");
            mg.MovieId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Genre Id = ");
            mg.GenreId = Convert.ToInt32(Console.ReadLine());

            if (movieGenreService.UpdateMovieGenre(mg) > 0)
                Console.WriteLine("MovieGenre Updated successfully");
            else
                Console.WriteLine("Some error has occurred");
        }

        public void Run()
        {
            //AddMovieCast();
            //UpdateMovieCast();
            //DeleteMovieCast();
            PrintAll();
        }
    }
}
