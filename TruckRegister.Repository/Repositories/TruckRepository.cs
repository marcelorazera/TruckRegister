using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TruckRegister.Domain.Entities;
using TruckRegister.Domain.Interfaces.Repositories;
using TruckRegister.Repository.Data;

namespace TruckRegister.Repository.Repositories
{
    public class TruckRepository : ITruckRepository
    {
        private readonly ApplicationContext _context;

        public TruckRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Truck>> GetAllTrucksEnablesAsync(CancellationToken cancelationToken = default)
        {
            return await _context.Trucks
                .Where(x => x.Active)
                .AsNoTracking()
                .ToListAsync(cancelationToken);
        }

        public async Task<Truck> GetDetailsTruckEnableByIdAsync(Guid? idTruck, CancellationToken cancelationToken = default)
        {
            return await _context.Trucks
                .Where(x => x.Active && x.Id == idTruck)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancelationToken);
        }

        public async Task CreateTruckAsync(Truck truck, CancellationToken cancelationToken = default)
        {
            _context.Add(truck);
            await _context.SaveChangesAsync(cancelationToken);
        }

        public async Task UpdateTruckAsync(Truck truck, CancellationToken cancelationToken = default)
        {
            _context.Update(truck);
            await _context.SaveChangesAsync(cancelationToken);
        }
    }
}