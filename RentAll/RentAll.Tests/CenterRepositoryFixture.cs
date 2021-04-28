using NUnit.Framework;
using RentAll.Domain;
using RentAll.Domain.Interfaces;
using RentAll.Infrastructure.Repositories;

namespace RentAll.Tests
{
    [TestFixture]
    public class CenterRepositoryFixture
    {
        private ICenterRepository centerRepository = new CenterRepository();

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
            double result = centerRepository.CalculateCostsPerLease(leaseId);
            Assert.AreEqual(expected, result);

        }
        [TestCase(1)]
        [TestCase(4)]
        public void FindLeaseByIdTest(int leaseId)
        {
           
            var result = centerRepository.FindLeaseById(leaseId);
            Assert.IsNotNull(result);
        }
       
        [TestCase(1)]
        [TestCase(2)]
        public void IsLeasedTest(int unitId)
        {
            
            var result = centerRepository.IsLeased(unitId);
            Assert.IsTrue(result);
        }


    }
}