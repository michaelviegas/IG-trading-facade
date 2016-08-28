using IgTradingFacade.Messages.Interfaces;
using System.Threading.Tasks;

namespace IgTradingFacade.Interfaces
{
    public interface ISessionFacade
    {
        Task<IAuthenticationResult> Login(string igApiKey, IUserCredentials userCredentials);
    }
}
