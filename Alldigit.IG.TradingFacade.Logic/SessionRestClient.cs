using Alldigit.IG.TradingFacade.Contracts.Messages;
using Alldigit.IG.TradingFacade.Logic.Helpers;
using Alldigit.IG.TradingFacade.Logic.Http.Interfaces;
using Alldigit.IG.TradingFacade.Logic.Messages;
using System.Net.Http;
using System.Threading.Tasks;

namespace Alldigit.IG.TradingFacade.Logic
{
    public class SessionRestClient : RestClientBase
    {
        public SessionRestClient(string endpoint, HttpMessageHandler messageHandler)
            : base(endpoint, messageHandler)
        {
        }

        public async Task<IAuthenticationResult> Login(string apiKey, IUserCredentials userCredentials)
        {
            var request = MessageAssembler.ToMessage<IUserCredentials, UserCredentials>(userCredentials);
            var response = await WithAnonymousClient()
                .ForApplication(apiKey)
                .OnVersion(2)
                .Post(request)
                .To("gateway/deal/session")
                .ForHttpResponseMessageReader();

            return await BuildAuthenticationResult(response);
        }

        public async Task<IEncryptionKey> GetEncryptionKey(string apiKey)
        {
            return await WithAnonymousClient()
                .ForApplication(apiKey)
                .Get()
                .To("gateway/deal/session/encryptionKey")
                .For<EncryptionKeyMessage>();
        }

        private async Task<IAuthenticationResult> BuildAuthenticationResult(IHttpResponseMessageReader reader)
        {
            var session = new Session
            {
                ActiveAccountToken = reader.ReadHeaderValue(Constants.ActiveAccountSessionTokenHeaderName),
                ClientToken = reader.ReadHeaderValue(Constants.ClientSessionTokenHeaderName)
            };
            var userAccount = await reader.ReadContent<UserAccount>();

            return new AuthenticationResult
            {
                Session = session,
                UserAccount = userAccount
            };
        }
    }
}
