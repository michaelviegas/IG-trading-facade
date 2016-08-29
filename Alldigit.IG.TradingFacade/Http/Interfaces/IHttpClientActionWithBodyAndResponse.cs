using System.Net.Http;
using System.Threading.Tasks;

namespace Alldigit.IG.TradingFacade.Http.Interfaces
{
    public interface IHttpClientActionWithBodyAndResponse
    {
        Task<HttpResponseMessage> ForHttpResponse();
    }
}