using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentAll.Web.DTOs
{
    public class CreateLeaseDto
    {
       
        public string LeaseNumber { get; set; }
        public int TenantId { get; set; }

        //public ICollection<UnitDto> UnitDtos { get; set; } = new List<UnitDto>();

        public int UserId { get; set; }
        
        public DateTime SigningDate { get; set; }
        public DateTime StartDate { get; set; }
        public int TermInMonths { get; set; }

        public DateTime EndDate { get; set; }

        public int CenterId { get; set; }
        

        public bool Valid { get; set; }
        public int ActivityId { get; set; }
       
    }
}
