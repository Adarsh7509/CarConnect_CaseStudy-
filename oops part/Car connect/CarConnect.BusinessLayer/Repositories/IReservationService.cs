﻿using CarConnect.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.BusinessLayer.Repositories
{
    public interface IReservationService
    {
        Reservation GetReservationById(int reservationId);
        IEnumerable<Reservation> GetAllReservations();
        IEnumerable<Reservation> GetReservationsByCustomerId(int customerId);
        void CreateReservation(Reservation reservationData);
        void UpdateReservation(Reservation reservationData);
        void CancelReservation(int reservationId);
        decimal CalculateTotalCost(DateTime startDate, DateTime endDate, decimal dailyRate);
    }
}
