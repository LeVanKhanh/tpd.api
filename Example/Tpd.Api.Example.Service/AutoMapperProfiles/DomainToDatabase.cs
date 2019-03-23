using AutoMapper;
using Tpd.Api.Database.Entities;
using Tpd.Api.DataTransferObject;

namespace Tpd.Api.Example.Service.AutoMapperProfiles
{
    public class DomainToDatabase : Profile
    {
        public DomainToDatabase()
        {
            CreateMap<DtoMasterDataCategory, EttMasterDataCategory>()
                .ForMember(f => f.CreatedAt, m => m.Ignore())
                .ForMember(f => f.UpdatedAt, m => m.Ignore())
                .ForMember(f => f.IsDeleted, m => m.Ignore())
                .ForMember(f => f.Id, m => m.Ignore());
        }
    }
}
