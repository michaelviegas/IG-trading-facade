using Alldigit.IG.TradingFacade.Enums;
using Alldigit.IG.TradingFacade.Exceptions;
using Alldigit.IG.TradingFacade.Helpers;
using Alldigit.IG.TradingFacade.Http;
using Alldigit.IG.TradingFacade.Http.Interfaces;
using Alldigit.IG.TradingFacade.Interfaces;
using Alldigit.IG.TradingFacade.Messages;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Alldigit.IG.TradingFacade
{
    public abstract class FacadeBase : IFacadeBaseCallback
    {
        private readonly string _endpoint;

        protected FacadeBase(IgEnvironment environment)
        {
            switch (environment)
            {
                case IgEnvironment.Demo:
                    _endpoint = Constants.DemoEndpoint;
                    break;

                case IgEnvironment.Live:
                    _endpoint = Constants.LiveEndpoint;
                    break;

                default:
                    throw new ArgumentException("Unknown IG environment", "environment");
            }
        }

        async Task<HttpResponseMessage> IFacadeBaseCallback.SendBodyAndCheckStatus<TRequest>(HttpClientWrapper clientWrapper, HttpMethod action, TRequest request, string url)
        {
            // todo try catch - ExtractException
            using (var content = request.ToJsonStringContent())
            {
                return await SendAsyncBodyAndCheckStatus(clientWrapper, action, url, content);
            }

        }

        private async Task<HttpResponseMessage> SendAsyncBodyAndCheckStatus(HttpClientWrapper clientWrapper, HttpMethod action, string url, ByteArrayContent content)
        {
            var request = CreateRequest(action, url, content);

            var response = await clientWrapper.Client.SendAsync(request);

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
            var reader = new HttpResponseMessageReader(response);
            var error = await reader.ReadContent<Error>();

            if (error != null)
            {
                RaiseException(error);
            }
            else
            {
                RaiseException(response.ReasonPhrase);
            }
        }

        private void RaiseException(string reasonPhrase)
        {
            throw new GeneralApiAccessFailedException(reasonPhrase);
        }

        private void RaiseException(Error error)
        {
            // todo handle exceptions
            //switch (error.ErrorCode)
            //{

            //}

            RaiseException(error.ErrorCode);
        }

        protected IHttpClientAction WithAnonymousClient()
        {
            return HttpClientAction.With(AnonymousHttpClient(_endpoint), this);
        }

        protected static HttpClientWrapper AnonymousHttpClient(string endpoint)
        {
            return Http.HttpClientFactory.Create(endpoint);
        }
    }
}
