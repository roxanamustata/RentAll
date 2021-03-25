using System.Collections.Generic;

namespace RentAll.Domain
{
    public class Company
    {
        #region properties

        public int Id { get; private set; }
        public string Name { get; set; }
        public int FiscalCode { get; set; }
        public string FiscalAttribute { get; set; }
        public string RecomNumber { get; set; }
        public Address Address { get; set; }
        public List<Person> ContactPersons { get; set; }

        #endregion
    }
}