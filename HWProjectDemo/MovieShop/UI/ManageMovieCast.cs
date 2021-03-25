using System;
using System.Collections.Generic;
using System.Text;
using Company.Data.Models;
using Company.Data.Services;

namespace MovieShop.UI
{
    class ManageMovieCast
    {
        private readonly MovieCastService movieCastService;
        public ManageMovieCast()
        {
            movieCastService = new MovieCastService();
        }

        void DeleteMovieCast()
        {
            Console.Write("Enter Movie Id = ");
            int id = Convert.ToInt32(Console.ReadLine());
            MovieCast mc = movieCastService.GetById(id);

            if (movieCastService.DeleteMovieCast(mc.MovieId) > 0)
                Console.WriteLine($"MovieCast {mc.Character} deleted successfully");
            else
                Console.WriteLine("Some error has occurred");
        }

        void PrintAll()
        {
            IEnumerable<MovieCast> movieCastCollection = movieCastService.GetAll();
            foreach (var item in movieCastCollection)
            {
                Console.WriteLine(item.MovieId + " \t " + item.CastId + " \t " + item.Character);
            }
        }

    void PrintById()
        {
            Console.Write("Enter Movie Id = ");
            int id = Convert.ToInt32(Console.ReadLine());
            MovieCast mc = movieCastService.GetById(id);

            if (mc != null)
            {
                Console.WriteLine(mc.MovieId + " \t " + mc.CastId + " \t " + mc.Character);
            }
            else
            {
                Console.WriteLine("Cannot find selected MovieCast");
            }
        }

        void AddMovieCast()
        {
            MovieCast mc = new MovieCast();
            Console.Write(" Enter Cast Name = ");
            mc.MovieId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter CastId = ");
            mc.CastId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Character Name = ");
            mc.Character = Console.ReadLine();

            if (movieCastService.AddMovieCast(mc) > 0)
                Console.WriteLine("MovieCast added successfully");
            else
                Console.WriteLine("Some error has occurred");
        }

        void UpdateMovieCast()
        {
            MovieCast mc = new MovieCast();
            Console.Write("Enter Movie Id = ");
            mc.MovieId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Cast Id = ");
            mc.CastId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Character Name = ");
            mc.Character = Console.ReadLine();

            if (movieCastService.UpdateMovieCast(mc) > 0)
                Console.WriteLine("MovieCast Updated successfully");
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
