using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TruckRegister.Application.ViewModels;

namespace TruckRegister.Application.Interfaces
{
    public interface ITruckBll
    {
        Task<List<TruckViewModel>> GetAllTrucksEnablesAsync(CancellationToken cancelationToken = default);
        Task<TruckViewModelDetails> GetDetailsTruckEnableByIdAsync(Guid? id, CancellationToken cancelationToken = default);
        Task<TruckViewModel> GetTruckEnableByIdAsync(Guid? id, CancellationToken cancelationToken = default);
        Task CreateTruckAsync(TruckViewModel truckModel, CancellationToken cancelationToken = default);
        Task UpdateTruckAsync(Guid? id, TruckViewModel truckModel, CancellationToken cancelationToken = default);
        Task DeleteTruckAsync(Guid? id, CancellationToken cancelationToken = default);
    }
}