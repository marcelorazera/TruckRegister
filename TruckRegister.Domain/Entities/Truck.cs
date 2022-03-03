using System;
using TruckRegister.Domain.Entities.Base;
using TruckRegister.Domain.Enums;

namespace TruckRegister.Domain.Entities
{
    public class Truck : Entity
    {
        public Truck()
        {
        }

        public Truck(string model, int fabricationYear, int modelYear)
        {
            Model = model;
            FabricationYear = fabricationYear;
            ModelYear = modelYear;
        }

        public string Model { get; private set; }        
        public int FabricationYear { get; private set; }
        public int ModelYear { get; private set; }       

        public bool IsValid()
        {
            var currentYear = int.Parse(DateTime.Now.ToString("yyyy"));

            if (FabricationYear != currentYear
                || ModelYear < currentYear
                || ModelYear > currentYear + 1)
                return false;
            else
                return true;
        }
    }
}