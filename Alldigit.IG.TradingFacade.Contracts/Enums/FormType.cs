using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alldigit.IG.TradingFacade.Contracts.Enums
{
    /// <summary>
    /// Types of Form
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FormType
    {
        /// <summary>
        /// Better customer agreement form type
        /// </summary>
        [EnumMember(Value = "BCA")]
        BetterCustomerAgreement,

        /// <summary>
        /// Know your client form type
        /// </summary>
        [EnumMember(Value = "KYC")]
        KnowYourClient
    }
}
