using CarConnect.BusinessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.BusinessLayer.Services
{
    public class ReportGenerator
    {
        public readonly IReservationService reservationService;
        public readonly IVehicleService vehicleService;

        public ReportGenerator(IReservationService reservationService, IVehicleService vehicleService)
        {
            this.reservationService = reservationService;
            this.vehicleService = vehicleService;
        }
        // generating reservation reports for all reservations
        public void GenerateReservationReport()
        {
            var reservations = reservationService.GetAllReservations();
            foreach (var reservation in reservations)
            {
                var customer = reservation.CustomerID;
                var vehicle = vehicleService.GetVehicleById(reservation.VehicleID);
                Console.WriteLine($"Reservation ID: {reservation.ReservationID}, Customer ID: {customer}, Vehicle: {vehicle.Make} {vehicle.Model}, Start Date: {reservation.StartDate.ToShortDateString()}, End Date: {reservation.EndDate.ToShortDateString()}, Total Cost: {reservation.TotalCost:C}, Status: {reservation.Status}");
            }
        }
        // generating reservation report based on availability
        public void GenerateVehicleAvailabilityReport()
        {
            var availableVehicles = vehicleService.GetAvailableVehicles();
            Console.WriteLine("Available Vehicles:");
            foreach (var vehicle in availableVehicles)
            {
                Console.WriteLine($"VehicleID: {vehicle.VehicleID}, Model: {vehicle.Model}, Make: {vehicle.Make}, Year: {vehicle.Year}, DailyRate: {vehicle.DailyRate}");
            }
        }
    }
}
