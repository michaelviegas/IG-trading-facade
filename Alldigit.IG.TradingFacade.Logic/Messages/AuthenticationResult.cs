
using Alldigit.IG.TradingFacade.Contracts.Messages;

namespace Alldigit.IG.TradingFacade.Logic.Messages
{
    public class AuthenticationResult : IAuthenticationResult
    {
        public ISession Session { get; set; }

        public IUserAccount UserAccount { get; set; }
    }
}
