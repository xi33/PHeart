using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Models;
using Domain.Repositories.Authentication;

namespace EFData.Authentication
{
    public class UserRepository:Repository<User>,IUserRepository
    {
        //public UserRepository(PHeartDbContext context):base(context)
        //{
            
        //}
    }
}
