namespace Alldigit.IG.TradingFacade.Contracts.Messages
{
    /// <summary>
    /// Successful client login
    /// </summary>
    public interface IAuthenticationResult
    {
        /// <summary>
        /// Session tokens for subsequent API access
        /// </summary>
        ISession Session { get; }

        /// <summary>
        /// Summary of client account information
        /// </summary>
        IUserAccount UserAccount { get; }
    }
}
