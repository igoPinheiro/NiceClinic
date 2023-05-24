using AutoMapper;
using NC.Core.Domain;
using NC.Core.Shared.ModelViews;

namespace NC.Manager.Mappings;

public class NewClientMappingProfile : Profile
{
    public NewClientMappingProfile()
    {
        CreateMap<NewClient, Client>()
            .ForMember(d=> d.CreationDate, o=> o.MapFrom(origin=> DateTime.Now))
            .ForMember(d=> d.BirthDate, o=> o.MapFrom(origin => origin.BirthDate.Date));
    }
}
