﻿using WebApiCardStatus.Models;

namespace WebApiCardStatus.Interfaces
{
    public interface IUsersRepository
    {
        ICollection<Users> GetUsers();

        Users GetUser(int id);
        Users GetUser(string name);
        bool UserExist(int id);

        void AddUser(Users user);
        void UpdateUser(Users user);
        void DeleteUser(int id);
    }
}
