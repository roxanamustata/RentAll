using System;
using System.Collections.Generic;
using System.Text;

namespace RentAll.Domain.Models
{
    public class Activity
    {
        #region properties

        public int Id { get; private set; }
        public string ActivityName { get; set; }
        public Category Category { get; set; }
        public ICollection<Lease> Leases { get; set; }

        #endregion
    }
}
