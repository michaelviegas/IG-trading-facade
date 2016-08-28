using IgTradingFacade.Http.Interfaces;
using IgTradingFacade.Interfaces;
using System.Net.Http;

namespace IgTradingFacade.Http
{
    public class HttpClientAction : IHttpClientAction
    {
        private readonly HttpClientWrapper _clientWrapper;
        private readonly IFacadeBaseCallback _owner;

        public HttpClientAction(HttpClientWrapper clientWrapper, IFacadeBaseCallback owner)
        {
            _clientWrapper = clientWrapper;
            _owner = owner;
        }

        public static IHttpClientAction With(HttpClientWrapper client, IFacadeBaseCallback owner)
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
