using System;
using System.Collections.Generic;
using System.Text;
using Company.Data.Models;
using Company.Data.Repository;

namespace Company.Data.Services
{
    public class UserService
    {
        IRepository<User> userRepository;
        public UserService()
        {
            userRepository = new UserRepository();
        }

        public int AddUser(User item)
        {
            return userRepository.Insert(item);
        }

        public int UpdateUser(User item)
        {
            return userRepository.Update(item);
        }

        public int DeleteUser(int id)
        {
            return userRepository.Delete(id);
        }

        public IEnumerable<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return userRepository.GetById(id);
        }
    }
}
