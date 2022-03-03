using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TruckRegister.Domain.Entities;

namespace TruckRegister.Domain.Interfaces.Repositories
{
    public interface ITruckRepository
    {
        Task<List<Truck>> GetAllTrucksEnablesAsync(CancellationToken cancelationToken = default);
        Task<Truck> GetDetailsTruckEnableByIdAsync(Guid? idTruck, CancellationToken cancelationToken = default);
        Task CreateTruckAsync(Truck truck, CancellationToken cancelationToken = default);
        Task UpdateTruckAsync(Truck truck, CancellationToken cancelationToken = default);
    }
}