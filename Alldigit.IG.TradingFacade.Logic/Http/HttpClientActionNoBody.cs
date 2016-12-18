using Alldigit.IG.TradingFacade.Logic.Http.Interfaces;
using System.Net.Http;

namespace Alldigit.IG.TradingFacade.Logic.Http
{
    public class HttpClientActionNoBody : IHttpClientActionNoBody
    {
        private readonly IHttpClientWrapper _clientWrapper;
        private readonly IHttpClientCallback _owner;
        private readonly HttpMethod _action;

        public HttpClientActionNoBody(IHttpClientWrapper clientWrapper, IHttpClientCallback owner, HttpMethod action)
        {
            _clientWrapper = clientWrapper;
            _owner = owner;
            _action = action;
        }

        IHttpClientActionNoBodyWithResponse IHttpClientActionNoBody.To(string url)
        {
            return new HttpClientActionNoBodyWithResponse(_clientWrapper, _owner, _action, url);
        }
    }
}
