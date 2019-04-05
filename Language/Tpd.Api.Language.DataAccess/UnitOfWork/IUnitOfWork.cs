using Tpd.Api.Core.DataAccess;
using Tpd.Api.Language.DataAccess.Repositories;

namespace Tpd.Api.Language.DataAccess.UnitOfWork
{
    public interface IUnitOfWork: IUnitOfWorkBase
    {
        RpstApplication Application { get; }
        RpstLanguage Language { get; }
        RpstLanguageBaseLine LanguageBaseLine { get; }
        RpstModule Module { get; }
        RpstModuleMapLanguage ModuleMapLanguage { get; }
        RpstTranslation Translation { get; }
    }
}
