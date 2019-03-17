using Tpd.Api.Core.DataAccess;
using Tpd.Api.Database.Context;
using Tpd.Api.Example.DataAccess.Repositories;

namespace Tpd.Api.Example.DataAccess.UnitOfWork
{
    public class UnitOfWork : UnitOfWorkBase, IUnitOfWork
    {
        protected new DatabaseContext DataContext { get; set; }

        public UnitOfWork(DatabaseContext databaseContext)
            : base(databaseContext)
        {
            DataContext = databaseContext;
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
    }
}
