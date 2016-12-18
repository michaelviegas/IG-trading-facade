using Alldigit.IG.TradingFacade.Contracts.Exceptions;
using Alldigit.IG.TradingFacade.Logic.Http;
using Alldigit.IG.TradingFacade.Logic.Http.Interfaces;
using Alldigit.IG.TradingFacade.Logic.Messages;
using System.Net.Http;
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
                var requestMessage = CreateRequest(action, url, content);

                return await SendRequestAndCheckStatus(clientWrapper, requestMessage);
            }
        }

        async Task<HttpResponseMessage> IHttpClientCallback.SendAndCheckStatus(IHttpClientWrapper clientWrapper, HttpMethod action, string url)
        {
            var requestMessage = CreateRequest(action, url);

            return await SendRequestAndCheckStatus(clientWrapper, requestMessage);
        }

        private static HttpRequestMessage CreateRequest(HttpMethod action, string url, ByteArrayContent content = null)
        {
            var request = new HttpRequestMessage(action, url);
            if (content != null) request.Content = content;
            return request;
        }

        private async Task<HttpResponseMessage> SendRequestAndCheckStatus(IHttpClientWrapper clientWrapper, HttpRequestMessage requestMessage)
        {
            var response = await clientWrapper.SendAsync(requestMessage);

            await CheckResponseStatus(response);

            return response;
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
