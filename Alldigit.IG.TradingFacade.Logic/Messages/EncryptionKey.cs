using Alldigit.IG.TradingFacade.Contracts.Messages;
using Newtonsoft.Json;

namespace Alldigit.IG.TradingFacade.Logic.Messages
{
    public class EncryptionKeyMessage : IEncryptionKey
    {
        [JsonProperty("encryptionKey")]
        public string EncryptionKey { get; set; }

        [JsonProperty("timeStamp")]
        public long TimeStamp { get; set; }
    }
}
