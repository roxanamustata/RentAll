using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAll.Domain.Models
{
 public abstract class AbstractUnit
    {
        public int Id { get; set; }
        public string UnitCode { get; set; }
        public double Area { get; set; }

        public double MonthlyRentSqm { get; set; }

    }
}
