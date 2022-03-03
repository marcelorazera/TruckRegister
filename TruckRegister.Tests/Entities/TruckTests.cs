using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TruckRegister.Domain.Entities;
using TruckRegister.Domain.Enums;
using TruckRegister.Domain.Helper;

namespace TruckRegister.Tests.Entities
{
    [TestClass]
    public class TruckTests
    {
        private int _currentYear = int.Parse(DateTime.Now.ToString("yyyy"));

        [TestMethod]
        [TestCategory("Domain")]
        public void When_create_new_truck_with_fabrication_year_greater_then_current_year_than_return_is_invalid()
        {
            var truck = new Truck(TruckModel.FH.ToDescription(), _currentYear + 1, _currentYear);
            Assert.AreEqual(truck.IsValid(), false);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void When_create_new_truck_with_fabrication_year_lower_then_current_year_than_return_is_invalid()
        {
            var truck = new Truck(TruckModel.FH.ToDescription(), _currentYear - 1, _currentYear);
            Assert.AreEqual(truck.IsValid(), false);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void When_create_new_truck_with_fabrication_year_equals_current_year_than_return_is_valid()
        {
            var truck = new Truck(TruckModel.FH.ToDescription(), _currentYear, _currentYear);
            Assert.AreEqual(truck.IsValid(), true);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void When_create_new_truck_with_model_year_equals_current_year_than_return_is_valid()
        {
            var truck = new Truck(TruckModel.FH.ToDescription(), _currentYear, _currentYear);
            Assert.AreEqual(truck.IsValid(), true);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void When_create_new_truck_with_model_year_subsequent_current_year_than_return_is_valid()
        {
            var truck = new Truck(TruckModel.FH.ToDescription(), _currentYear, _currentYear + 1);
            Assert.AreEqual(truck.IsValid(), true);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void When_create_new_truck_with_model_year_lower_current_year_than_return_is_invalid()
        {
            var truck = new Truck(TruckModel.FH.ToDescription(), _currentYear, _currentYear - 1);
            Assert.AreEqual(truck.IsValid(), false);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void When_create_new_truck_with_model_year_grater_then_subsequent_year_than_return_is_invalid()
        {
            var truck = new Truck(TruckModel.FH.ToDescription(), _currentYear, _currentYear + 2);
            Assert.AreEqual(truck.IsValid(), false);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void When_create_new_truck_with_model_equals_FH_return_is_valid()
        {
            var truck = new Truck(TruckModel.FH.ToDescription(), _currentYear, _currentYear);
            Assert.AreEqual(truck.IsValid(), true);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void When_create_new_truck_with_model_equals_FM_return_is_valid()
        {
            var truck = new Truck(TruckModel.FH.ToDescription(), _currentYear, _currentYear);
            Assert.AreEqual(truck.IsValid(), true);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void When_create_new_truck_with_model_diferent_FM_or_FH_return_is_invalid()
        {
            var truck = new Truck(TruckModel.FH.ToDescription(), _currentYear, _currentYear);
            Assert.AreEqual(truck.IsValid(), false);
        }
    }
}