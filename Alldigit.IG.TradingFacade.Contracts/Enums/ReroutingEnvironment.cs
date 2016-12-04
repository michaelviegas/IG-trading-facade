using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alldigit.IG.TradingFacade.Contracts.Enums
{
    /// <summary>
    /// Describes the environment to be used as the rerouting destination
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReroutingEnvironment
    {
        [EnumMember(Value = "TEST")]
        Test,

        [EnumMember(Value = "UAT")]
        UAT,

        [EnumMember(Value = "DEMO")]
        Demo,

        [EnumMember(Value = "LIVE")]
        Live
    }
}
