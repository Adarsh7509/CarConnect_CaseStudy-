﻿
using Microsoft.TeamFoundation.Framework.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.Utils
{
    public static class DatabaseInitializer
    {
       
        public static void Initialize()
        {
            using (var connection = DBConn.GetConnection())
                

            {
                try
                {
                    if (connection == null) throw new DatabaseConnectionException("Database connection failed. Cannot initialize the database.");
                    string createTablesSql = @"
                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Customers' AND xtype='U')
                        CREATE TABLE Customers (
                            CustomerID INT PRIMARY KEY IDENTITY(1,1),
                            FirstName NVARCHAR(50),
                            LastName NVARCHAR(50),
                            Email NVARCHAR(100),
                            PhoneNumber NVARCHAR(20),
                            Address NVARCHAR(200),
                            Username NVARCHAR(50),
                            Password NVARCHAR(100),
                            RegistrationDate DATE
                        );

                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Vehicles' AND xtype='U')
                        CREATE TABLE Vehicles (
                            VehicleID INT PRIMARY KEY IDENTITY(1,1),
                            Model NVARCHAR(100),
                            Make NVARCHAR(100),
                            Year INT,
                            Color NVARCHAR(50),
                            RegistrationNumber NVARCHAR(50),
                            Availability BIT,
                            DailyRate DECIMAL(18, 2)
                        );

                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Reservations' AND xtype='U')
                        CREATE TABLE Reservations (
                            ReservationID INT PRIMARY KEY IDENTITY(1,1),
                            CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
                            VehicleID INT FOREIGN KEY REFERENCES Vehicles(VehicleID),
                            StartDate DATE,
                            EndDate DATE,
                            TotalCost DECIMAL(18, 2),
                            Status NVARCHAR(50)
                        );

                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Admins' AND xtype='U')
                        CREATE TABLE Admins (
                            AdminID INT PRIMARY KEY IDENTITY(1,1),
                            FirstName NVARCHAR(50),
                            LastName NVARCHAR(50),
                            Email NVARCHAR(100),
                            PhoneNumber NVARCHAR(20),
                            Username NVARCHAR(50),
                            Password NVARCHAR(100),
                            Role NVARCHAR(50),
                            JoinDate DATE
                        );
                    ";
                }
                catch (Exception ex) { }
            }
        }
    }
}
