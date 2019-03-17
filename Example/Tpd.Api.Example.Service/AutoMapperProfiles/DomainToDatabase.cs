using AutoMapper;
using Tpd.Api.Database.Entities;
using Tpd.Api.DataTransferObject;

namespace Tpd.Api.Example.Service.AutoMapperProfiles
{
    public class DomainToDatabase : Profile
    {
        public DomainToDatabase()
        {
            CreateMap<DtoMasterDataCategory, EttMasterDataCategory>();
        }
    }
}
