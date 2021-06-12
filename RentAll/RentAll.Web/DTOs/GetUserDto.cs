using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentAll.Web.DTOs
{
    public class GetUserDto
    {
        public int Id { get; private set; }
        public string Username { get; set; }
    }
}
