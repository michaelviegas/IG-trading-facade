using Alldigit.IG.TradingFacade.Http.Interfaces;
using Alldigit.IG.TradingFacade.Interfaces;
using System.Net.Http;

namespace Alldigit.IG.TradingFacade.Http
{
    public class HttpClientActionWithBody<TRequest> : IHttpClientActionWithBody
    {
        private readonly HttpClientWrapper _clientWrapper;
        private readonly IFacadeBaseCallback _owner;
        private readonly HttpMethod _action;
        private readonly TRequest _request;

        public HttpClientActionWithBody(HttpClientWrapper clientWrapper, IFacadeBaseCallback owner, HttpMethod action, TRequest request)
        {
            _clientWrapper = clientWrapper;
            _owner = owner;
            _action = action;
            _request = request;
        }

        IHttpClientActionWithBodyAndResponse IHttpClientActionWithBody.To(string url)
        {
            return new HttpClientActionWithBodyAndResponse<TRequest>(_clientWrapper, _owner, _action, _request, url);
        }
    }
}
