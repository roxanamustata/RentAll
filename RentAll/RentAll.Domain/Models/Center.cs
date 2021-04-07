using System;
using System.Collections.Generic;
using System.Text;

namespace RentAll.Domain
{
    public class Center
    {
        #region properties

        public int Id { get; private set; }
        public string Name { get; set; }
        public Company Owner { get; set; }
        public List<Floor> Floors { get; set; }
        public int ParkingCapacity { get; set; }
        public List<Unit> Premises { get; set; }

        #endregion


        #region public methods


        public double CalculateGrossLeasableArea()
        {
            double GLA = 0;
            foreach (Unit Unit in this.Premises)
            {
                GLA += Unit.Area;

            }

            return GLA;
        }

        #endregion
        public  double CalculateOcupancyDegree()
        {
            double grossLeasableArea = CalculateGrossLeasableArea();
            double leasedArea = 0;
            foreach (Unit unit in Premises)
            {
                if (unit.IsLeased())
                {
                    leasedArea += unit.Area;
                }
            }
            return leasedArea / grossLeasableArea * 100;
        }




    }



}
