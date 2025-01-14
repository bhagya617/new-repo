//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Employee_Travel_Booking_MVC.Models;
using Employee_Travel_Booking_MVC.Controllers.Admin;
using Employee_Travel_Booking_MVC.Controllers.Employee;
using NUnit.Framework;
using Moq;
using System.Data.Entity;
using System.Web.Mvc;
using NUnit.Framework.Legacy;

namespace UnitTestProject
{
    [TestFixture]
    public class Tests
    {
        private AdminLoginController _controller;
        private EmployeeLoginController _econtroller;
        private Mock<Employee_Travel_Booking_SystemDB1Entities1> _mockContext;
        private Mock<DbSet<admin>> _mockAdmins;
        private Mock<DbSet<employee>> _mockEmployee;

        [SetUp]
        public void Setup()
        {
            // Initialize mocks
            _mockContext = new Mock<Employee_Travel_Booking_SystemDB1Entities1>();
            _mockAdmins = new Mock<DbSet<admin>>();
            _mockEmployee = new Mock<DbSet<employee>>();


            _controller = new AdminLoginController();
            _econtroller = new EmployeeLoginController();
        }

        // Login Redirecting to its View
        [Test]
        public void Login_Get_ReturnsView()
        {
            var result = _controller.Login() as ViewResult;
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual("", result.ViewName);

        }
        [Test]
        public void Login_Get_EReturnsView()
        {
            var result = _econtroller.Login() as ViewResult;
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual("", result.ViewName);

        }


    }
}