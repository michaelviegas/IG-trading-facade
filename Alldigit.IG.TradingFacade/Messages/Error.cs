using Newtonsoft.Json;

namespace Alldigit.IG.TradingFacade.Messages
{
    public class Error
    {
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }
    }
}
