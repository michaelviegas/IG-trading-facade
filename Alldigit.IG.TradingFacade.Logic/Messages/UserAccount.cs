using Alldigit.IG.TradingFacade.Contracts.Enums;
using Alldigit.IG.TradingFacade.Contracts.Messages;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Alldigit.IG.TradingFacade.Logic.Messages
{
    public class UserAccount : IUserAccount
    {
        [JsonProperty("accountType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AccountType AccountType { get; set; }

        [JsonProperty("accountInfo")]
        public AccountInfo AccountInfo { get; set; }

        [JsonProperty("accounts")]
        public IEnumerable<Account> Accounts { get; set; }

        [JsonProperty("authenticationStatus")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AuthenticationStatus? AuthenticationStatus { get; set; }

        [JsonProperty("clientId")]
        public string ClientId { get; set; }

        [JsonProperty("currencyIsoCode")]
        public string CurrencyIsoCode { get; set; }

        [JsonProperty("currencySymbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty("currentAccountId")]
        public string CurrentAccountId { get; set; }      

        [JsonProperty("dealingEnabled")]
        public bool DealingEnabled { get; set; }

        [JsonProperty("encrypted")]
        public bool Encrypted { get; set; }

        [JsonProperty("formDetails")]
        public IEnumerable<FormDetails> FormDetails { get; set; }

        [JsonProperty("hasActiveDemoAccounts")]
        public bool HasActiveDemoAccounts { get; set; }

        [JsonProperty("hasActiveLiveAccounts")]
        public bool HasActiveLiveAccounts { get; set; }

        [JsonProperty("igCompany")]
        public string IGCompany { get; set; }

        [JsonProperty("lightstreamerEndpoint")]
        public string LightstreamerEndpoint { get; set; }

        [JsonProperty("reroutingEnvironment")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ReroutingEnvironment? ReroutingEnvironment { get; set; }

        [JsonProperty("timezoneOffset")]
        public float TimezoneOffset { get; set; }

        [JsonProperty("trailingStopsEnabled")]
        public bool TrailingStopsEnabled { get; set; }

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

        IEnumerable<IFormDetails> IUserAccount.FormDetails
        {
            get
            {
                return FormDetails;
            }
        }
    }
}
