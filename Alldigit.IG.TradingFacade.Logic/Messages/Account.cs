using Alldigit.IG.TradingFacade.Contracts.Messages;
using Newtonsoft.Json;

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
        public string AccountType { get; set; }
    }
}