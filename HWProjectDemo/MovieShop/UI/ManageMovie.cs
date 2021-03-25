using System;
using System.Collections.Generic;
using System.Text;
using Company.Data.Repository;
using Company.Data.Models;
using Company.Data.Services;
using System.Threading.Tasks;
using MovieShop.Menu;
using MovieShop.Menu.MenuOption;

namespace MovieShop.UI
{
    class ManageMovie
    {
        //data protection. can only change the value inside the constructor. Allows for more flexibility compared to Const 
        //private readonly MovieRepository movieRepository;
        private readonly MovieService movieService;
        public ManageMovie()
        {
            movieService = new MovieService();
            //movieRepository = new MovieRepository();
        }
        void AddMovie()
        {
            Movie m = new Movie();
            Console.Write("Enter Title = ");
            m.Title = Console.ReadLine();

            Console.Write("Enter Overview = ");
            m.Overview = Console.ReadLine();

            Console.Write("Enter Tagline = ");
            m.Tagline = Console.ReadLine();

            Console.Write("Enter Budget = ");
            m.Budget = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Revenue = ");
            m.Revenue = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter IMDBUrl = ");
            m.ImdbUrl = Console.ReadLine();

            Console.Write("Enter TMDBUrl = ");
            m.TmdbUrl = Console.ReadLine();

            Console.Write("Enter PosterUrl = ");
            m.PosterUrl = Console.ReadLine();

            Console.Write("Enter BackdropUrl = ");
            m.BackdropUrl = Console.ReadLine();

            Console.Write("Enter Original Language = ");
            m.OriginalLanguage = Console.ReadLine();

            Console.Write("Enter Release Date = ");
            m.ReleaseDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Enter RunTime = ");
            m.RunTime = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Price = ");
            m.Price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Created Date = ");
            m.CreatedDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Enter Updated Date = ");
            m.UpdatedDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Created By = ");
            m.CreatedBy = Console.ReadLine();

            Console.Write("Updated By = ");
            m.UpdatedBy = Console.ReadLine();

            if(movieService.AddMovie(m) > 0)
                Console.WriteLine( "Movie added successfully");
            else
                Console.WriteLine("Some error has occurred");
        }

        void UpdateMovie()
        {
            Movie m = new Movie();
            Console.Write("Enter Id = ");
            m.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Title = ");
            m.Title = Console.ReadLine();

            Console.Write("Enter Overview = ");
            m.Overview = Console.ReadLine();

            Console.Write("Enter Tagline = ");
            m.Tagline = Console.ReadLine();

            Console.Write("Enter Budget = ");
            m.Budget = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Revenue = ");
            m.Revenue = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter IMDBUrl = ");
            m.ImdbUrl = Console.ReadLine();

            Console.Write("Enter TMDBUrl = ");
            m.TmdbUrl = Console.ReadLine();

            Console.Write("Enter PosterUrl = ");
            m.PosterUrl = Console.ReadLine();

            Console.Write("Enter BackdropUrl = ");
            m.BackdropUrl = Console.ReadLine();

            Console.Write("Enter Original Language = ");
            m.OriginalLanguage = Console.ReadLine();

            Console.Write("Enter Release Date = ");
            m.ReleaseDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Enter RunTime = ");
            m.RunTime = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Price = ");
            m.Price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Created Date = ");
            m.CreatedDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Enter Updated Date = ");
            m.UpdatedDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Created By = ");
            m.CreatedBy = Console.ReadLine();

            Console.Write("Updated By = ");
            m.UpdatedBy = Console.ReadLine();

            if (movieService.UpdateMovie(m) > 0)
                Console.WriteLine("Movie Updated successfully");
            else
                Console.WriteLine("Some error has occurred");
        }

        void PrintAll()
        {
            IEnumerable<Movie> movieCollection = movieService.GetAll();
            foreach (var item in movieCollection)
            {
                Console.WriteLine(item.Id + " \t " + item.Title + "\t" + item.Overview + "\t" + item.Tagline + "\t" +item.Budget + "\t" + item.Revenue + "\t" + item.ImdbUrl + "\t" + item.TmdbUrl + "\t" + item.PosterUrl + "\t" + item.BackdropUrl + "\t" + item.OriginalLanguage + "\t" + item.ReleaseDate + "\t" + item.RunTime + "\t" + item.Price + "\t" + item.CreatedDate + "\t" + item.UpdatedDate + "\t" + item.CreatedBy + "\t" + item.UpdatedBy );
            }
        }

