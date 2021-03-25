namespace RentAll.Domain
{
    public class Address
    {

        public int Id { get; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string StreetName { get; set; }
        public string StreetNo { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string Apartment { get; set; }

    }
}