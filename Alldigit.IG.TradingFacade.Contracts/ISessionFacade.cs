using Alldigit.IG.TradingFacade.Contracts.Messages;
using System.Threading.Tasks;

namespace Alldigit.IG.TradingFacade.Contracts
{
    public interface ISessionFacade
    {
        Task<IAuthenticationResult> Login(string apiKey, IUserCredentials userCredentials);
    }
}
