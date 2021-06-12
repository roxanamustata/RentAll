using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentAll.Web.DTOs
{
    public class GetCompanyDto
    {
        public int Id { get; private set; }
        public string CompanyName { get; set; }
    }
}
