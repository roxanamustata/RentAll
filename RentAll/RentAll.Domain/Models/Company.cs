using System.Collections.Generic;
using System.Text;

namespace RentAll.Domain
{
    public class Company
    {
        public Company()
        {
            ContactPersons = new List<Person>();
            Leases = new List<Lease>();


        }
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


        public string GetContactPersons()
        {
            var sb = new StringBuilder();


            foreach (var person in ContactPersons)
            {
                sb.Append($"{person.FirstName} {person.LastName}, {person.Title}");
                sb.Append("\n");

            }

            return sb.ToString();
        }


    }
}