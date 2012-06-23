using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Models;
using Domain.Repositories.Authentication;

namespace Domain.Services.Authentication
{
    public class RoleService
    {
        private readonly IRoleRepository repository;

        public RoleService(IRoleRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get role by role name
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public Role GetRole(string roleName)
        {
            return repository.GetAll().SingleOrDefault(r => r.Name == roleName);
        }

        public IQueryable<Role> Roles
        {
            get { return repository.GetAll(); }
        }

    }
}
