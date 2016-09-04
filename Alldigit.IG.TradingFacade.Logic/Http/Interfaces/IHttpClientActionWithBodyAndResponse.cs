using System.Threading.Tasks;

namespace Alldigit.IG.TradingFacade.Http.Interfaces
{
    public interface IHttpClientActionWithBodyAndResponse
    {
        Task<TResponse> For<TResponse>();

        Task<IHttpResponseMessageReader> ForHttpResponseMessageReader();
    }
}