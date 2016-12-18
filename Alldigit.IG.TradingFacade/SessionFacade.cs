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

        /// <summary>
        /// Creates a trading session, obtaining session tokens for subsequent API access.
        /// </summary>
        /// <param name="apiKey">API key identifies the application and authorises its use</param>
        /// <param name="userCredentials">Client login credentials</param>
        /// <returns>Trading session and summary of client account information</returns>
        public Task<IAuthenticationResult> Login(string apiKey, IUserCredentials userCredentials)
        {
            return _restClient.Login(apiKey, userCredentials);
        }

        /// <summary>
        /// Returns the encryption key to use in order to send the user password in an encrypted form
        /// </summary>
        /// <param name="apiKey">API key identifies the application and authorises its use</param>
        /// <returns>Encryption key</returns>
        public Task<IEncryptionKey> GetEncryptionKey(string apiKey)
        {
            return _restClient.GetEncryptionKey(apiKey);
        }

        private static string GetEnvironmentEndpoint(IGEnvironment environment)
        {
            switch (environment)
            {
                case IGEnvironment.Demo:
                    return Endpoints.Demo;

                case IGEnvironment.Live:
                    return Endpoints.Live;

                default:
                    throw new ArgumentException("Unknown IG environment", "environment");
            }

        }
    }
}
