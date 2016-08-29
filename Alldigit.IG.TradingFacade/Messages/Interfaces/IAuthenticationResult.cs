namespace Alldigit.IG.TradingFacade.Messages.Interfaces
{
    public interface IAuthenticationResult
    {
        ISession Session { get; }

        IUserAccount UserAccount { get; }
    }
}
