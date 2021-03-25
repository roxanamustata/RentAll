
using System.Collections.Generic;


namespace RentAll.Domain
{
    public class Unit
    {
        public int Id { get; }
        public string Code { get; set; }
        public double Area { get; set; }
        public UnitType Type { get; set; }
        public Center Center { get; set; }
        public Floor Floor { get; set; }
        public List<Lease> Leases { get; set; }
    }
}
