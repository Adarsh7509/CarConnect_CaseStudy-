using NUnit.Framework;
using CarConnect.BusinessLayer.Repositories;
using CarConnect.BusinessLayer.Services;
using CarConnect.entity;

namespace CarConnect.Tests
{
    [TestFixture]
    public class VehicleServiceTests
    {
        private IVehicleService _vehicleService;

        [SetUp]
        public void SetUp()
        {
            _vehicleService = new VehicleService();
        }

        [Test]
        public void AddVehicle_ShouldAddVehicleSuccessfully()
        {
            var vehicle = new Vehicle
            {
                VehicleID = 1,
                Model = "Tesla",
                Make = "Model S",
                Year = 2023,
                Color = "Red",
                Availability = true,
                
            };

            _vehicleService.AddVehicle(vehicle);
            var retrievedVehicle = _vehicleService.GetVehicleById(1);

           
        }

        [Test]
        public void GetAvailableVehicles_ShouldReturnAvailableVehicles()
        {
            var vehicle1 = new Vehicle { VehicleID = 1, Model = "Tesla", Availability = true };
            var vehicle2 = new Vehicle { VehicleID = 2, Model = "BMW", Availability = false };

            _vehicleService.AddVehicle(vehicle1);
            _vehicleService.AddVehicle(vehicle2);

            var availableVehicles = _vehicleService.GetAvailableVehicles();

            
        }
    }
}

