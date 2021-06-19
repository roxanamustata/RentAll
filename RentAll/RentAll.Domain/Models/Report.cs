﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAll.Domain.Models
{
   public class Report
    {

        public double LeasableArea { get; set; }
        public double LeasedArea { get; set; }
        public double OccupancyDegree { get; set; }
        public double AverageRent { get; set; }
        public double TotalRentIncome { get; set; }
    }
}