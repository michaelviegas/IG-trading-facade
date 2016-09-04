using Alldigit.IG.TradingFacade.Contracts.Messages;
using Alldigit.IG.TradingFacade.Http.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Alldigit.IG.TradingFacade.Http
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _httpClient;

        private static MediaTypeWithQualityHeaderValue JsonMediaTypeHeaderValue
        {
            get
            {
                return new MediaTypeWithQualityHeaderValue(Constants.JsonContentType);
            }
        }

        private HttpClientWrapper(HttpMessageHandler messageHandler, string baseAddress, ISession session)
        {
            if (string.IsNullOrWhiteSpace(baseAddress))
                throw new ArgumentNullException("baseAddress");

            _httpClient = new HttpClient(messageHandler ?? new HttpClientHandler());

            SetBaseAddress(baseAddress);
            SetTokenRequestHeaders(session);
            SetJsonContentTypeRequestHeaders();
        }

        public static HttpClientWrapper ForAnonymous(HttpMessageHandler messageHandler, string baseAddress)
        {
            return new HttpClientWrapper(messageHandler, baseAddress, null);
        }

        private void SetBaseAddress(string baseAddress)
        {
            _httpClient.BaseAddress = new Uri(baseAddress);
        }

        private void SetTokenRequestHeaders(ISession session)
        {
            if (session == null)
                return;

            _httpClient.DefaultRequestHeaders.Add(Constants.ActiveAccountSessionTokenHeaderName, session.ActiveAccountToken);
            _httpClient.DefaultRequestHeaders.Add(Constants.ClientSessionTokenHeaderName, session.ClientToken);
        }

        private void SetJsonContentTypeRequestHeaders()
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(JsonMediaTypeHeaderValue);
        }

        public void SetApiKeyRequestHeader(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentNullException("apiKey");

            _httpClient.DefaultRequestHeaders.Add(Constants.IgApiKeyHeaderName, apiKey);
        }

        public void SetVersionRequestHeader(int version)
        {
            _httpClient.DefaultRequestHeaders.Add(Constants.VersionHeaderName, version.ToString());
        }

        Task<HttpResponseMessage> IHttpClientWrapper.SendAsync(HttpRequestMessage request)
        {
            return _httpClient.SendAsync(request);
        }

        void IDisposable.Dispose()
        {
            if (_httpClient != null) _httpClient.Dispose();
        }
    }
}
