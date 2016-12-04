using Alldigit.IG.TradingFacade.Contracts.Messages;
using System.Threading.Tasks;

namespace Alldigit.IG.TradingFacade.Contracts
{
    public interface ISessionFacade
    {
        /// <summary>
        /// Creates a trading session, obtaining session tokens for subsequent API access.
        /// </summary>
        /// <param name="apiKey">API key identifies the application and authorises its use</param>
        /// <param name="userCredentials">Client login credentials</param>
        /// <returns>Trading session and summary of client account information</returns>
        Task<IAuthenticationResult> Login(string apiKey, IUserCredentials userCredentials);
    }
}
