using RentAll.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentAll.Domain
{
    public class DomainModelFactory
    {

        public static Center GetShoppingCenter(int id, int[] areas)
        {

            var shoppingCenter = new Center
            {
                Id = id,
                Floors = new List<Floor>(),
                Premises = new List<Unit>()
            };

            for (int i = 0; i < areas.Length / 2; i++)
            {
                shoppingCenter.Premises.Add(GetUnitOnGroundfloor(areas[i]));
            }
            for (int i = areas.Length / 2; i < areas.Length; i++)
            {
                shoppingCenter.Premises.Add(GetUnitOnFirstfloor(areas[i]));
            }

            var groundFloor = new Floor { Name = "Ground Floor" };
            var firstFloor = new Floor { Name = "First Floor" };
            shoppingCenter.Floors.Add(groundFloor);
            shoppingCenter.Floors.Add(firstFloor);


            return shoppingCenter;

        }



        public static Unit GetUnitOnGroundfloor(int area)
        {
            var unit = new Unit
            {
                Area = area,
                Leases = new List<Lease>(),
                Floor = new Floor { Name = "Ground Floor" },
                Code = "G" + area,
                Type = UnitType.Retail
            };
            return unit;
        }

        public static Unit GetUnitOnFirstfloor(int area)
        {
            var unit = new Unit
            {
                Area = area,
                Leases = new List<Lease>(),
                Floor = new Floor { Name = "First Floor" },
                Code = "F" + area,
                Type = UnitType.Retail

            };
            return unit;
        }



        public static List<Unit> GetUnits(int[] areas)
        {
            var listOfUnits = new List<Unit>();
            for (int i = 0; i < areas.Length - 2; i++)
            {
                listOfUnits.Add(GetUnitOnGroundfloor(areas[i]));
            }
            listOfUnits.Add(GetUnitOnFirstfloor(areas[^1]));
            return listOfUnits;
        }


        public static Lease GetLease(int[] areas)
        {
            var lease = new Lease
            {
                RentSqm = 10,
                MaintenanceCostSqm = 5,
                MarketingFeeSqm = 2,
                Valid = true,
                TermInMonths = 60,
                StartDate = DateTime.Now,
                Activity = new Activity
                {
                    Name = "Apparel",
                    ActivityRange = new ActivityRange { Name = "Non-Food" }
                }
            };
            lease.Premises = GetUnits(areas);

            return lease;
        }

    }
}
