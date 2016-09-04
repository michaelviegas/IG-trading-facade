using Alldigit.IG.TradingFacade.Contracts.Messages;

namespace Alldigit.IG.TradingFacade.Tests.Support.Stubs
{
    public class UserCredentialsStub : IUserCredentials
    {
        public bool EncryptedPassword
        {
            get
            {
                return true;
            }
        }

        public string Password
        {
            get
            {
                return "dummy_password";
            }
        }

        public string Username
        {
            get
            {
                return "dummy_username";
            }
        }
    }
}
