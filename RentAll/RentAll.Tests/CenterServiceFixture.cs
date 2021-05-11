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
            //ToDo: setup of the _centerRepository mock
            // create some mock products to play with

            var floors = new List<Floor>() {
                            new Floor {Id=1,  Name = "Ground Floor" },
                            new Floor {Id=2, Name = "First Floor" }
            };

            var categories = new List<ActivityCategory>()
            {
                new ActivityCategory{Id=1, Name="Non-food"},
                new ActivityCategory{Id=2, Name="Food"}

            };
            var activities = new List<Activity>()
            {
                new Activity{Id=1, Name="Apparel", ActivityCategory=categories.Where(c=>c.Id==1).Single(),},
                new Activity{Id=2, Name="Shoes",ActivityCategory=categories.Where(c=>c.Id==1).Single()},
                new Activity{Id=3, Name="Restaurant",ActivityCategory=categories.Where(c=>c.Id==2).Single()},

            };

            var centers = new List<Center>
                {
                    new Center {
                        Id = 1,
                        Name = "Iulius Mall Timisoara",
                        Floors = floors,
                        ParkingCapacity=2500

                    },
                    new Center {
                        Id = 2,
                        Name = "Iulius Mall Cluj",
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
                                Code="A1",
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
                                Code="A2",
                                Area=50,
                                Floor= floors.Where(f=>f.Id==1).Single(),
                                Center=centers.Where(c=>c.Id==1).Single(),
                                Leases=leases.Where(l=>l.Id==1).ToList(),
                                Type=UnitType.Storage,
                                MonthlyRentSqm=15,

                            },

                            new Unit {
                                Id=3,
                                Code="A3",
                                Area=5000,
                                Floor= floors.Where(f=>f.Id==2).Single(),
                                Center=centers.Where(c=>c.Id==1).Single(),
                                Type=UnitType.Retail
                            },
                            new Unit {
                                Id=4,
                                Code="A4",
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
                                Code="A5",
                                Area=10,
                                Floor= floors.Where(f=>f.Id==1).Single(),
                                Center=centers.Where(c=>c.Id==2).Single(),
                                Leases=leases.Where(l=>l.Id==2).ToList(),
                                Type=UnitType.Storage,
                                MonthlyRentSqm=15,

                            },
                            new Unit {
                                Id=6,
                                Code="A6",
                                Area=1000,
                                Floor= floors.Where(f=>f.Id==2).Single(),
                                Center=centers.Where(c=>c.Id==2).Single(),
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

            center1.Premises = new List<Unit>() { unit1, unit2, unit3 };



            // Mock the Center Repository using Moq

            // Return all the centers
            _mockCenterRepository.Setup(mr => mr.FindAll()).Returns(centers);



            // return a center by Id
            _mockCenterRepository.Setup(mr => mr.FindCenterById(
                It.IsAny<int>())).Returns((int i) => centers.Where(
                x => x.Id == i).Single());

            _mockCenterRepository.Setup(mr => mr.FindUnitById(
                It.IsAny<int>())).Returns((int i) => units.Where(
                x => x.Id == i).Single());

            _mockCenterRepository.Setup(mr => mr.FindLeaseById(
                It.IsAny<int>())).Returns((int i) => leases.Where(
                x => x.Id == i).Single());

            // return a center by Name
            _mockCenterRepository.Setup(mr => mr.FindByName(
                It.IsAny<string>())).Returns((string s) => centers.Where(
                x => x.Name == s).Single());

            // Allows us to test saving a center
            _mockCenterRepository.Setup(mr => mr.Save(It.IsAny<Center>())).Returns(
                (Center target) =>
                {

                    if (target.Id.Equals(default(int)))
                    {
                        target.Id = centers.Count() + 1;
                        centers.Add(target);
                    }
                    else
                    {
                        var original = centers.Where(
                            c => c.Id == target.Id).Single();

                        if (original == null)
                        {
                            return false;
                        }

                        original.Name = target.Name;
                        original.Floors = target.Floors;
                        original.Premises = target.Premises;
                        original.ParkingCapacity = target.ParkingCapacity;

                    }

                    return true;
                });



        }

        //[TestCase(1)]
        //public void TestFindCenterById(int centerId)
        //{
        //    var service = new CenterService(_mockCenterRepository.Object);
        //    _mockCenterRepository.Verify(m => m.FindCenterById(centerId), Times.Once);

        //}


        [TestCase(1, 5550)]
        public void TestCalculateGrossLeasableAreaPerCenter(int id, int expectedResult)
        {
            var centerService = new CenterService(_mockCenterRepository.Object);
            double result = centerService.CalculateGrossLeasableAreaPerCenter(id);
            Assert.AreEqual(expectedResult, result);

        }

        [TestCase(1, "Ground Floor", 550)]
        public void TestCalculateGrossLeasableAreaPerFloor(int centerId, string floorName, int expectedResult)
        {
            var centerService = new CenterService(_mockCenterRepository.Object);
            double result = centerService.CalculateGrossLeasableAreaPerFloor(centerId, floorName);
            Assert.AreEqual(expectedResult, result);

        }

        [TestCase(1, 550)]
        public void TestCalculateLeasedAreaPerCenter(int centerId, double expectedResult)
        {
            var centerService = new CenterService(_mockCenterRepository.Object);
            double result = centerService.CalculateLeasedAreaPerCenter(1);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(1, 8250)]
        public void TestCalculateRentPerLease(int leaseId, double expectedResult)
        {

            var centerService = new CenterService(_mockCenterRepository.Object);
            double result = centerService.CalculateLeasedAreaPerCenter(leaseId);
            Assert.AreEqual(expectedResult, result);
        }




    }
}
