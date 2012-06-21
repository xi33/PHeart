using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Models.Authentication;
using Domain.Repositories.Authentication;

namespace Domain.Services.Authentication
{
    public class UserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        //R
        public IQueryable<User> Users
        {
            get { return repository.GetAll(); }
        }

        // Get user by username
        public User GetUser(string name)
        {
            return repository.GetAll().SingleOrDefault(u => u.Name == name);
        }

        //C
        public void CreateNewUser(User user)
        {
            repository.Insert(user);
        }
    }
}
