using AutoMapper;
using NC.Core.Domain;
using NC.Core.Shared.ModelViews;

namespace NC.Manager.Mappings;

public class UpdateClientMappingProfile : Profile
{
    public UpdateClientMappingProfile()
    {
        CreateMap<UpdateClient, Client>()
            .ForMember(d => d.LastUpdate, o => o.MapFrom(x => DateTime.Now))
            .ForMember(d => d.BirthDate, o => o.MapFrom(x => x.BirthDate.Date));
    }
}
