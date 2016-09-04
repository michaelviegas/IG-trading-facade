using Alldigit.IG.TradingFacade.Contracts.Messages;
using Newtonsoft.Json;

namespace Alldigit.IG.TradingFacade.Logic.Messages
{
    public class AccountInfo : IAccountInfo
    {
        [JsonProperty("balance")]
        public double Balance { get; set; }

        [JsonProperty("deposit")]
        public double Deposit { get; set; }

        [JsonProperty("profitLoss")]
        public double ProfitLoss { get; set; }

        [JsonProperty("available")]
        public double Available { get; set; }
    }
}