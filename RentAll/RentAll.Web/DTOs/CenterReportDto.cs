﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentAll.Web.DTOs
{
    public class CenterReportDto
    {

        public double LeasableArea { get; set;}
        public double LeasedArea { get; set;}
        public double OccupancyDegree { get; set;}
        public double AverageRent { get; set;}
        public double TotalRentIncome { get; set; }

        public double TotalRentIncomeOnNonFood { get; set; }
        public double TotalRentIncomeOnFood { get; set; }
        public double TotalRentIncomeOnEntertainment { get; set; }
        public double TotalRentIncomeOnServices { get; set; }
    }
}
