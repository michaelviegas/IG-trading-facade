using Alldigit.IG.TradingFacade.Contracts.Enums;
using Alldigit.IG.TradingFacade.Contracts.Messages;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alldigit.IG.TradingFacade.Logic.Messages
{
    public class Account : IAccount
    {
        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [JsonProperty("accountName")]
        public string AccountName { get; set; }

        [JsonProperty("preferred")]
        public bool Preferred { get; set; }

        [JsonProperty("accountType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AccountType AccountType { get; set; }
    }
}