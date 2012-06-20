using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Models.Authentication
{
    public class Role
    {
        public int Id { get; protected set; }
        public string Name { get; set; }

        public IList<User> Users { get; protected set; }
    }
}
