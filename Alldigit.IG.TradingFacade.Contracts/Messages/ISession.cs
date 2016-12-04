namespace Alldigit.IG.TradingFacade.Contracts.Messages
{
    /// <summary>
    /// Session tokens for subsequent API access
    /// </summary>
    public interface ISession
    {
        /// <summary>
        /// Client session security access token
        /// </summary>
        string ClientToken { get; }

        /// <summary>
        /// Account session security access token
        /// </summary>
        string ActiveAccountToken { get; }
    }
}
