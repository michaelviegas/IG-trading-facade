using IgTradingFacade;
using IgTradingFacade.Enums;
using IgTradingFacade.Messages;

namespace TestHarness
{
    public class Program
    {
        static void Main(string[] args)
        {
            var sessionFacade = new SessionFacade(IgEnvironment.Live);
            var apiKey = "d1f162c015d21d5c475308387d14111b6add6c4";
            var userCredentials = new UserCredentials
            {
                Username = "michaelviegas",
                Password = "Messines124"
            };

            var authResult = sessionFacade.Login(apiKey, userCredentials).Result;
        }
    }
}
