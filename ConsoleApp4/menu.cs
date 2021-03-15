using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    class Menu
    {
        public int Print()
        {
            //Console.WriteLine("Press 1 for customer");
            //Console.WriteLine("Press 2 for visitor");
            string[] names = Enum.GetNames(typeof(CustomerOption));
            int length = names.Length;
            int[] values = (int[])Enum.GetValues(typeof(CustomerOption));
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine("Press "+values[i]+ " for " + names[i]);
            }
         
            Console.Write("Enter your choice = ");
            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;

        }
    }
}
