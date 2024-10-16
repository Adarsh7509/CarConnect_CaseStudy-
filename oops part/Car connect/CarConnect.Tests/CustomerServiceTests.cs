using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Authentication;
using CarConnect.BusinessLayer.Repositories;
using CarConnect.BusinessLayer.Services;
using CarConnect.entity;

namespace CarConnect.Tests
{
    [TestFixture]
    public class CustomerServiceTests
    {
        private ICustomerService _customerService;

        [SetUp]
        public void SetUp()
        {
            _customerService = new CustomerService();
            _customerService.RegisterCustomer(new Customer
            {
                CustomerID = 1,
                Username = "testuser",
                Password = "testpass",
                FirstName = "adarsh",
                LastName = "sharma",
                Email = "adaer@gmail.com"
            });
        }

        [Test]
        public void Authenticate_InvalidPassword_ShouldThrowAuthenticationException()
        {
            var customer = _customerService.GetCustomerByUsername("testuser");

            // Simulate incorrect password
            var invalidPassword = "wrongpass";

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ThrowsException<AuthenticationException>(() => customer.Authenticate(invalidPassword));
        }

       
        
    }
}
