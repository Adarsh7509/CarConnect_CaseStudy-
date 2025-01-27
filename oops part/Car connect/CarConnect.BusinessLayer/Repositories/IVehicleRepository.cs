﻿using CarConnect.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.BusinessLayer.Repositories
{
    public interface IVehicleRepository
    {
        void Add(Vehicle vehicle);
        void Delete(int vehicleId);
        IEnumerable<Vehicle> GetAll();
        Vehicle GetById(int vehicleId);
        void Update(Vehicle vehicle);
    }

}
