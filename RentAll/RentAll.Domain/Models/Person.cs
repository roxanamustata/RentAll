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
        public Company Company { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Email> Emails { get; set; }
        public List<Phone> Phones { get; set; }

        #endregion

    }
}