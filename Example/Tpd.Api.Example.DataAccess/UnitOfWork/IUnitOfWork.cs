using Tpd.Api.Core.DataAccess;
using Tpd.Api.Example.DataAccess.Repositories;

namespace Tpd.Api.Example.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IUnitOfWorkBase
    {
        RpstMasterData MasterData { get; }

        RpstMasterDataCategory MasterDataCategory { get; }
    }
}
