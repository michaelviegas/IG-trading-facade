using IgTradingFacade.Messages.Interfaces;

namespace IgTradingFacade.Assemblers
{
    public class AuthenticationResultAssembler : IAuthenticationResult
    {
        private readonly ISession _session;
        private readonly IUserAccount _userAccount;

        public AuthenticationResultAssembler(ISession session, IUserAccount userAccount)
        {
            _session = session;
            _userAccount = userAccount;
        }

        public ISession Session
        {
            get
            {
                return _session;
            }
        }

        public IUserAccount UserAccount
        {
            get
            {
                return _userAccount;
            }
        }
    }
}
