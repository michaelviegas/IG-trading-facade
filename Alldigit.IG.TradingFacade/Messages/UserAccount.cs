using Alldigit.IG.TradingFacade.Messages.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Alldigit.IG.TradingFacade.Messages
{
    public class UserAccount : IUserAccount
    {
        [JsonProperty("accountType")]
        public string AccountType { get; set; }

        [JsonProperty("accountInfo")]
        public AccountInfo AccountInfo { get; set; }

        [JsonProperty("currencyIsoCode")]
        public string CurrencyIsoCode { get; set; }

        [JsonProperty("currentAccountId")]
        public string CurrentAccountId { get; set; }

        [JsonProperty("lightstreamerEndpoint")]
        public string LightstreamerEndpoint { get; set; }

        [JsonProperty("accounts")]
        public IEnumerable<Account> Accounts { get; set; }

        [JsonProperty("clientId")]
        public string ClientId { get; set; }

        IAccountInfo IUserAccount.AccountInfo
        {
            get
            {
                return AccountInfo;
            }
        }

        IEnumerable<IAccount> IUserAccount.Accounts
        {
            get
            {
                return Accounts;
            }
        }
    }
}
