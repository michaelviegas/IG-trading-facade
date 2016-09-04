namespace Alldigit.IG.TradingFacade.Contracts.Messages
{
    public interface ISession
    {
        string ClientToken { get; }

        string ActiveAccountToken { get; }
    }
}
