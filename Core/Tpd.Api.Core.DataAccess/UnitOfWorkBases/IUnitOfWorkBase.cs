using System;
using System.Threading.Tasks;
using Tpd.Api.Core.DataTransferObject;

namespace Tpd.Api.Core.DataAccess
{
    //
    // Summary:
    //     A abstract class provide fuctions/DbSets to work with database
    public interface IUnitOfWorkBase : IDisposable
    {
        //
        // Summary:
        //     A function can be used to get a repository of an entity
        // Parameters:
        //     TEntity:
        //          Type of an entity
        IRpstBase<TEntity> Repository<TEntity>() where TEntity : DtoBase;
        
        int Commit();
        
        Task<int> CommitAsync();
    }
}
