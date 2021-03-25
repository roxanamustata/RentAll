using System.Collections.Generic;

namespace RentAll.Domain
{
    public class Company
    {
        public int Id { get; }
        public string Name { get; set; }
        public int FiscalCode { get; set; }
        public string FiscalAttribute { get; set; }
        public string RecomNo { get; set; }
        public Address Address { get; set; }
        public List<Person> ContactPersons { get; set; }

    }
}