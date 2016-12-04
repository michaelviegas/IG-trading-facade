namespace Alldigit.IG.TradingFacade.Contracts.Messages
{
    /// <summary>
    /// Client login credentials
    /// </summary>
    public interface IUserCredentials
    {
        /// <summary>
        /// Client login identifier
        /// </summary>
        string Username { get; }

        /// <summary>
        /// Client login password
        /// </summary>
        string Password { get; }

        /// <summary>
        /// Whether the password has been sent encrypted
        /// </summary>
        bool EncryptedPassword { get; }
    }
}