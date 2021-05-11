using System;
using System.Collections.Generic;
using System.Text;

namespace RentAll.Domain.Models
{
    public class Activity
    {
        #region properties

        public int Id { get; set; }
        public string ActivityName { get; set; }
       
        public Category Category { get; set; }

        #endregion
    }
}
