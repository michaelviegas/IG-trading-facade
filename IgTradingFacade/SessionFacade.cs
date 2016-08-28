using IgTradingFacade.Assemblers;
using IgTradingFacade.Enums;
using IgTradingFacade.Interfaces;
using IgTradingFacade.Messages;
using IgTradingFacade.Messages.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IgTradingFacade
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

            var session = ReadResponseSessionHeaders(response);
            var userAccount = await ReadResponseContent<UserAccount>(response);

            return new AuthenticationResultAssembler(session, userAccount);
        }

        private static ISession ReadResponseSessionHeaders(HttpResponseMessage response)
        {
            if (response.Headers == null)
                return null;

            return new Session
            {
                ActiveAccountToken = ReadResponseHeaderValue(response, Constants.ActiveAccountSessionTokenHeaderName),
                ClientToken = ReadResponseHeaderValue(response, Constants.ClientSessionTokenHeaderName)
            };
        }

        private static string ReadResponseHeaderValue(HttpResponseMessage response, string headerName)
        {
            IEnumerable<string> values;
            if (response.Headers.TryGetValues(headerName, out values))
            {
                return values.FirstOrDefault();
            }
            return null;
        }
    }
}
