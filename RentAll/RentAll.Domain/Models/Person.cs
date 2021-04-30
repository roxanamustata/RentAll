using System.Collections.Generic;

namespace RentAll.Domain
{
    public class Person
    {

        #region properties

        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        //public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Email> Emails { get; set; }
        public ICollection<Phone> Phones { get; set; }

        #endregion

    }
}