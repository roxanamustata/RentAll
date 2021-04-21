
using System.Collections.Generic;


namespace RentAll.Domain
{
    public class Unit
    {

        #region properties

        public int Id { get; private set; }
        public string Code { get; set; }
        public double Area { get; set; }
        public UnitType Type { get; set; }
        public Center Center { get; set; }
        public Floor Floor { get; set; }
        public List<Lease> Leases { get; set; }

        #endregion

        public bool IsLeased()
        {
            foreach(Lease Lease in Leases)
            {
                if (Lease.Valid)
                {
                    return true;
                }
            }
            return false;
        }

        public Lease GetValidLease()
        {
            return Leases.Find(l => l.Valid == true);
        }

    }
}
