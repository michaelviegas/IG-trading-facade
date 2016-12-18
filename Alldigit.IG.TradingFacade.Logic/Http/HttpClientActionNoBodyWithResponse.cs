using Alldigit.IG.TradingFacade.Logic.Http.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace Alldigit.IG.TradingFacade.Logic.Http
{
    public class HttpClientActionNoBodyWithResponse : IHttpClientActionNoBodyWithResponse
    {
        private readonly IHttpClientWrapper _clientWrapper;
        private readonly IHttpClientCallback _owner;
        private readonly HttpMethod _action;
        private readonly string _url;

        public HttpClientActionNoBodyWithResponse(IHttpClientWrapper clientWrapper, IHttpClientCallback owner, HttpMethod action, string url)
        {
            _clientWrapper = clientWrapper;
            _owner = owner;
            _action = action;
            _url = url;
        }

        async Task<TResponse> IHttpClientActionNoBodyWithResponse.For<TResponse>()
        {
            using (_clientWrapper)
            {
                var response = await _owner.SendAndCheckStatus(_clientWrapper, _action, _url);
                var reader = HttpResponseMessageReader.Create(response);
                return await reader.ReadContent<TResponse>();
            }
        }
    }
}
