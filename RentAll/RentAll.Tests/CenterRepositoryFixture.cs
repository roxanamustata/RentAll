using NUnit.Framework;
using RentAll.Domain;
using RentAll.Domain.Interfaces;
using RentAll.Infrastructure.Repositories;

namespace RentAll.Tests
{
    [TestFixture]
    public class CenterRepositoryFixture
    {
        private ICenterRepository _centerRepository;
        public CenterRepositoryFixture(ICenterRepository centerRepository)
        {
            _centerRepository = centerRepository;
        }

        [SetUp]
        public void Setup()
        {
            // Arrange
            var center1 = _centerRepository.FindCenterById(1);
            var unit1 = _centerRepository.FindUnitById(1);
            var unit2 = _centerRepository.FindUnitById(2);
            var unit3 =_centerRepository.FindUnitById(3);
            center1.Premises.Add(unit1);
            center1.Premises.Add(unit2);
            center1.Premises.Add(unit3);
            var lease1 = _centerRepository.FindLeaseById(1);
            lease1.Premises.Add(unit1);
            lease1.Premises.Add(unit2);
            unit1.Leases.Add(lease1);
            unit2.Leases.Add(lease1);
        }

        
        [TestCase(1)]
        [TestCase(4)]
        public void FindLeaseByIdTest(int leaseId)
        {
           
            var result = _centerRepository.FindLeaseById(leaseId);
            Assert.IsNotNull(result);
        }
       
        [TestCase(1)]
        [TestCase(2)]
        public void IsLeasedTest(int unitId)
        {
            
            var result = _centerRepository.IsLeased(unitId);
            Assert.IsTrue(result);
        }


    }
}