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
            return _message.Content != null
                ? _message.Content.ReadAsAsync<TResponse>()
                : Task.FromResult(default(TResponse));
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
