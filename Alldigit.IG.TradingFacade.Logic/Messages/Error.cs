using Newtonsoft.Json;

namespace Alldigit.IG.TradingFacade.Logic.Messages
{
    public class Error
    {
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }
    }
}
