using System;
using System.Collections.Generic;
using System.Text;

namespace RentAll.Domain.Models
{
    public class Activity
    {
        #region properties

        public int Id { get; private set; }
        public string Name { get; set; }
        public ActivityCategory ActivityCategory { get; set; }

        #endregion
    }
}
