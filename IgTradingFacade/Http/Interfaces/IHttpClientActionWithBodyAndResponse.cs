using System.Net.Http;
using System.Threading.Tasks;

namespace IgTradingFacade.Http.Interfaces
{
    public interface IHttpClientActionWithBodyAndResponse
    {
        Task<HttpResponseMessage> ForHttpResponse();
    }
}