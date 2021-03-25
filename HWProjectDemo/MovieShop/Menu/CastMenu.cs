using System;
using System.Collections.Generic;
using System.Text;
using MovieShop.Menu.MenuOption;

namespace MovieShop.Menu
{
    class CastMenu : IMenu
    {
        public int PrintMenu()
        {
            int choice = 0;

            string[] names = Enum.GetNames(typeof(CastMenuOption));
            int[] values = (int[])Enum.GetValues(typeof(CastMenuOption));

            int length = names.Length;
            Console.WriteLine("This is the Cast Menu");
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine("Press{0} for {1}", values[i], names[i]);
            }
            Console.Write("Enter your Choice => ");

            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Only numbers are allowed");
            }
            catch (OverflowException oe)
            {
                Console.WriteLine("value must be in between 1 to " + int.MaxValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine("some unforseen error has occured. Contact the IT department");
            }

            return choice;
        }
    }
}
