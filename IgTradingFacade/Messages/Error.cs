using Newtonsoft.Json;

namespace IgTradingFacade.Messages
{
    public class Error
    {
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }
    }
}
