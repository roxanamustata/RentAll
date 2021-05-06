using Moq;
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
        private readonly Mock<ICenterRepository> _centerRepository = new Mock<ICenterRepository>();
        
        [SetUp]
        public void Setup()
        {
            // Arrange
            //ToDo: setup of the _centerRepository mock
        }


        [TestCase(1)]
        public void CalculateCostsPerLeaseTest(int leaseId)
        {
            var centerService = new CenterService(_centerRepository.Object);

            double expected = 9350;
            double result = centerService.CalculateCostsPerLease(leaseId);
            Assert.AreEqual(expected, result);

        }
    }
}
