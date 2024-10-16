using CarConnect.BusinessLayer.Exceptions;
using CarConnect.BusinessLayer.Repositories;
using CarConnect.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.BusinessLayer.Services
{
    public class AuthenticationService
    {
        public readonly ICustomerService customerService;
        public readonly IAdminService adminService;

        public AuthenticationService(ICustomerService customerService, IAdminService adminService)
        {
            this.customerService = customerService;
            this.adminService = adminService;
        }
        public Customer AuthenticateCustomer(string username, string password)
        {
            try
            {
                var customer = GetCustomerByUsername(username);
                if (customer == null || customer.Password != password)
                    throw new AuthenticationException("Invalid username or password.");
                return customer;
            }
            catch (AuthenticationException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return null;
        }

        private Customer GetCustomerByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Admin AuthenticateAdmin(string username, string password)
        {
            try
            {
                var admin = adminService.GetAdminByUsername(username);
                if (admin == null || admin.Password != password)
                    throw new AuthenticationException("Invalid username or password.");
                return admin;
            }
            catch (AuthenticationException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return null;
        }
    }
}

