using Alldigit.IG.TradingFacade.Contracts.Enums;
using Alldigit.IG.TradingFacade.Contracts.Messages;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alldigit.IG.TradingFacade.Logic.Messages
{
    public class FormDetails : IFormDetails
    {
        [JsonProperty("formDismissible")]
        public bool FormDismissible { get; set; }

        [JsonProperty("formTitle")]
        public string FormTitle { get; set; }

        [JsonProperty("formType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FormType FormType { get; set; }

        [JsonProperty("formUrl")]
        public string FormUrl { get; set; }
    }
}