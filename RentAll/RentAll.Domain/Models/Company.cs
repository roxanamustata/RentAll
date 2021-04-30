using System.Collections.Generic;

namespace RentAll.Domain
{
    public class Company
    {
        #region properties

        public int Id { get; private set; }
        public string CompanyName { get; set; }
        public int FiscalCode { get; set; }
        public string FiscalAttribute { get; set; }
        public string RecomNumber { get; set; }
        public Address Address { get; set; }
        public ICollection<Person> ContactPersons { get; set; }
        public ICollection<Lease> Leases { get; set; }

        #endregion
    }
}