using AutoMapper;
using TruckRegister.Application.ViewModels;
using TruckRegister.Domain.Entities;

namespace TruckRegister.IoC.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Truck, TruckViewModel>().ReverseMap();
            CreateMap<Truck, TruckViewModelDetails>().ReverseMap();            
        }
    }
}