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
        private readonly Mock<ICenterRepository> mockCenterRepository = new Mock<ICenterRepository>();
        public ICenterRepository MockCentersRepository { get; set; }





        [SetUp]
        public void Setup()
        {

            //ToDo: setup of the _centerRepository mock
            // create some mock products to play with

            List<Floor> floors = new List<Floor>() {
                            new Floor {Id=1,  Name = "Ground Floor" },
                            new Floor {Id=2, Name = "First Floor" }
            };

            List<ActivityCategory> categories = new List<ActivityCategory>()
            {
                new ActivityCategory{Id=1, Name="Non-food"},
                new ActivityCategory{Id=2, Name="Food"}

            };
            List<Activity> activities = new List<Activity>()
            {
                new Activity{Id=1, Name="Apparel", ActivityCategory=categories.FirstOrDefault(c=>c.Id==1)},
                new Activity{Id=2, Name="Shoes",ActivityCategory=categories.FirstOrDefault(c=>c.Id==1)},
                new Activity{Id=3, Name="Restaurant",ActivityCategory=categories.FirstOrDefault(c=>c.Id==2)},

            };


            IList<Center> centers = new List<Center>
                {
                    new Center {
                        Id = 1,
                        Name = "Iulius Mall Timisoara",
                        Floors = floors,
                        Premises = new List<Unit>()
                        {
                            new Unit {
                                Id=1,
                                Code="A1",
                                Area=500,
                                Floor= floors.FirstOrDefault(f=>f.Id==1),
                                Type=UnitType.Retail,
                                MonthlyRentSqm=15,
                                MonthlyMaintenanceCostSqm=5,
                                MonthlyMarketingFeeSqm=1,

                            },
                            new Unit {
                                Id=2,
                                Code="A2",
                                Area=50,
                                Floor= floors.FirstOrDefault(f=>f.Id==1),
                                Type=UnitType.Storage,
                                MonthlyRentSqm=15,

                            },
                            new Unit {
                                Id=3,
                                Code="A3",
                                Area=5000,
                                Floor= floors.FirstOrDefault(f=>f.Id==2),
                                Type=UnitType.Retail},

                        },
                        ParkingCapacity=2500

                    },
                    new Center {
                        Id = 2,
                        Name = "Iulius Mall Cluj",
                        Floors = floors.Where(f=>f.Id==1).ToList(),
                        Premises = new List<Unit>()
                        {
                            new Unit {
                                Id=4,
                                Code="A4",
                                Area=100,
                                Floor= floors.FirstOrDefault(f=>f.Id==1),
                                Type=UnitType.Retail,
                                MonthlyRentSqm=15,
                                MonthlyMaintenanceCostSqm=5,
                                MonthlyMarketingFeeSqm=1
                            },
                            new Unit {
                                Id=5,
                                Code="A5",
                                Area=10,
                                Floor= floors.FirstOrDefault(f=>f.Id==1),
                                Type=UnitType.Storage,
                                MonthlyRentSqm=15,

                            },
                            new Unit {
                                Id=6,
                                Code="A6",
                                Area=1000,
                                Floor= floors.FirstOrDefault(f=>f.Id==2),
                                Type=UnitType.Retail,
                            MonthlyRentSqm=10,
                            MonthlyMaintenanceCostSqm=5,
                                MonthlyMarketingFeeSqm=1

                        }
                    },
                        ParkingCapacity=1500
                     }
                   };


            //IList<Lease> leases = new List<Lease>()
            //{
            //    new Lease {
            //        Id = 1,
            //        Premises = {
            //            centers.FirstOrDefault(c=>c.Id==1).Premises.FirstOrDefault(u=>u.Id==1),
            //            centers.FirstOrDefault(c=>c.Id==1).Premises.FirstOrDefault(u=>u.Id==2)
            //        },
            //       Activity = activities.FirstOrDefault(a=>a.Id==1)
            //    },

            //    new Lease {
            //        Id = 2,
            //        Premises = {

            //            centers.FirstOrDefault(c=>c.Id==1).Premises.FirstOrDefault(u=>u.Id==3)
            //        },
            //       Activity = activities.FirstOrDefault(a=>a.Id==2)
            //    },

            //};

            //centers.FirstOrDefault(c => c.Id == 1).
            //    Premises.FirstOrDefault(u => u.Id == 1)
            //    .Leases.Add(leases.FirstOrDefault(l => l.Id == 1));

            //centers.FirstOrDefault(c => c.Id == 1).
            //    Premises.FirstOrDefault(u => u.Id == 2)
            //    .Leases.Add(leases.FirstOrDefault(l => l.Id == 1));

            //centers.FirstOrDefault(c => c.Id == 1).
            //    Premises.FirstOrDefault(u => u.Id == 3)
            //    .Leases.Add(leases.FirstOrDefault(l => l.Id == 2));



            // Mock the Center Repository using Moq

            // Return all the centers
            mockCenterRepository.Setup(mr => mr.FindAll()).Returns(centers);

            // return a center by Id
            mockCenterRepository.Setup(mr => mr.FindCenterById(
                It.IsAny<int>())).Returns((int i) => centers.Where(
                x => x.Id == i).Single());

            // return a center by Name
            mockCenterRepository.Setup(mr => mr.FindByName(
                It.IsAny<string>())).Returns((string s) => centers.Where(
                x => x.Name == s).Single());

            // Allows us to test saving a center
            mockCenterRepository.Setup(mr => mr.Save(It.IsAny<Center>())).Returns(
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


            MockCentersRepository = mockCenterRepository.Object;
        }


        // Can we return a product By Id?
        [TestCase(1)]
        public void CanReturnCenterById(int id)
        {

            // Try finding a product by id
            Center testCenter = MockCentersRepository.FindCenterById(id);

            Assert.IsNotNull(testCenter); // Test if null
            Assert.IsInstanceOf(typeof(Center), testCenter); // Test type
            Assert.AreEqual("Iulius Mall Timisoara", testCenter.Name); // Verify it is the right product
        }

        [TestCase("Iulius Mall Timisoara")]
        public void CanReturnCenterByName(string name)
        {
            // Try finding a product by Name
            Center testCenter = MockCentersRepository.FindByName(name);

            Assert.IsNotNull(testCenter); // Test if null
            Assert.IsInstanceOf(typeof(Center), testCenter); // Test type
            Assert.AreEqual(1, testCenter.Id); // Verify it is the right product
        }


        [TestCase]
        public void CanReturnAllProducts()
        {
            // Try finding all products
            IList<Center> testCenters = this.MockCentersRepository.FindAll();

            Assert.IsNotNull(testCenters); // Test if null
            Assert.AreEqual(2, testCenters.Count); // Verify the correct Number
        }


        [TestCase(1)]
        public void CalculateGrossLeasableAreaPerCenter(int id)
        {
            var centerService = new CenterService(MockCentersRepository);
           
                      
            double result = centerService.CalculateGrossLeasableAreaPerCenter(id);
            Assert.AreEqual(5550, result);

        }

        [TestCase(1, "Ground Floor")]
        public void CalculateGrossLeasableAreaPerFloor(int centerId, string floorName)
        {
            var centerService = new CenterService(MockCentersRepository);


            double result = centerService.CalculateGrossLeasableAreaPerFloor(centerId,floorName);
            Assert.AreEqual(550, result);

        }

    }
}
