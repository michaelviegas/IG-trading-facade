using Alldigit.IG.TradingFacade.Messages.Interfaces;
using System.Threading.Tasks;

namespace Alldigit.IG.TradingFacade.Interfaces
{
    public interface ISessionFacade
    {
        Task<IAuthenticationResult> Login(string igApiKey, IUserCredentials userCredentials);
    }
}
