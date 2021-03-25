using System;
using System.Collections.Generic;
using System.Text;

namespace RentAll.Domain
{
    public class User
    {
        #region properties

        public int Id { get; private set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Role> Roles { get; set; }

        #endregion
    }
}
