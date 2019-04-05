namespace Tpd.Api.Core.Interface.RequestModelBases
{
    public class RequestModelBase<T>: IRequestModelBase<T>
    {
        public RequestContext RequestContext { get; set; }
        public T Model { get; set; }
    }
}
