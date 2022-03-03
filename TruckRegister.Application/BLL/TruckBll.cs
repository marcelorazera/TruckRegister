using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using TruckRegister.Application.Interfaces;
using TruckRegister.Application.ViewModels;
using TruckRegister.Domain.Entities;
using TruckRegister.Domain.Interfaces.Repositories;

namespace TruckRegister.Application.BLL
{
    public class TruckBll : ITruckBll
    {
        private readonly ITruckRepository _truckRepository;
        private readonly IMapper _mapper;

        public TruckBll(ITruckRepository truckRepository
            , IMapper mapper)
        {
            _truckRepository = truckRepository;
            _mapper = mapper;
        }

        public async Task<List<TruckViewModel>> GetAllTrucksEnablesAsync(CancellationToken cancelationToken = default)
        {
            var trucks = await _truckRepository.GetAllTrucksEnablesAsync(cancelationToken);

            return _mapper.Map<List<TruckViewModel>>(trucks);
        }

        public async Task<TruckViewModelDetails> GetDetailsTruckEnableByIdAsync(Guid? id, CancellationToken cancelationToken = default)
        {
            var truck = await _truckRepository.GetDetailsTruckEnableByIdAsync(id, cancelationToken);

            return _mapper.Map<TruckViewModelDetails>(truck);
        }       

        public async Task CreateTruckAsync(TruckViewModel truckModel, CancellationToken cancelationToken = default)
        {
            var truck = _mapper.Map<Truck>(truckModel);

            if (truck.IsValid())
                await _truckRepository.CreateTruckAsync(truck, cancelationToken);
        }

        public async Task<TruckViewModel> GetTruckEnableByIdAsync(Guid? id, CancellationToken cancelationToken = default)
        {
            var truck = await _truckRepository.GetDetailsTruckEnableByIdAsync(id, cancelationToken);

            return _mapper.Map<TruckViewModel>(truck);
        }

        public async Task UpdateTruckAsync(Guid? id, TruckViewModel truckModel, CancellationToken cancelationToken = default)
        {
            var truck = await _truckRepository.GetDetailsTruckEnableByIdAsync(id, cancelationToken);

            var truckUpdated = _mapper.Map(truckModel, truck);

            truckUpdated.SetDateTimeUpdated();

            if (truck.IsValid())
                await _truckRepository.UpdateTruckAsync(truckUpdated, cancelationToken);
        }

        public async Task DeleteTruckAsync(Guid? id, CancellationToken cancelationToken = default)
        {
            var truck = await _truckRepository.GetDetailsTruckEnableByIdAsync(id, cancelationToken);

            truck.SetDisabled();

            await _truckRepository.UpdateTruckAsync(truck, cancelationToken);
        }
    }
}