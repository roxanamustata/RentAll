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
        private CenterRepository centerRepository;
        private ICenterService centerService;

        public CenterServiceFixture()
        {
            centerRepository = new CenterRepository();
            centerService = new CenterService(centerRepository);
        }

        [SetUp]
        public void Setup()
        {
            // Arrange

            var center1 = centerRepository.FindCenterById(1);
            var unit1 = centerRepository.FindUnitById(1);
            var unit2 = centerRepository.FindUnitById(2);
            var unit3 = centerRepository.FindUnitById(3);
            center1.Premises.Add(unit1);
            center1.Premises.Add(unit2);
            center1.Premises.Add(unit3);
            var lease1 = centerRepository.FindLeaseById(1);
            lease1.Premises.Add(unit1);
            lease1.Premises.Add(unit2);
            unit1.Leases.Add(lease1);
            unit2.Leases.Add(lease1);
        }


        [TestCase(1)]
        public void CalculateCostsPerLeaseTest(int leaseId)
        {
            double expected = 9350;
            double result = centerService.CalculateCostsPerLease(leaseId);
            Assert.AreEqual(expected, result);

        }

        [TestCase(1)]
        public void CalculateOcupancyDegreePerCenterTest(int centerId)
        {
            double expected = 78.57;
            double result = Math.Round(centerService.CalculateOcupancyDegreePerCenter(centerId),2);
            Assert.AreEqual(expected, result);

        }


    }
}
