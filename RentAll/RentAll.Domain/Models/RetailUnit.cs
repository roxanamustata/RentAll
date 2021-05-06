using RentAll.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentAll.Domain.Models
{
   public class RetailUnit:IUnit
    {

        private string _type;

        public RetailUnit(string type)
        {
            _type = type;
        }

        public string GetUnitType()
        {
            return UnitType.Retail.ToString();
        }
    }
}
