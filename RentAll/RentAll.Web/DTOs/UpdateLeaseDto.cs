using System;

namespace RentAll.Web.DTOs
{
    public class UpdateLeaseDto
    {
        public int TenantId { get; set; }
        //public ICollection<Unit> Units { get; set; }
        public DateTime StartDate { get; set; }
        public int TermInMonths { get; set; }
        public DateTime EndDate { get; set; }
        public bool Valid { get; set; }
        public int ActivityId { get; set; }

    }
}