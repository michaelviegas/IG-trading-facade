using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Alldigit.IG.TradingFacade.Http
{
    public static class ModelExtensions
    {
        public static StringContent ToJsonStringContent<T>(this T model)
        {
            return new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, Constants.JsonContentType);
        }
    }
}
