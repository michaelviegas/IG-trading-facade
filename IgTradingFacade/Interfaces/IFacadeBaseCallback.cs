using IgTradingFacade.Http;
using System.Net.Http;
using System.Threading.Tasks;

namespace IgTradingFacade.Interfaces
{
    public interface IFacadeBaseCallback
    {
        Task<HttpResponseMessage> SendBodyAndCheckStatus<TRequest>(HttpClientWrapper clientWrapper, HttpMethod action, TRequest request, string url);
    }
}
