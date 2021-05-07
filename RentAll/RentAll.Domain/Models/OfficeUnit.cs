using RentAll.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentAll.Domain.Models
{
   public class OfficeUnit:IUnit
    {
              
        public string GetUnitType()
        {
            return UnitType.Office.ToString();
        }
    }
}
