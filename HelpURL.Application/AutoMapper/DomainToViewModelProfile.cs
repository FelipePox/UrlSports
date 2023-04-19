using AutoMapper;
using HelpURL.Application.ViewModel;
using HelpURL.Domain.Entities;

namespace HelpURL.Application.AutoMapper
{
    public sealed class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<URL, ResponseUrlViewModel>()
            .ForMember(dest => dest.URLTexto, act => act.MapFrom(src => src.URLTexto.Texto))
            .ForMember(dest => dest.Descricao, act => act.MapFrom(src => src.Descricao.Texto));
        }
    }
}
