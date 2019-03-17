using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.Database;
using Tpd.Api.Core.DataTransferObject;
using Tpd.Api.Example.DataAccess.Repositories;
using Tpd.Api.Database.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Tpd.Api.Example.DataAccess.UnitOfWork
{
    public class UnitOfWork : UnitOfWorkBase, IUnitOfWork
    {
        public UnitOfWork()
        {
            //TODO: Inject DBContext
            DataContext = new DatabaseContext();
        }

        private RpstMasterData _rpstMasterData;
        public RpstMasterData MasterData
        {
            get
            {
                if (_rpstMasterData == null)
                {
                    _rpstMasterData = new RpstMasterData(DataContext);
                }
                return _rpstMasterData;
            }
        }

        private RpstMasterDataCategory _rpstMasterDataCategory;
        public RpstMasterDataCategory MasterDataCategory
        {
            get
            {
                if (_rpstMasterDataCategory == null)
                {
                    _rpstMasterDataCategory = new RpstMasterDataCategory(DataContext);
                }
                return _rpstMasterDataCategory;
            }
        }

        private RpstBleSignal _bleSignal;
        public RpstBleSignal BleSignal
        {
            get
            {
                if (_bleSignal == null)
                {
                    _bleSignal = new RpstBleSignal(DataContext);
                }
                return _bleSignal;
            }
        }


        public override IRpstBase<TEntity> Repository<TEntity>()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IRpstBase<TEntity>>(intance => new RpstBase<TEntity, DatabaseContextBase>(DataContext))
                .BuildServiceProvider();

            var repository = serviceProvider.GetService<IRpstBase<TEntity>>();
            return repository;
        }
    }
}
