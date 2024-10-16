using CarConnect.BusinessLayer.Repositories;
using CarConnect.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.BusinessLayer.Services
{
    public class ReservationService : IReservationService
    {
        public readonly IReservationRepository reservationRepository;

        public ReservationService(IReservationRepository reservationRepo)
        {
            reservationRepository = reservationRepo;
        }

        public ReservationService()
        {
        }

        public Reservation GetReservationById(int reservationId)
        {
            return reservationRepository.GetById(reservationId);
        }

        public IEnumerable<Reservation> GetReservationsByCustomerId(int customerId)
        {
            return reservationRepository.GetReservationsByCustomerId(customerId);
        }

        public void CreateReservation(Reservation reservation)
        {
            reservationRepository.Add(reservation);
        }

        public void UpdateReservation(Reservation reservation)
        {
            reservationRepository.Update(reservation);
        }

        public void CancelReservation(int reservationId)
        {
            reservationRepository.Delete(reservationId);
        }
        public decimal CalculateTotalCost(DateTime startDate, DateTime endDate, decimal dailyRate)
        {
            var days = (endDate - startDate).Days;
            if (days <= 0) throw new ArgumentException("End date must be later than start date.");
            return days * dailyRate;
        }
        public IEnumerable<Reservation> GetAllReservations()
        {
            return reservationRepository.GetAllReservations();
        }
    }
}
