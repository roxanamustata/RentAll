using RentAll.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentAll.Domain
{
    public class DomainModelFactory
    {

        public static Center GetShoppingCenter(int id, string name)
        {

            var shoppingCenter = new Center
            {
                Id = id,
                CenterName = name,
                Floors = new List<Floor>() { new Floor { FloorName = "Ground Floor" }, new Floor { FloorName = "First Floor" } },
                Premises = new List<Unit>()

            };

            return shoppingCenter;

        }

        public static Unit GetUnitOnGroundfloor(int unitId, double area)
        {
            var unit = new Unit
            {
                Id = unitId,
                Area = area,
                MonthlyRentSqm = 10,
                MonthlyMaintenanceCostSqm = 5,
                MonthlyMarketingFeeSqm = 2,
                Leases = new List<Lease>(),
                Floor = new Floor { FloorName = "Ground Floor" },
                UnitCode = "G" + area,
                Type = UnitType.Retail,

            };
            return unit;
        }

        public static Unit GetUnitOnFirstfloor(int unitId, double area)
        {
            var unit = new Unit
            {
                Id = unitId,
                Area = area,
                MonthlyRentSqm = 10,
                MonthlyMaintenanceCostSqm = 5,
                MonthlyMarketingFeeSqm = 2,
                Leases = new List<Lease>(),
                Floor = new Floor { FloorName = "First Floor" },
                UnitCode = "F" + area,
                Type = UnitType.Retail,

            };
            return unit;
        }


        public static Lease GetLease(int leaseId)
        {

            var lease = new Lease
            {
                Id = leaseId,
                Valid = true,
                TermInMonths = 60,
                StartDate = DateTime.Now,
                Activity = new Activity
                {
                    ActivityName = "Apparel",
                    Category = new Category { CategoryName = "Non-Food" },
                },
                Premises = new List<Unit>()
            };


            return lease;
        }

    }
}