        void PrintById()
        {
            Console.Write("Enter Movie Id = ");
            int id = Convert.ToInt32(Console.ReadLine());
            Movie m = movieService.GetById(id);

            if (m != null)
            {
                Console.WriteLine(m.Id + " \t " + m.Title + "\t" + m.Overview + "\t" + m.Tagline + "\t" + m.Budget + "\t" + m.Revenue + "\t" + m.ImdbUrl + "\t" + m.TmdbUrl + "\t" + m.PosterUrl + "\t" + m.BackdropUrl + "\t" + m.OriginalLanguage + "\t" + m.ReleaseDate + "\t" + m.RunTime + "\t" + m.Price + "\t" + m.CreatedDate + "\t" + m.UpdatedDate + "\t" + m.CreatedBy + "\t" + m.UpdatedBy);
            }
            else
            {
                Console.WriteLine("Cannot find selected Movie");
            }
        }

        void DeleteMovie()
        {
            //cannot do Movie m = new Movie(); Must get the movie by correct Id and then delete only that movie
            Console.Write("Enter Id = ");
            int id = Convert.ToInt32(Console.ReadLine());
            Movie m = movieService.GetById(id);

            if (movieService.DeleteMovie(m.Id) > 0)
                Console.WriteLine($"Movie {m.Title} deleted successfully");
            else
                Console.WriteLine("Some error has occurred");
        }

        #region async

        async Task DeleteMovieAsync()
        {
            Console.Write("Enter Id = ");
            int id = Convert.ToInt32(Console.ReadLine());
            Movie m = movieService.GetById(id);

            int res = await movieService.DeleteMovieAsync(m.Id);
            
            if (res > 0)
                Console.WriteLine($"Movie {m.Title} deleted successfully");
            else
                Console.WriteLine("Some error has occurred");
        }

        async Task PrintAllAsync()
        {
            IEnumerable<Movie> movieCollection = await movieService.GetAllMovieAsync();
            foreach (var item in movieCollection)
            {
                Console.WriteLine(item.Id + " \t " + item.Title + "\t" + item.Overview + "\t" + item.Tagline + "\t" + item.Budget + "\t" + item.Revenue + "\t" + item.ImdbUrl + "\t" + item.TmdbUrl + "\t" + item.PosterUrl + "\t" + item.BackdropUrl + "\t" + item.OriginalLanguage + "\t" + item.ReleaseDate + "\t" + item.RunTime + "\t" + item.Price + "\t" + item.CreatedDate + "\t" + item.UpdatedDate + "\t" + item.CreatedBy + "\t" + item.UpdatedBy);
            }
        }

        async Task PrintMovieByIdAsync()
        {
            Console.Write("Enter Movie Id = ");
            int id = Convert.ToInt32(Console.ReadLine());
            Movie m = await movieService.GetMovieByIdAsync(id);

            if (m != null)
            {
                Console.WriteLine(m.Id + " \t " + m.Title + "\t" + m.Overview + "\t" + m.Tagline + "\t" + m.Budget + "\t" + m.Revenue + "\t" + m.ImdbUrl + "\t" + m.TmdbUrl + "\t" + m.PosterUrl + "\t" + m.BackdropUrl + "\t" + m.OriginalLanguage + "\t" + m.ReleaseDate + "\t" + m.RunTime + "\t" + m.Price + "\t" + m.CreatedDate + "\t" + m.UpdatedDate + "\t" + m.CreatedBy + "\t" + m.UpdatedBy);
            }
            else
            {
                Console.WriteLine("Cannot find selected Movie");
            }
        }

