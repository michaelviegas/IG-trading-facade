using IgTradingFacade.Messages.Interfaces;
using Newtonsoft.Json;
using System;

namespace IgTradingFacade.Messages
{
    public class UserCredentials : IUserCredentials, IMessage<IUserCredentials, UserCredentials>
    {
        [JsonProperty("identifier")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("encryptedPassword")]
        public bool EncryptedPassword { get; set; }

        UserCredentials IMessage<IUserCredentials, UserCredentials>.CopyFrom(IUserCredentials source)
        {
            if (source == null) throw new ArgumentNullException("source");

            Username = source.Username;
            Password = source.Password;
            EncryptedPassword = source.EncryptedPassword;

            return this;
        }
    }
}
