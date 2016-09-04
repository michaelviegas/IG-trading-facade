using Alldigit.IG.TradingFacade.Contracts.Messages;

namespace Alldigit.IG.TradingFacade.Logic.Messages
{
    public class Session : ISession
    {
        public string ActiveAccountToken { get; set; }

        public string ClientToken { get; set; }
    }
}
