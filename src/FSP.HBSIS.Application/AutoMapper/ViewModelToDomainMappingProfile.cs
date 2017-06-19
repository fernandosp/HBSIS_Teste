using AutoMapper;
using FSP.HBSIS.Application.ViewModels;
using FSP.HBSIS.Domain.Entities;

namespace FSP.HBSIS.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ClienteViewModel, Cliente>();
        }
    }
}