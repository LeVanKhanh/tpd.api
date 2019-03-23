namespace Tpd.Api.Core.Service.RequestBases.QueryBases
{
    public interface IQueryListBase:IQueryBase
    {
        bool IsPaged { get; set; }
        string OrderBy { get; set; }
        string OrderByDirection { get; set; }
        string ThenOrderBy { get; set; }
        string ThenOrderByDirection { get; set; }
        int Skip { get; set; }
        int Take { get; set; }
    }
}
