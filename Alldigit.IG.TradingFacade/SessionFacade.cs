using Alldigit.IG.TradingFacade.Contracts;
using Alldigit.IG.TradingFacade.Contracts.Messages;
using Alldigit.IG.TradingFacade.Enums;
using Alldigit.IG.TradingFacade.Logic;
using System;
using System.Threading.Tasks;

namespace Alldigit.IG.TradingFacade
{
    public class SessionFacade : ISessionFacade
    {
        protected readonly SessionRestClient _restClient;

        public SessionFacade(IGEnvironment environment)
        {
            var endpoint = GetEnvironmentEndpoint(environment);

            _restClient = new SessionRestClient(endpoint, null);
        }

        public Task<IAuthenticationResult> Login(string apiKey, IUserCredentials userCredentials)
        {
            return _restClient.Login(apiKey, userCredentials);
        }

        private static string GetEnvironmentEndpoint(IGEnvironment environment)
        {
            switch (environment)
            {
                case Enums.IGEnvironment.Demo:
                    return Endpoints.Demo;

                case Enums.IGEnvironment.Live:
                    return Endpoints.Live;

                default:
                    throw new ArgumentException("Unknown IG environment", "environment");
            }

        }
    }
}
