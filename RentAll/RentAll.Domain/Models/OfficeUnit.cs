using RentAll.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentAll.Domain.Models
{
   public class OfficeUnit:IUnit
    {
        private string _type;

        public OfficeUnit(string type)
        {
            _type = type;
        }

        public string GetUnitType()
        {
            return UnitType.Office.ToString();
        }
    }
}
