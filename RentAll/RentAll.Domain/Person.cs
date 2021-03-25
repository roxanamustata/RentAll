using System.Collections.Generic;

namespace RentAll.Domain
{
    public class Person
    {
        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public Company Company { get; set; }
        public List<Address> Addresses;
        public List<Email> Emails;
        public List<Phone> Phones;

    }
}