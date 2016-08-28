﻿using IgTradingFacade.Messages.Interfaces;
using Newtonsoft.Json;

namespace IgTradingFacade.Messages
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