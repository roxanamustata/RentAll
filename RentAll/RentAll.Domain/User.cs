using System;
using System.Collections.Generic;
using System.Text;

namespace RentAll.Domain
{
    public class User
    {

        public int Id { get; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Role> Roles;
    }
}
