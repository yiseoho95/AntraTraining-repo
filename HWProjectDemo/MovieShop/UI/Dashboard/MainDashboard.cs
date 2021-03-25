using System;
using System.Collections.Generic;
using System.Text;
using MovieShop.Menu;
using MovieShop.Menu.MenuOption;


namespace MovieShop.UI.Dashboard
{
    class MainDashboard : IDashboard
    {
        public void ShowDashboard()
        {
            int choice = 0;
            IDashboard dashboard;
            IMenu mainMenu = new MainMenu();

            do
            {
                choice = mainMenu.PrintMenu();

                switch (choice)
                {
                    case (int)MainMenuOption.Movie:
                        Console.Clear();
                        dashboard = new MovieDashboard();
                        dashboard.ShowDashboard();
                        break;
                    case (int)MainMenuOption.User:
                        Console.Clear();
                        dashboard = new UserDashboard();
                        dashboard.ShowDashboard();
                        break;
                    case (int)MainMenuOption.Genre:
                        Console.Clear();
                        dashboard = new GenreDashboard();
                        dashboard.ShowDashboard();
                        break;
                    case (int)MainMenuOption.Cast:
                        Console.Clear();
                        dashboard = new CastDashboard();
                        dashboard.ShowDashboard();
                        break;
                    case (int)MainMenuOption.Exit:
                        Console.WriteLine("Thanks for your visit. Please visit again !!!!");
                        break;
                    default:
                        Console.WriteLine("Invalid Option.");
                        break;
                }

                if (choice != (int)MainMenuOption.Exit)
                {
                    //Console.WriteLine("main " + choice);
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                }

            } while (choice != (int)MainMenuOption.Exit);
        }
    }
}
