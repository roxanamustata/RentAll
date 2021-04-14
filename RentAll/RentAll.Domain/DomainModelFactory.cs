using System;
using System.Collections.Generic;
using System.Text;

namespace RentAll.Domain
{
    public static class DomainModelFactory
    {

        public static Center GetShoppingCenter(int[] areas)
        {

            var shoppingCenter = new Center();

            shoppingCenter.Premises = GetUnits(areas);

            return shoppingCenter;

        }



        public static Unit GetUnit(int area)
        {
            var unit = new Unit
            {
                Area = area,
                Leases = new List<Lease>()
            };
            return unit;
        }

        public static List<Unit> GetUnits(int[] areas)
        {
            var listOfUnits = new List<Unit>();
            foreach (int area in areas)
            {
                listOfUnits.Add(GetUnit(area));
            }

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
                StartDate = DateTime.Now
            };

            lease.Premises = GetUnits(areas);

            return lease;
        }

    }
}
