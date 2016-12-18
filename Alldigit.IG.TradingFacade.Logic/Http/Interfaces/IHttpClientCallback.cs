using System.Net.Http;
using System.Threading.Tasks;

namespace Alldigit.IG.TradingFacade.Logic.Http.Interfaces
{
    public interface IHttpClientCallback
    {
        Task<HttpResponseMessage> SendBodyAndCheckStatus<TRequest>(IHttpClientWrapper clientWrapper, HttpMethod action, TRequest request, string url);

        Task<HttpResponseMessage> SendAndCheckStatus(IHttpClientWrapper clientWrapper, HttpMethod action, string url);
    }
}
