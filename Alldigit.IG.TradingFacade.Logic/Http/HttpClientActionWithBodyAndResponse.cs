using Alldigit.IG.TradingFacade.Http.Interfaces;
using Alldigit.IG.TradingFacade.Logic.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace Alldigit.IG.TradingFacade.Http
{
    public class HttpClientActionWithBodyAndResponse<TRequest> : IHttpClientActionWithBodyAndResponse
    {
        private readonly IHttpClientWrapper _clientWrapper;
        private readonly IHttpClientCallback _owner;
        private readonly HttpMethod _action;
        private readonly TRequest _request;
        private readonly string _url;

        public HttpClientActionWithBodyAndResponse(IHttpClientWrapper clientWrapper, IHttpClientCallback owner, HttpMethod action, TRequest request, string url)
        {
            _clientWrapper = clientWrapper;
            _owner = owner;
            _action = action;
            _url = url;
            _request = request;
        }

        async Task<TResponse> IHttpClientActionWithBodyAndResponse.For<TResponse>()
        {
            var reader = await ForHttpResponseMessageReader();
            return await reader.ReadContent<TResponse>();
        }

        public async Task<IHttpResponseMessageReader> ForHttpResponseMessageReader()
        {
            using (_clientWrapper)
            {
                var response = await _owner.SendBodyAndCheckStatus(_clientWrapper, _action, _request, _url);
                return HttpResponseMessageReader.Create(response);
            }
        }
    }
}
