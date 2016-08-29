using Alldigit.IG.TradingFacade.Http;
using System.Net.Http;
using System.Threading.Tasks;

namespace Alldigit.IG.TradingFacade.Interfaces
{
    public interface IFacadeBaseCallback
    {
        Task<HttpResponseMessage> SendBodyAndCheckStatus<TRequest>(HttpClientWrapper clientWrapper, HttpMethod action, TRequest request, string url);
    }
}
