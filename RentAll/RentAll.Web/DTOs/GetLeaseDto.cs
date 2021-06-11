using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentAll.Web.DTOs
{
    public class GetLeaseDto
    {
       public int Id { get; set; }
        public string LeaseNumber { get; set; }
        public string Tenant { get; set; }
        public ICollection<GetUnitDto> Units { get; set; }


        public DateTime SigningDate { get; set; }
        public DateTime StartDate { get; set; }
        public int TermInMonths { get; set; }

        public int CenterId { get; set; }
        public string Center { get; set; }

        public string Valid { get; set; }
        public string Activity { get; set; }

    }
}
