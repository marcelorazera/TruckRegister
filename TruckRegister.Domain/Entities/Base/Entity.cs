using System;

namespace TruckRegister.Domain.Entities.Base
{
    public class Entity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime? Changed { get; set; }
        public bool Active { get; private set; } = true;
        
        public void SetEnabled()
        {
            Active = true;
        }

        public void SetDisabled()
        {
            Active = false;
        }

        public void SetDateTimeUpdated()
        {
            Changed = DateTime.Now;
        }
    }
}