using Alldigit.IG.TradingFacade.Http.Interfaces;
using Alldigit.IG.TradingFacade.Logic.Interfaces;
using System.Net.Http;

namespace Alldigit.IG.TradingFacade.Http
{
    public class HttpClientAction : IHttpClientAction
    {
        private readonly HttpClientWrapper _clientWrapper;
        private readonly IHttpClientCallback _owner;

        private HttpClientAction(HttpClientWrapper clientWrapper, IHttpClientCallback owner)
        {
            _clientWrapper = clientWrapper;
            _owner = owner;
        }

        public static IHttpClientAction With(HttpClientWrapper client, IHttpClientCallback owner)
        {
            return new HttpClientAction(client, owner);
        }

        IHttpClientAction IHttpClientAction.ForApplication(string apiKey)
        {
            _clientWrapper.SetApiKeyRequestHeader(apiKey);
            return this;
        }

        IHttpClientAction IHttpClientAction.OnVersion(int version)
        {
            _clientWrapper.SetVersionRequestHeader(version);
            return this;
        }

        IHttpClientActionWithBody IHttpClientAction.Post<TRequest>(TRequest request)
        {
            return new HttpClientActionWithBody<TRequest>(_clientWrapper, _owner, HttpMethod.Post, request);
        }
    }
}
