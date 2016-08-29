using Alldigit.IG.TradingFacade.Messages.Interfaces;

namespace Alldigit.IG.TradingFacade.Messages
{
    public class Session : ISession
    {
        public string ActiveAccountToken { get; set; }

        public string ClientToken { get; set; }
    }
}
