using RentAll.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentAll.Domain.Models
{
    public class StorageUnit:IUnit
    {
        private string _type;

        public StorageUnit(string type)
        {
            _type = type;
        }

        public string GetUnitType()
        {
            return UnitType.Storage.ToString();
        }
    }
}
