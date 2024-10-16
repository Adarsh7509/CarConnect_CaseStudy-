using NUnit.Framework;
using System;
using CarConnect.BusinessLayer.Repositories;
using CarConnect.BusinessLayer.Services;
using CarConnect.entity;

namespace CarConnect.Tests
{
    [TestFixture]
    public class ReservationServiceTests
    {
        private IReservationService _reservationService;

        [SetUp]
        public void SetUp()
        {
            _reservationService = new ReservationService();
        }

        [Test]
        public void CreateReservation_ShouldCalculateTotalCostCorrectly()
        {
            var reservation = new Reservation
            {
                ReservationID = 1,
                VehicleID = 1,
                CustomerID = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(3),
                
            };

            reservation.CalculateTotalCost(100.0); // Assuming a daily rate of 100

            
        }

        [Test]
        public void CreateReservation_ShouldAddReservationSuccessfully()
        {
            var reservation = new Reservation
            {
                ReservationID = 1,
                VehicleID = 1,
                CustomerID = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(3),
                Status = "Active"
            };

            _reservationService.CreateReservation(reservation);
            var retrievedReservation = _reservationService.GetReservationById(1);

            
        }
    }
}

