namespace IgTradingFacade.Messages.Interfaces
{
    public interface IAuthenticationResult
    {
        ISession Session { get; }

        IUserAccount UserAccount { get; }
    }
}
