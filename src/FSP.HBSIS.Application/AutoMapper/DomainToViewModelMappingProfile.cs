using AutoMapper;
using FSP.HBSIS.Application.ViewModels;
using FSP.HBSIS.Domain.Entities;

namespace FSP.HBSIS.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Cliente, ClienteViewModel>();
        }
    }
}