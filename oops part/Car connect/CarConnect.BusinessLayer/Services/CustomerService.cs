﻿using CarConnect.BusinessLayer.Exceptions;
using CarConnect.BusinessLayer.Repositories;
using CarConnect.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.BusinessLayer.Services
{
    public class CustomerService : ICustomerService
    {
        public readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepo)
        {
            customerRepository = customerRepo;
        }

        public CustomerService()
        {
        }

        public Customer GetCustomerById(int customerId)
        {
            var customer = customerRepository.GetById(customerId);
            if (customer == null) throw new CustomerNotFoundException("customer not found");
            return customer;
        }

        public Customer GetCustomerByUsername(string username)
        {
            var customer = customerRepository.GetAll().FirstOrDefault(c => c.Username == username);
            if (customer == null) throw new CustomerNotFoundException("customer not found");
            return customer;
        }

        public void RegisterCustomer(Customer customer)
        {
            customer.RegistrationDate = DateTime.Now;
            customerRepository.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            var c = customerRepository.GetById(customer.CustomerID);
            if (c == null) throw new CustomerNotFoundException("customer not found");
            customerRepository.Update(customer);
        }

        public void DeleteCustomer(int customerId)
        {
            var c = customerRepository.GetById(customerId);
            if (c == null) throw new CustomerNotFoundException("customer not found");
            customerRepository.Delete(customerId);
        }
    }
}
