using Tpd.Api.Core.DataAccess;
using Tpd.Api.Language.DataAccess.Repositories;
using Tpd.Api.Language.Database.Context;

namespace Tpd.Api.Language.DataAccess.UnitOfWork
{
    public class UnitOfWork : UnitOfWorkBase, IUnitOfWork
    {
        protected new DatabaseContext DataContext { get; set; }

        public UnitOfWork(DatabaseContext databaseContext)
            : base(databaseContext)
        {
            DataContext = databaseContext;
        }

        private RpstApplication _rpstApplication;
        public RpstApplication Application
        {
            get
            {
                if (_rpstApplication == null)
                {
                    _rpstApplication = new RpstApplication(DataContext);
                }
                return _rpstApplication;
            }
        }

        private RpstLanguage _rpstLanguage;
        public RpstLanguage Language
        {
            get
            {
                if (_rpstLanguage == null)
                {
                    _rpstLanguage = new RpstLanguage(DataContext);
                }
                return _rpstLanguage;
            }
        }

        private RpstLanguageBaseLine _rpstLanguageBaseLine;
        public RpstLanguageBaseLine LanguageBaseLine
        {
            get
            {
                if (_rpstLanguageBaseLine == null)
                {
                    _rpstLanguageBaseLine = new RpstLanguageBaseLine(DataContext);
                }
                return _rpstLanguageBaseLine;
            }
        }

        private RpstModule _rpstModule;
        public RpstModule Module
        {
            get
            {
                if (_rpstModule == null)
                {
                    _rpstModule = new RpstModule(DataContext);
                }
                return _rpstModule;
            }
        }

        private RpstModuleMapLanguage _rpstModuleMapLanguage;
        public RpstModuleMapLanguage ModuleMapLanguage
        {
            get
            {
                if (_rpstModuleMapLanguage == null)
                {
                    _rpstModuleMapLanguage = new RpstModuleMapLanguage(DataContext);
                }
                return _rpstModuleMapLanguage;
            }
        }

        private RpstTranslation _rpstTranslation;
        public RpstTranslation Translation
        {
            get
            {
                if (_rpstTranslation == null)
                {
                    _rpstTranslation = new RpstTranslation(DataContext);
                }
                return _rpstTranslation;
            }
        }
    }
}
