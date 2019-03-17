namespace Tpd.Api.Core.Interface
{
    public class RequestModelBase<T>
    {
        public RequestContext RequestContext { get; set; }
        public T Model { get; set; }
    }
}
