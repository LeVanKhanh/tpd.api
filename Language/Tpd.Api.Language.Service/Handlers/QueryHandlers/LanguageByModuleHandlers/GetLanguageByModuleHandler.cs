using System.Linq;
using Tpd.Api.Core.DataAccess;
using Tpd.Api.Language.DataAccess.UnitOfWork;
using Tpd.Api.Language.DataTransferObject;
using Tpd.Api.Language.Service.Requests.Queries;
using Tpd.Api.Language.Service.Requests.Queries.LanguageByModule;

namespace Tpd.Api.Language.Service.Handlers.QueryHandlers.LanguageByModuleHandlers
{
    public class GetLanguageByModuleHandler : QueryListHandler<GetLanguageByModuleQuery, DtoLanguageByModule>
    {
        public GetLanguageByModuleHandler(IUnitOfWork unitOfWork)
           : base(unitOfWork)
        {

        }

        protected override IQueryable<DtoLanguageByModule> BuildQuery(GetLanguageByModuleQuery query, RequestContext context)
        {
            var languageId = UnitOfWork.Language.GetQuery()
                .Where(w => w.Code == query.Language).Select(s => s.Id).FirstOrDefault();

            var moduleId = UnitOfWork.Module.GetQuery()
                .Where(w => w.Application.ShortName == query.Application
                && w.Name == query.Module).Select(s => s.Id).FirstOrDefault();

            var moduleMapLanguage = UnitOfWork.ModuleMapLanguage.GetQuery()
                .Where(w => w.ModuleId == moduleId);

            var translation = UnitOfWork.Translation.GetQuery()
                .Where(w => w.LanguageId == languageId);

            var dataQuery = from map in moduleMapLanguage
                            join tran in translation
                            on map.Baseline.Id equals tran.Baseline.Id into tmpBaseline
                            from trans in tmpBaseline.DefaultIfEmpty()
                            select new DtoLanguageByModule
                            {
                                Code = map.Baseline.Code,
                                Display = trans == null? map.Baseline.Display: trans.Display
                            };

            return dataQuery;
        }
    }
}
