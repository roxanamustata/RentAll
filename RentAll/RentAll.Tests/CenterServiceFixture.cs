using Moq;
using NUnit.Framework;
using RentAll.Domain;
using RentAll.Domain.Interfaces;
using RentAll.Domain.Models;
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
        private Mock<ICenterRepository> _mockCenterRepository;


        [SetUp]
        public void Setup()
        {
            _mockCenterRepository = new Mock<ICenterRepository>();

            var floors = new List<Floor>() {
                            new Floor {Id=1,  FloorName = "Ground Floor" },
                            new Floor {Id=2, FloorName = "First Floor" }
            };

            var categories = new List<Category>()
            {
                new Category{Id=1, CategoryName="Non-food"},
                new Category{Id=2, CategoryName="Food"}

            };
            var activities = new List<Activity>()
            {
                new Activity{Id=1, ActivityName="Apparel",Category=categories.Where(c=>c.Id==1).Single(),},
                new Activity{Id=2, ActivityName="Shoes",Category=categories.Where(c=>c.Id==1).Single()},
                new Activity{Id=3, ActivityName="Restaurant",Category=categories.Where(c=>c.Id==2).Single()},

            };

            var centers = new List<Center>
                {
                    new Center {
                        Id = 1,
                        CenterName = "Iulius Mall Timisoara",
                        Floors = floors,
                        ParkingCapacity=2500

                    },
                    new Center {
                        Id = 2,
                        CenterName = "Iulius Mall Cluj",
                        Floors = floors.Where(f=>f.Id==1).ToList(),
                        ParkingCapacity=1500

                    }

                   };
            var leases = new List<Lease>()
            {
                new Lease {
                    Id = 1,

                   Activity = activities.Where(a=>a.Id==1).Single(),
                   Valid=true
                },

                new Lease {
                    Id = 2,

                   Activity = activities.Where(a=>a.Id==2).Single(),
                   Valid=true
                },

            };
            var units = new List<Unit>()
            {
                new Unit {
                                Id=1,
                                UnitCode="A1",
                                Area=500,
                                Floor= floors.Where(f=>f.Id==1).Single(),
                                Center=centers.Where(c=>c.Id==1).Single(),
                                Leases=leases.Where(l=>l.Id==1).ToList(),
                                Type=UnitType.Retail,
                                MonthlyRentSqm=15,
                                MonthlyMaintenanceCostSqm=5,
                                MonthlyMarketingFeeSqm=1,

                            },
                            new Unit {
                                Id=2,
                                UnitCode="A2",
                                Area=50,
                                Floor= floors.Where(f=>f.Id==1).Single(),
                                Center=centers.Where(c=>c.Id==1).Single(),
                                Leases=leases.Where(l=>l.Id==1).ToList(),
                                Type=UnitType.Storage,
                                MonthlyRentSqm=15,
                                MonthlyMaintenanceCostSqm=0,
                                MonthlyMarketingFeeSqm=0

                            },

                            new Unit {
                                Id=3,
                                UnitCode="A3",
                                Area=5000,
                                Floor= floors.Where(f=>f.Id==2).Single(),
                                Center=centers.Where(c=>c.Id==1).Single(),
                                Leases=leases.Where(l=>l.Id==1).ToList(),
                                Type=UnitType.Retail,
                                 MonthlyRentSqm=15,
                                MonthlyMaintenanceCostSqm=3,
                                MonthlyMarketingFeeSqm=1
                            },
                            new Unit {
                                Id=4,
                                UnitCode="A4",
                                Area=100,
                                Floor= floors.Where(f=>f.Id==1).Single(),
                                Center=centers.Where(c=>c.Id==2).Single(),
                                Leases=leases.Where(l=>l.Id==2).ToList(),
                                Type=UnitType.Retail,
                                MonthlyRentSqm=15,
                                MonthlyMaintenanceCostSqm=5,
                                MonthlyMarketingFeeSqm=1
                            },
                            new Unit {
                                Id=5,
                                UnitCode="A5",
                                Area=10,
                                Floor= floors.Where(f=>f.Id==1).Single(),
                                Center=centers.Where(c=>c.Id==2).Single(),
                                Leases=leases.Where(l=>l.Id==2).ToList(),
                                Type=UnitType.Storage,
                                MonthlyRentSqm=15,

                            },
                            new Unit {
                                Id=6,
                                UnitCode="A6",
                                Area=1000,
                                Floor= floors.Where(f=>f.Id==2).Single(),
                                Center=centers.Where(c=>c.Id==2).Single(),
                                Leases=leases.Where(l=>l.Id==2).ToList(),
                                Type=UnitType.Retail,
                                MonthlyRentSqm=10,
                                MonthlyMaintenanceCostSqm=5,
                                MonthlyMarketingFeeSqm=1

                        }


            };

            var center1 = centers.Where(c => c.Id == 1).Single();
            var unit1 = units.Where(u => u.Id == 1).Single();
            var unit2 = units.Where(u => u.Id == 2).Single();
            var unit3 = units.Where(u => u.Id == 3).Single();

            center1.Units = new List<Unit>() { unit1, unit2, unit3 };



            // Mock the Center Repository using Moq

            // Return all the centers
            //_mockCenterRepository.Setup(mr => mr.GetCenters()).Returns(Task<IEnumerable<Center>>.FromResult(centers));
       



            // return a center by Id
            _mockCenterRepository.Setup(mr => mr.GetCenterById(
                It.IsAny<int>())).Returns((int i) => Task.FromResult(centers.Where(
                x => x.Id == i).Single()));

            _mockCenterRepository.Setup(mr => mr.GetUnitById(
                It.IsAny<int>())).Returns((int i) => units.Where(
                x => x.Id == i).Single());

            _mockCenterRepository.Setup(mr => mr.GetLeaseById(
                It.IsAny<int>())).Returns((int i) => leases.Where(
                x => x.Id == i).Single());


            _mockCenterRepository.Setup(mr => mr.FindAllUnitsInCenter(
                It.IsAny<int>())).Returns((int i) => units.AsQueryable().Where(
                x => x.Center == centers.Where(
                x => x.Id == i).Single()));

            _mockCenterRepository.Setup(mr => mr.FindAllUnitsInCenterOnFloor(
                It.IsAny<int>(), It.IsAny<string>())).Returns((int i, string s) => units.AsQueryable()
                .Where(x => x.Center == centers.Where(x => x.Id == i).Single())
                .Where(x => x.Floor == floors.Where(f => f.FloorName == s).Single())
                );


            _mockCenterRepository.Setup(mr => mr.FindAllLeasedUnitsInCenter(
                It.IsAny<int>())).Returns((int i) => units.AsQueryable()
                .Where(x => x.Center == centers.Where(x => x.Id == i).Single())
                .Where(x => x.Leases.Any(l => l.Valid == true))
                );


            _mockCenterRepository.Setup(mr => mr.FindAllLeasedUnitsInCenterOnFloor(
                It.IsAny<int>(), It.IsAny<string>())).Returns((int i, string s) => units.AsQueryable()
                .Where(x => x.Center == centers.Where(x => x.Id == i).Single())
                .Where(x => x.Floor == floors.Where(f => f.FloorName == s).Single())
                .Where(x => x.Leases.Any(l => l.Valid == true))
                );

            _mockCenterRepository.Setup(mr => mr.FindUnitsByLeaseId(
                It.IsAny<int>())).Returns((int i) => units.AsQueryable().Where(
                x => x.Leases.All(l => l.Id == i)));


            _mockCenterRepository.Setup(mr => mr.FindAllLeasedRetailUnitsInCenterByActivity(
                It.IsAny<int>(), It.IsAny<string>())).Returns((int i, string s) => units.AsQueryable()
                .Where(x => x.Center == centers.Where(x => x.Id == i).Single())
                .Where(x => x.Leases.Any(l => l.Valid == true))
                .Where(u => u.Leases.Any(l => l.Activity == activities.Where(a => a.ActivityName == s).Single()))
                .Where(u => u.Type == UnitType.Retail)
                );

        }

        [TestCase(1, 5550)]
        public void TestCalculateGrossLeasableAreaPerCenter(int id, int expectedResult)
        {
            var centerService = new CenterService(_mockCenterRepository.Object);
            double result = centerService.CalculateGrossLeasableAreaOnCenter(id);
            Assert.AreEqual(expectedResult, result);

        }

        [TestCase(1, "Ground Floor", 550)]
        public void TestCalculateGrossLeasableAreaPerFloor(int centerId, string floorName, int expectedResult)
        {
            var centerService = new CenterService(_mockCenterRepository.Object);
            double result = centerService.CalculateGrossLeasableAreaInCenterOnFloor(centerId, floorName);
            Assert.AreEqual(expectedResult, result);

        }

        [TestCase(1, 5550)]
        public void TestCalculateLeasedAreaPerCenter(int centerId, double expectedResult)
        {
            var centerService = new CenterService(_mockCenterRepository.Object);
            double result = centerService.CalculateLeasedAreaOnCenter(1);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(1, 100)]
        public void TestCalculateOcupancyDegreeOnCenter(int centerId, double expectedResult)
        {
            var centerService = new CenterService(_mockCenterRepository.Object);
            double result = centerService.CalculateOcupancyDegreeOnCenter(centerId);
            Assert.AreEqual(expectedResult, result);

        }


        [TestCase(1, "Ground Floor", 100)]
        public void TestCalculateOcupancyDegreeInCenterOnFloor(int centerId, string floorName, double expectedResult)
        {
            var centerService = new CenterService(_mockCenterRepository.Object);
            double result = centerService.CalculateOcupancyDegreeInCenterOnFloor(centerId, floorName);
            Assert.AreEqual(expectedResult, result);

        }

        [TestCase(1, 83250)]
        public void TestCalculateTotalRentOnCenter(int centerId, double expectedResult)
        {

            var centerService = new CenterService(_mockCenterRepository.Object);
            double result = centerService.CalculateTotalRentOnCenter(centerId);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(1, 15)]
        public void TestCalculateAverageRentPerSqmOnCenter(int centerId, double expectedResult)
        {
            var centerService = new CenterService(_mockCenterRepository.Object);
            double result = centerService.CalculateAverageRentPerSqmOnCenter(centerId);
            Assert.AreEqual(expectedResult, result);
        }


        [TestCase(1, 106250)]
        public void TestCalculateTotalCostsPerLease(int leaseId, double expectedResult)
        {
            var centerService = new CenterService(_mockCenterRepository.Object);
            double result = centerService.CalculateTotalCostsPerLease(leaseId);
            Assert.AreEqual(expectedResult, result);
        }


        [TestCase(1, "Apparel", 5500)]
        public void TestCalculateLeasedAreaInCenterOnActivity(int centerId, string activityName, double expectedResult)
        {
            var centerService = new CenterService(_mockCenterRepository.Object);
            double result = centerService.CalculateLeasedAreaInCenterOnActivity(centerId, activityName);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(1, "Apparel", 82500)]
        public void TestCalculateTotalRentInCenterOnActivity(int centerId, string activityName, double expectedResult)
        {

            var centerService = new CenterService(_mockCenterRepository.Object);
            double result = centerService.CalculateTotalRentInCenterOnActivity(centerId, activityName);
            Assert.AreEqual(expectedResult, result);
        }
        [TestCase(1, "Apparel", 15)]
        public void TestCalculateAverageRentPerSqmInCenterOnActivity(int centerId, string activityName, double expectedResult)
        {
            var centerService = new CenterService(_mockCenterRepository.Object);
            double result = centerService.CalculateAverageRentPerSqmInCenterOnActivity(centerId, activityName);
            Assert.AreEqual(expectedResult, result);
        }

    }
}