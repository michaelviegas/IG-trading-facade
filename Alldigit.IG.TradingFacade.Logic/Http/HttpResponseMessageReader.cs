using Alldigit.IG.TradingFacade.Logic.Http.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Alldigit.IG.TradingFacade.Logic.Http
{
    public class HttpResponseMessageReader : IHttpResponseMessageReader
    {
        private readonly HttpResponseMessage _message;

        private HttpResponseMessageReader(HttpResponseMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            _message = message;
        }

        Task<TResponse> IHttpResponseMessageReader.ReadContent<TResponse>()
        {
            return ResponseContentIsValid()
                ? _message.Content.ReadAsAsync<TResponse>()
                : Task.FromResult(default(TResponse));
        }

        private bool ResponseContentIsValid()
        {
            if (_message.Content == null) return false;

            // All media types accepted?
            var accept = _message.RequestMessage.Headers.Accept;
            if (!accept.Any() || accept.Any(a => a.MediaType == Constants.AllMediaTypesRange)) return true;

            // Validate response content media type
            var contentType = _message.Content.Headers.ContentType;
            return contentType != null && accept.Any(a => a.MediaType == contentType.MediaType);
        }

        string IHttpResponseMessageReader.ReadHeaderValue(string headerName)
        {
            if (string.IsNullOrWhiteSpace(headerName))
                return null;

            IEnumerable<string> values;
            if (_message.Headers.TryGetValues(headerName, out values))
            {
                return values.FirstOrDefault();
            }
            return null;
        }

        public static IHttpResponseMessageReader Create(HttpResponseMessage message)
        {
            return new HttpResponseMessageReader(message);
        }
    }
}
