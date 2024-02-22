using System;
using System.Collections.Generic;
using System.Linq;
using WebApiCardStatus.Data;
using WebApiCardStatus.Interfaces;
using WebApiCardStatus.Models;

namespace WebApiCardStatus.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private DataContext _context;

        public UsersRepository(DataContext context)
        {
            _context = context;
        }


        public Users GetUser(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public Users GetUser(string name)
        {
            return _context.Users.FirstOrDefault(u => u.Name == name);
        }

        public ICollection<Users> GetUsers()
        {
            return _context.Users.OrderBy(u => u.Id).ToList();
        }

        public bool UserExist(int id)
        {
            return _context.Users.Any(u => u.Id == id);
        }
    }
}
