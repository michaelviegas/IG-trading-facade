using IgTradingFacade.Messages.Interfaces;

namespace IgTradingFacade.Messages
{
    public class Session : ISession
    {
        public string ActiveAccountToken { get; set; }

        public string ClientToken { get; set; }
    }
}
