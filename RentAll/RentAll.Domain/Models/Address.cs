namespace RentAll.Domain
{
    public class Address
    {
        #region fields
        #endregion

        #region constants
        #endregion

        #region constructors
        #endregion

        #region properties

        public int Id { get; private set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public string Building { get; set; }
        public int Floor { get; set; }
        public int Apartment { get; set; }

        #endregion

        #region public methods
        #endregion

        #region private methods
        #endregion
    }
}