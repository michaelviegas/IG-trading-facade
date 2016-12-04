using Alldigit.IG.TradingFacade.Contracts.Enums;

namespace Alldigit.IG.TradingFacade.Contracts.Messages
{
    /// <summary>
    /// Account details
    /// </summary>
    public interface IAccount
    {
        /// <summary>
        /// Account identifier
        /// </summary>
        string AccountId { get; }

        /// <summary>
        /// Account name
        /// </summary>
        string AccountName { get; }

        /// <summary>
        /// Account type
        /// </summary>
        AccountType AccountType { get; }

        /// <summary>
        /// Indicates whether this account is the client's preferred account
        /// </summary>
        bool Preferred { get; }
    }
}