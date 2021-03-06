using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentAll.Domain
{
    public class Center
    {

        public Center()
        {
            Units = new List<Unit>();
        }
        #region properties

        public int Id { get; set; }
        public string CenterName { get; set; }
        public int CompanyId { get; set; }
        public Company Owner { get; set; }
        public ICollection<Floor> Floors { get; set; }
        public int ParkingCapacity { get; set; }
        public ICollection<Unit> Units { get; set; }

        public string Description { get; set; }

        public string Opening { get; set; }

        #endregion


        #region public methods

        #endregion


        #region private methods

        #endregion
    }



}
