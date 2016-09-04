using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Alldigit.IG.TradingFacade.Tests.Support
{
    public class HttpMessageHandlerMock<TRequestBody> : HttpMessageHandler
    {
        private readonly HttpResponseMessage _response;

        public HttpRequestMessage LastRequest { get; private set; }

        public TRequestBody LastRequestBody { get; private set; }

        public HttpMessageHandlerMock(HttpResponseMessage response)
        {
            _response = response;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            LastRequest = request;

            LastRequestBody = (request.Content != null)
                ? request.Content.ReadAsAsync<TRequestBody>().Result
                : default(TRequestBody);

            return Task.FromResult(_response);
        }

        public void ValidateJsonRequest(HttpMethod expectedMethod, string endpoint, string path, string apiKey, int? version)
        {
            ValidateRequest(Constants.JsonContentType, expectedMethod, endpoint, path, apiKey, version);
        }

        private void ValidateRequest(string contentType, HttpMethod expectedMethod, string endpoint, string path, string apiKey, int? version)
        {
            Assert.AreEqual(contentType, LastRequest.Headers.Accept.First().ToString());
            Assert.AreEqual(expectedMethod, LastRequest.Method);
            Assert.AreEqual(new Uri(new Uri(endpoint), path), LastRequest.RequestUri);

            ValidateRequestHeader(Constants.IgApiKeyHeaderName, apiKey);
            ValidateRequestHeader(Constants.VersionHeaderName, version.HasValue ? version.ToString() : null);
        }

        private void ValidateRequestHeader(string headerName, string expectedValue)
        {
            var headerValue = ReadHeaderValue(headerName);

            if (!string.IsNullOrEmpty(expectedValue))
            {
                Assert.IsNotNull(headerValue);
                Assert.AreEqual(expectedValue, headerValue);
            }
            else
            {
                Assert.IsNull(headerValue);
            }
        }

        private string ReadHeaderValue(string headerName)
        {
            IEnumerable<string> values;
            if (LastRequest.Headers.TryGetValues(headerName, out values))
            {
                return values.FirstOrDefault();
            }
            return null;
        }
    }
}
