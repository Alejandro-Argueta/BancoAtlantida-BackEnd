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
        private readonly DataContext _context;

        public UsersRepository(DataContext context)
        {
            _context = context;
        }

        public void AddUser(Users user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var userToDelete = _context.Users.FirstOrDefault(u => u.Id == id);
            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                _context.SaveChanges();
            }
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

        public void UpdateUser(Users user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var existingUser = _context.Users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.LastName = user.LastName;
                _context.SaveChanges();
            }
        }

        public bool UserExist(int id)
        {
            return _context.Users.Any(u => u.Id == id);
        }
    }
}
