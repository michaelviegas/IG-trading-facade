using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alldigit.IG.TradingFacade.Contracts.Enums
{
    /// <summary>
    /// Account type
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AccountType
    {
        /// <summary>
        /// CFD account
        /// </summary>
        [EnumMember(Value = "CFD")]
        CFD,

        /// <summary>
        /// Physical account
        /// </summary>
        [EnumMember(Value = "PHYSICAL")]
        Physical,

        /// <summary>
        /// Spread bet account
        /// </summary>
        [EnumMember(Value = "SPREADBET")]
        SpreadBet
    }
}
