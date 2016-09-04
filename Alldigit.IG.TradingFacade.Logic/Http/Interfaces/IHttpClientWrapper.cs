using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Alldigit.IG.TradingFacade.Http.Interfaces
{
    public interface IHttpClientWrapper : IDisposable
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}
