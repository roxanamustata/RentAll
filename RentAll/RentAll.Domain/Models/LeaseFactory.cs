using RentAll.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentAll.Domain.Models
{
    public class LeaseFactory
    {
        private IUnit _unit;

        public LeaseFactory(IUnit unit)
        {
            _unit = unit;
        }

        public string CreateLease()
        {
            return $"New lease with unit of type: {_unit.GetUnitType()}";
        }

    }
}
