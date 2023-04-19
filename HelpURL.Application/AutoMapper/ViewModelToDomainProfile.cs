using AutoMapper;
using HelpURL.Application.ViewModel;
using HelpURL.Domain.Entities;

namespace HelpURL.Application.AutoMapper;

public sealed class ViewModelToDomainProfile : Profile
{
    public ViewModelToDomainProfile()
    {
        CreateMap<RequestUrlViewModel, URL>();
    }
}
