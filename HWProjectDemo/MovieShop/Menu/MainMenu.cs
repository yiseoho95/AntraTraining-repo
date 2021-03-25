using System;
using System.Collections.Generic;
using System.Text;
using MovieShop.Menu.MenuOption;

namespace MovieShop.Menu
{
    public class MainMenu : IMenu
    {
        public int PrintMenu()
        {
            int choice = 0;

            string[] optionNames = Enum.GetNames(typeof(MainMenuOption));
            int[] optionValues = (int[])Enum.GetValues(typeof(MainMenuOption));
            int length = optionNames.Length;

            Console.WriteLine("This is the Main Menu");
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"Press {0} for {1}", optionValues[i], optionNames[i] );
            }
            Console.Write("Enter your Choice => ");

            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch(FormatException fe)
            {
                Console.WriteLine("Only Numbers Plz");
            }
            catch(OverflowException oe)
            {
                Console.WriteLine("Value must be between 1 to "+ int.MaxValue);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Some error has occured. Contact IT department");
            }

            return choice;
        }
        
    }
}
