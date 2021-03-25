using System;
using System.Collections.Generic;
using System.Text;
using Company.Data.Models;
using Company.Data.Services;
using System.Threading.Tasks;
using MovieShop.Menu;
using MovieShop.Menu.MenuOption;

namespace MovieShop.UI
{
    class ManageGenre
    {
        private readonly GenreService genreService;

        public ManageGenre()
        {
            genreService = new GenreService();
        }

        #region sync
        void DeleteGenre()
        {
            Console.Write("Enter Id = ");
            int id = Convert.ToInt32(Console.ReadLine());
            Genre g = genreService.GetById(id);

            if (genreService.DeleteGenre(g.Id) > 0)
                Console.WriteLine($"Genre {g.Name} deleted successfully");
            else
                Console.WriteLine("Some error has occurred");
        }

        void PrintAll()
        {
            IEnumerable<Genre> genreCollection = genreService.GetAll();
            foreach (var item in genreCollection)
            {
                Console.WriteLine(item.Id + " \t " + item.Name);
            }
        }

        void PrintById()
        {
            Console.Write("Enter Genre Id = ");
            int id = Convert.ToInt32(Console.ReadLine());
            Genre g = genreService.GetById(id);

            if (g != null)
            {
                Console.WriteLine(g.Id + " \t " + g.Name);
            }
            else
            {
                Console.WriteLine("Cannot find selected Genre");
            }
        }

        void AddGenre()
        {
            Genre g = new Genre();
            Console.Write(" Enter Genre Name = ");
            g.Name = Console.ReadLine();

            if (genreService.AddGenre(g) > 0)
                Console.WriteLine("Genre added successfully");
            else
                Console.WriteLine("Some error has occurred");
        }

        void UpdateGenre()
        {
            Genre g = new Genre();
            Console.Write("Enter Id = ");
            g.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Genre Name = ");
            g.Name = Console.ReadLine();

            if (genreService.UpdateGenre(g) > 0)
                Console.WriteLine("Genre Updated successfully");
            else
                Console.WriteLine("Some error has occurred");
        }

        #endregion

        #region async

        async Task DeleteGenreAsync()
        {
            Console.Write("Enter Id = ");
            int id = Convert.ToInt32(Console.ReadLine());
            Genre g = genreService.GetById(id);

            int res = await genreService.DeleteGenreAsync(g.Id);

            if (res > 0)
                Console.WriteLine($"Genre {g.Name} deleted successfully");
            else
                Console.WriteLine("Some error has occurred");
        }

        async Task PrintAllAsync()
        {
            IEnumerable<Genre> genreCollection = await genreService.GetAllGenreAsync();
            foreach (var item in genreCollection)
            {
                Console.WriteLine(item.Id + " \t " + item.Name);
            }
        }

        async Task PrintGenreByIdAsync()
        {
            Console.Write("Enter Genre Id = ");
            int id = Convert.ToInt32(Console.ReadLine());
            Genre g = await genreService.GetGenreByIdAsync(id);

            if (g != null)
            {
                Console.WriteLine(g.Id + " \t " + g.Name);
            }
            else
            {
                Console.WriteLine("Cannot find selected Genre");
            }
        }

        async Task AddGenreAsync()
        {
            Genre g = new Genre();
            Console.Write(" Enter Genre Name = ");
            g.Name = Console.ReadLine();
            int res = await genreService.AddGenreAsync(g);

            if (res > 0)
                Console.WriteLine("Genre added successfully");
            else
                Console.WriteLine("Some error has occurred");
        }

        async Task UpdateGenreAsync()
        {
            Genre g = new Genre();
            Console.Write("Enter Id = ");
            g.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Genre Name = ");
            g.Name = Console.ReadLine();

            int res = await genreService.UpdateGenreAsync(g);

            if (res > 0)
                Console.WriteLine("Genre Updated successfully");
            else
                Console.WriteLine("Some error has occurred");
        }


        #endregion
        public void Run()
        {
            int choice = 0;

            do
            {
                IMenu genreMenu = new GenreMenu();
                choice = genreMenu.PrintMenu();
                switch (choice)
                {
                    case (int)GenreMenuOption.Insert:
                        AddGenreAsync().Wait();
                        break;
                    case (int)GenreMenuOption.Delete:
                        DeleteGenreAsync().Wait();
                        break;
                    case (int)GenreMenuOption.Print:
                        PrintAllAsync().Wait();
                        break;
                    case (int)GenreMenuOption.Update:
                        UpdateGenreAsync().Wait();
                        break;
                    case (int)GenreMenuOption.GetGenreById:
                        PrintGenreByIdAsync().Wait();
                        break;
                    case (int)GenreMenuOption.Exit:
                        Console.WriteLine("Thanks for your visit. Please visit the Genre Menu again !!!!");
                        break;

                    default:
                        Console.WriteLine("Invalid Option");
                        break;

                }

                if (choice != (int)GenreMenuOption.Exit)
                {
                    //Console.WriteLine("genre " + choice);
                    Console.WriteLine("Press Enter to continue.......");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (choice != (int)GenreMenuOption.Exit);

        }
    }
}
