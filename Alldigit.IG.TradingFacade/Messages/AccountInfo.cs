using Alldigit.IG.TradingFacade.Messages.Interfaces;
using Newtonsoft.Json;

namespace Alldigit.IG.TradingFacade.Messages
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