using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Alldigit.IG.TradingFacade.Helpers
{
    public class HttpResponseMessageReader
    {
        private readonly HttpResponseMessage _message;

        public HttpResponseMessageReader(HttpResponseMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            _message = message;
        }

        public Task<TResponse> ReadContent<TResponse>()
        {
            return _message.Content != null
                ? _message.Content.ReadAsAsync<TResponse>()
                : Task.FromResult(default(TResponse));
        }

        public string ReadHeaderValue(string headerName)
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
    }
}
