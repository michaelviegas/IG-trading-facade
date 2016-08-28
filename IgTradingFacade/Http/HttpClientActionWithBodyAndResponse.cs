using IgTradingFacade.Http.Interfaces;
using IgTradingFacade.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace IgTradingFacade.Http
{
    public class HttpClientActionWithBodyAndResponse<TRequest> : IHttpClientActionWithBodyAndResponse
    {
        private readonly HttpClientWrapper _clientWrapper;
        private readonly IFacadeBaseCallback _owner;
        private readonly HttpMethod _action;
        private readonly TRequest _request;
        private readonly string _url;

        public HttpClientActionWithBodyAndResponse(HttpClientWrapper clientWrapper, IFacadeBaseCallback owner, HttpMethod action, TRequest request, string url)
        {
            _clientWrapper = clientWrapper;
            _owner = owner;
            _action = action;
            _url = url;
            _request = request;
        }

        async Task<HttpResponseMessage> IHttpClientActionWithBodyAndResponse.ForHttpResponse()
        {
            using (_clientWrapper)
            {
                return await _owner.SendBodyAndCheckStatus(_clientWrapper, _action, _request, _url);
            }
        }
    }
}
