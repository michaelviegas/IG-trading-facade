using Alldigit.IG.TradingFacade.Contracts.Exceptions;
using Alldigit.IG.TradingFacade.Http;
using Alldigit.IG.TradingFacade.Http.Interfaces;
using Alldigit.IG.TradingFacade.Logic.Http;
using Alldigit.IG.TradingFacade.Logic.Interfaces;
using Alldigit.IG.TradingFacade.Logic.Messages;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Alldigit.IG.TradingFacade.Logic
{
    public abstract class RestClientBase : IHttpClientCallback
    {
        private readonly HttpMessageHandler _messageHandler;
        private readonly string _endpoint;

        public RestClientBase(string endpoint, HttpMessageHandler messageHandler)
        {
            _messageHandler = messageHandler;
            _endpoint = endpoint;
        }

        async Task<HttpResponseMessage> IHttpClientCallback.SendBodyAndCheckStatus<TRequest>(IHttpClientWrapper clientWrapper, HttpMethod action, TRequest request, string url)
        {
            using (var content = HttpContentConverter.ToJsonStringContent(request))
            {
                return await SendAsyncBodyAndCheckStatus(clientWrapper, action, url, content);
            }
        }

        private async Task<HttpResponseMessage> SendAsyncBodyAndCheckStatus(IHttpClientWrapper clientWrapper, HttpMethod action, string url, ByteArrayContent content)
        {
            var request = CreateRequest(action, url, content);

            var response = await clientWrapper.SendAsync(request);

            await CheckResponseStatus(response);

            return response;
        }

        private static HttpRequestMessage CreateRequest(HttpMethod action, string url, ByteArrayContent content)
        {
            return new HttpRequestMessage(action, url)
            {
                Content = content
            };
        }

        private async Task CheckResponseStatus(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                await ExtractException(response);
            }
        }

        private async Task ExtractException(HttpResponseMessage response)
        {
            var reader = HttpResponseMessageReader.Create(response);
            var error = await reader.ReadContent<Error>();

            if (error != null)
            {
                throw new ApiAccessFailedException(error.ErrorCode, response.ReasonPhrase);
            }
            else
            {
                throw new UnknownApiAccessFailedException(response.ReasonPhrase);
            }
        }

        protected virtual IHttpClientAction WithAnonymousClient()
        {
            return HttpClientAction.With(AnonymousHttpClient(_messageHandler, _endpoint), this);
        }

        private static HttpClientWrapper AnonymousHttpClient(HttpMessageHandler messageHandler, string endpoint)
        {
            return HttpClientWrapper.ForAnonymous(messageHandler, endpoint);
        }
    }
}
