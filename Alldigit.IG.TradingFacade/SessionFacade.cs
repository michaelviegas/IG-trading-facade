using Alldigit.IG.TradingFacade.Enums;
using Alldigit.IG.TradingFacade.Helpers;
using Alldigit.IG.TradingFacade.Interfaces;
using Alldigit.IG.TradingFacade.Messages;
using Alldigit.IG.TradingFacade.Messages.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace Alldigit.IG.TradingFacade
{
    public class SessionFacade : FacadeBase, ISessionFacade
    {
        public SessionFacade(IgEnvironment environment)
            : base(environment)
        {}

        public async Task<IAuthenticationResult> Login(string igApiKey, IUserCredentials userCredentials)
        {
            var request = MessageAssembler.ToMessage<IUserCredentials, UserCredentials>(userCredentials);
            var response = await WithAnonymousClient()
                .ForApplication(igApiKey)
                .OnVersion(2)
                .Post(request)
                .To("gateway/deal/session")
                .ForHttpResponse();

            return await BuildAuthenticationResult(response);
        }

        private async Task<IAuthenticationResult> BuildAuthenticationResult(HttpResponseMessage message)
        {
            var reader = new HttpResponseMessageReader(message);
            var session = new Session
            {
                ActiveAccountToken = reader.ReadHeaderValue(Constants.ActiveAccountSessionTokenHeaderName),
                ClientToken = reader.ReadHeaderValue(Constants.ClientSessionTokenHeaderName)
            };
            var userAccount = await reader.ReadContent<UserAccount>();

            return new AuthenticationResultAssembler(session, userAccount);
        }

    }
}
