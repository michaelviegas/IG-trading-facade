using IgTradingFacade.Messages.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace IgTradingFacade.Http
{
    public class HttpClientWrapper : IDisposable
    {
        private readonly HttpClient _httpClient;

        private static MediaTypeWithQualityHeaderValue JsonMediaTypeHeaderValue
        {
            get
            {
                return new MediaTypeWithQualityHeaderValue(Constants.JsonContentType)
                {
                    CharSet = Encoding.UTF8.WebName
                };
            }
        }

        public HttpClient Client
        {
            get
            {
                return _httpClient;
            }
        }

        public HttpClientWrapper(string baseAddress, ISession session)
        {
            if (string.IsNullOrWhiteSpace(baseAddress))
                throw new ArgumentNullException("baseAddress");

            _httpClient = new HttpClient();

            SetBaseAddress(baseAddress);
            SetTokenRequestHeaders(session);
            SetJsonContentTypeRequestHeaders();
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

        public void Dispose()
        {
            if (_httpClient != null) _httpClient.Dispose();
        }
    }
}
