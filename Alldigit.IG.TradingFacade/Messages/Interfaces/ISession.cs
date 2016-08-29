namespace Alldigit.IG.TradingFacade.Messages.Interfaces
{
    public interface ISession
    {
        string ClientToken { get; }

        string ActiveAccountToken { get; }
    }
}
