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
    class ManageCast
    {
        private readonly CastService castService;
        public ManageCast()
        {
            castService = new CastService();
        }
        #region sync
        void DeleteCast()
        {
            Console.Write("Enter Id = ");
            int id = Convert.ToInt32(Console.ReadLine());
            Cast c = castService.GetById(id);

            if (castService.DeleteCast(c.Id) > 0)
                Console.WriteLine($"Cast {c.Name} deleted successfully");
            else
                Console.WriteLine("Some error has occurred");
        }

        void PrintAll()
        {
            IEnumerable<Cast> castCollection = castService.GetAll();
            foreach (var item in castCollection)
            {
                Console.WriteLine(item.Id + " \t " + item.Name + " \t " + item.Gender + " \t " + item.TmdbUrl + " \t " + item.ProfilePath);
            }
        }

        void PrintById()
        {
            Console.Write("Enter Cast Id = ");
            int id = Convert.ToInt32(Console.ReadLine());
            Cast c = castService.GetById(id);

            if (c != null)
            {
                Console.WriteLine(c.Id + " \t " + c.Name + " \t " + c.Gender + " \t " + c.TmdbUrl + " \t " + c.ProfilePath);
            }
            else
            {
                Console.WriteLine("Cannot find selected Cast");
            }
        }

        void AddCast()
        {
            Cast c = new Cast();
            Console.Write(" Enter Cast Name = ");
            c.Name = Console.ReadLine();

            Console.Write("Enter Gender = ");
            c.Gender = Console.ReadLine();

            Console.Write("Enter TmbdUrl = ");
            c.TmdbUrl = Console.ReadLine();

            Console.Write("Enter ProfilePath = ");
            c.ProfilePath = Console.ReadLine();

            if (castService.AddCast(c) > 0)
                Console.WriteLine("Cast added successfully");
            else
                Console.WriteLine("Some error has occurred");
        }

        void UpdateCast()
        {
            Cast c = new Cast();
            Console.Write("Enter Id = ");
            c.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Cast Name = ");
            c.Name = Console.ReadLine();

            Console.Write("Enter Gender = ");
            c.Gender = Console.ReadLine();

            Console.Write("Enter TmbdUrl = ");
            c.TmdbUrl = Console.ReadLine();

            Console.Write("Enter ProfilePath = ");
            c.ProfilePath = Console.ReadLine();

            if (castService.UpdateCast(c) > 0)
                Console.WriteLine("Cast Updated successfully");
            else
                Console.WriteLine("Some error has occurred");
        }
        #endregion

        #region async

        async Task DeleteCastAsync()
        {
            Console.Write("Enter Id = ");
            int id = Convert.ToInt32(Console.ReadLine());
            Cast c = castService.GetById(id);

            int res = await castService.DeleteCastAsync(c.Id);

            if (res > 0)
                Console.WriteLine($"Genre {c.Name} deleted successfully");
            else
                Console.WriteLine("Some error has occurred");
        }

        async Task PrintAllAsync()
        {
            IEnumerable<Cast> castCollection = await castService.GetAllCastAsync();
            foreach (var item in castCollection)
            {
                Console.WriteLine(item.Id + " \t " + item.Name + " \t " + item.Gender + " \t " + item.TmdbUrl + " \t " + item.ProfilePath);
            }
        }

        async Task PrintCastByIdAsync()
        {
            Console.Write("Enter Cast Id = ");
            int id = Convert.ToInt32(Console.ReadLine());
            Cast c = await castService.GetGenreByIdAsync(id);

            if (c != null)
            {
                Console.WriteLine(c.Id + " \t " + c.Name + " \t " + c.Gender + " \t " + c.TmdbUrl + " \t " + c.ProfilePath);
            }
            else
            {
                Console.WriteLine("Cannot find selected Cast Member");
            }
        }

        async Task AddCastAsync()
        {
            Cast c = new Cast();
            Console.Write(" Enter Cast Name = ");
            c.Name = Console.ReadLine();

            Console.Write("Enter Gender = ");
            c.Gender = Console.ReadLine();

            Console.Write("Enter TmbdUrl = ");
            c.TmdbUrl = Console.ReadLine();

            Console.Write("Enter ProfilePath = ");
            c.ProfilePath = Console.ReadLine();
            int res = await castService.AddCastAsync(c);

            if (res > 0)
                Console.WriteLine("Cast added successfully");
            else
                Console.WriteLine("Some error has occurred");
        }

        async Task UpdateCastAsync()
        {
            Cast c = new Cast();
            Console.Write("Enter Id = ");
            c.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Cast Name = ");
            c.Name = Console.ReadLine();

            Console.Write("Enter Gender = ");
            c.Gender = Console.ReadLine();

            Console.Write("Enter TmbdUrl = ");
            c.TmdbUrl = Console.ReadLine();

            Console.Write("Enter ProfilePath = ");
            c.ProfilePath = Console.ReadLine();
            int res = await castService.UpdateCastAsync(c);

            if (res > 0)
                Console.WriteLine("Cast Updated successfully");
            else
                Console.WriteLine("Some error has occurred");
        }

        #endregion
        public void Run()
        {
            int choice = 0;

            do
            {
                IMenu castMenu = new CastMenu();
                choice = castMenu.PrintMenu();
                switch (choice)
                {
                    case (int)CastMenuOption.Insert:
                        AddCastAsync().Wait();
                        break;
                    case (int)CastMenuOption.Delete:
                        DeleteCastAsync().Wait();
                        break;
                    case (int)CastMenuOption.Print:
                        PrintAllAsync().Wait();
                        break;
                    case (int)CastMenuOption.Update:
                        UpdateCastAsync().Wait();
                        break;
                    case (int)CastMenuOption.GetCastById:
                        PrintCastByIdAsync().Wait();
                        break;
                    case (int)CastMenuOption.Exit:
                        Console.WriteLine("Thanks for your visit. Please visit the Cast Menu again !!!!");
                        break;

                    default:
                        Console.WriteLine("Invalid Option");
                        break;

                }

                if (choice != (int)CastMenuOption.Exit)
                {
                    //Console.WriteLine("genre " + choice);
                    Console.WriteLine("Press Enter to continue.......");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (choice != (int)CastMenuOption.Exit);

        }
    }
}