        async Task AddMovieAsync()
        {
            Movie m = new Movie();
            Console.Write("Enter Title = ");
            m.Title = Console.ReadLine();

            Console.Write("Enter Overview = ");
            m.Overview = Console.ReadLine();

            Console.Write("Enter Tagline = ");
            m.Tagline = Console.ReadLine();

            Console.Write("Enter Budget = ");
            m.Budget = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Revenue = ");
            m.Revenue = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter IMDBUrl = ");
            m.ImdbUrl = Console.ReadLine();

            Console.Write("Enter TMDBUrl = ");
            m.TmdbUrl = Console.ReadLine();

            Console.Write("Enter PosterUrl = ");
            m.PosterUrl = Console.ReadLine();

            Console.Write("Enter BackdropUrl = ");
            m.BackdropUrl = Console.ReadLine();

            Console.Write("Enter Original Language = ");
            m.OriginalLanguage = Console.ReadLine();

            Console.Write("Enter Release Date = ");
            m.ReleaseDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Enter RunTime = ");
            m.RunTime = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Price = ");
            m.Price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Created Date = ");
            m.CreatedDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Enter Updated Date = ");
            m.UpdatedDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Created By = ");
            m.CreatedBy = Console.ReadLine();

            Console.Write("Updated By = ");
            m.UpdatedBy = Console.ReadLine();

            int res = await movieService.AddMovieAsync(m);

            if (res > 0)
                Console.WriteLine("Movie added successfully");
            else
                Console.WriteLine("Some error has occurred");
        }

        async Task UpdateMovieAsync()
        {
            Movie m = new Movie();
            Console.Write("Enter Id = ");
            m.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Title = ");
            m.Title = Console.ReadLine();

            Console.Write("Enter Overview = ");
            m.Overview = Console.ReadLine();

            Console.Write("Enter Tagline = ");
            m.Tagline = Console.ReadLine();

            Console.Write("Enter Budget = ");
            m.Budget = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Revenue = ");
            m.Revenue = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter IMDBUrl = ");
            m.ImdbUrl = Console.ReadLine();

            Console.Write("Enter TMDBUrl = ");
            m.TmdbUrl = Console.ReadLine();

            Console.Write("Enter PosterUrl = ");
            m.PosterUrl = Console.ReadLine();

            Console.Write("Enter BackdropUrl = ");
            m.BackdropUrl = Console.ReadLine();

            Console.Write("Enter Original Language = ");
            m.OriginalLanguage = Console.ReadLine();

            Console.Write("Enter Release Date = ");
            m.ReleaseDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Enter RunTime = ");
            m.RunTime = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Price = ");
            m.Price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Created Date = ");
            m.CreatedDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Enter Updated Date = ");
            m.UpdatedDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Created By = ");
            m.CreatedBy = Console.ReadLine();

            Console.Write("Updated By = ");
            m.UpdatedBy = Console.ReadLine();

            int res = await movieService.UpdateMovieAsync(m);

            if (res > 0)
                Console.WriteLine("Movie has been Updated successfully");
            else
                Console.WriteLine("Some error has occurred");
        }


        #endregion

        public void Run()
        {
            int choice = 0;

            do
            {
                IMenu movieMenu = new MovieMenu();
                choice = movieMenu.PrintMenu();
                switch (choice)
                {
                    case (int)MovieMenuOption.Insert:
                        AddMovieAsync().Wait();
                        break;
                    case (int)MovieMenuOption.Delete:
                        DeleteMovieAsync().Wait();
                        break;
                    case (int)MovieMenuOption.Print:
                        PrintAllAsync().Wait();
                        break;
                    case (int)MovieMenuOption.Update:
                        UpdateMovieAsync().Wait();
                        break;
                    case (int)MovieMenuOption.GetMovieById:
                        PrintMovieByIdAsync().Wait();
                        break;
                    case (int)MovieMenuOption.Exit:
                        Console.WriteLine("Thanks for your visit. Please visit the Movie Menu again !!!!");
                        break;

                    default:
                        Console.WriteLine("Invalid Option");
                        break;

                }

                if (choice != (int)MovieMenuOption.Exit)
                {
                    //Console.WriteLine("genre " + choice);
                    Console.WriteLine("Press Enter to continue.......");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (choice != (int)MovieMenuOption.Exit);
        }
    }
}
