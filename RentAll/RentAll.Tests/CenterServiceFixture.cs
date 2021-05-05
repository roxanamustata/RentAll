using NUnit.Framework;
using RentAll.Domain.Interfaces;
using RentAll.Infrastructure.Repositories;
using RentAll.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAll.Tests
{
    [TestFixture]
    public class CenterServiceFixture
    {
        private readonly ICenterRepository _centerRepository;
        private readonly ICenterService _centerService;

        public CenterServiceFixture(ICenterRepository centerRepository, ICenterService centerService)
        {
            _centerRepository = centerRepository;
            _centerService = centerService;
        }

        [SetUp]
        public void Setup()
        {
            // Arrange

            var center1 = _centerRepository.FindCenterById(1);
            var unit1 = _centerRepository.FindUnitById(1);
            var unit2 = _centerRepository.FindUnitById(2);
            var unit3 = _centerRepository.FindUnitById(3);
            center1.Units.Add(unit1);
            center1.Units.Add(unit2);
            center1.Units.Add(unit3);
            var lease1 = _centerRepository.FindLeaseById(1);
            lease1.Units.Add(unit1);
            lease1.Units.Add(unit2);
            unit1.Leases.Add(lease1);
            unit2.Leases.Add(lease1);
        }


        [TestCase(1)]
        public void CalculateCostsPerLeaseTest(int leaseId)
        {
            double expected = 9350;
            double result = _centerService.CalculateCostsPerLease(leaseId);
            Assert.AreEqual(expected, result);

        }

        [TestCase(1)]
        public void CalculateOcupancyDegreePerCenterTest(int centerId)
        {
            double expected = 78.57;
            double result = Math.Round(_centerService.CalculateOcupancyDegreePerCenter(centerId),2);
            Assert.AreEqual(expected, result);

        }


    }
}
