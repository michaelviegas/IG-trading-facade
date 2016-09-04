using Alldigit.IG.TradingFacade.Http.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace Alldigit.IG.TradingFacade.Logic.Interfaces
{
    public interface IHttpClientCallback
    {
        Task<HttpResponseMessage> SendBodyAndCheckStatus<TRequest>(IHttpClientWrapper clientWrapper, HttpMethod action, TRequest request, string url);
    }
}
