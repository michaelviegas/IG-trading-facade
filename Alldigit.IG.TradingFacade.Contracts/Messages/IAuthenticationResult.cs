namespace Alldigit.IG.TradingFacade.Contracts.Messages
{
    public interface IAuthenticationResult
    {
        ISession Session { get; }

        IUserAccount UserAccount { get; }
    }
}
