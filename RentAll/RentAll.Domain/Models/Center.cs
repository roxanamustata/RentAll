using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentAll.Domain
{
    public class Center
    {
        #region properties

        public int Id { get; set; }
        public string Name { get; set; }
        public Company Owner { get; set; }
        public List<Floor> Floors { get; set; }
        public int ParkingCapacity { get; set; }
        public List<Unit> Premises { get; set; }

        #endregion


        #region public methods

        //public double CalculateOcupancyDegreePerCenter()
        //{
        //    double grossLeasableArea = CalculateGrossLeasableAreaPerCenter();
        //    double leasedArea = 0;
        //    foreach (var unit in Premises)
        //    {
        //        if (unit.IsLeased())
        //        {
        //            leasedArea += unit.Area;
        //        }
        //    }
        //    return leasedArea / grossLeasableArea * 100;
        //}


        //public double CalculateGrossLeasableAreaPerCenter()
        //{
        //    double GrossLeasableArea = 0;
        //    Premises.ForEach(p => GrossLeasableArea += p.Area);
           
        //    return GrossLeasableArea;
        //}

        //public double CalculateGrossLeasableAreaPerFloor(string floorName)
        //{
        //    double GrossLeasableArea = 0;
        //    Premises.Where(p=>p.Floor.Name==floorName).Sum(p=> GrossLeasableArea+=p.Area);

        //    return GrossLeasableArea;
        //}


        //public double CalculateOcupancyDegreePerFloor(string floorName)
        //{
        //    double grossLeasableArea = CalculateGrossLeasableAreaPerFloor(floorName);
        //    double leasedArea = 0;
        //    foreach (Unit unit in Premises)
        //    {
        //        if (unit.IsLeased()&&unit.Floor.Name==floorName)
        //        {
        //            leasedArea += unit.Area;
        //        }
        //    }
        //    return leasedArea / grossLeasableArea * 100;
        //}

        #endregion


        #region private methods
        
        #endregion
    }



}
