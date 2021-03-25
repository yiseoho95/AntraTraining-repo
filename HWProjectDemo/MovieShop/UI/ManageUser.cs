using System;
using System.Collections.Generic;
using System.Text;
using Company.Data.Models;
using Company.Data.Services;

namespace MovieShop.UI
{
    class ManageUser
    {
        private readonly UserService userService;
        public ManageUser()
        {
            userService = new UserService();
        }

        void AddUser()
        {
            User u = new User();
            Console.Write("Enter UserName = ");
            u.UserName = Console.ReadLine();

            Console.Write("Enter Normalized UserName = ");
            u.NormalizedUserName = Console.ReadLine();

            Console.Write("Enter Email = ");
            u.Email = Console.ReadLine();

            Console.Write("Enter Normalized Email");
            u.NormalizedEmail = Console.ReadLine();

            Console.Write("Enter Email Confirmed = ");
            u.EmailConfirmed = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Hashed Password = ");
            u.HashedPassword = Console.ReadLine();



        }

        void UpdateUser()
        {
            User u = new User();
        }

        void DeleteUser()
        {
            User u = new User();
        }

        void PrintAll()
        {
            User u = new User();
        }

        void PrintById()
        {
            User u = new User();
        }
        //AddUser UpdateUser DeleteUser GetAll GetById

        public void Run()
        {

        }

    }
}
