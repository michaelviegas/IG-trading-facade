using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Alldigit.IG.TradingFacade.Logic.Http
{
    public static class HttpContentConverter
    {
        public static StringContent ToJsonStringContent<TRequest>(TRequest request)
        {
            return new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, Constants.JsonContentType);
        }
    }
}
