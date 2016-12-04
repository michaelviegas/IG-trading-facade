using Alldigit.IG.TradingFacade.Contracts.Enums;
using System.Collections.Generic;

namespace Alldigit.IG.TradingFacade.Contracts.Messages
{
    /// <summary>
    /// Summary of client account information
    /// </summary>
    public interface IUserAccount
    {
        /// <summary>
        /// Account financial data
        /// </summary>
        AccountType AccountType { get; }

        /// <summary>
        /// Account type
        /// </summary>
        IAccountInfo AccountInfo { get; }

        /// <summary>
        /// Collection of account details
        /// </summary>
        IEnumerable<IAccount> Accounts { get; }

        /// <summary>
        /// Authentication status
        /// </summary>
        AuthenticationStatus? AuthenticationStatus { get; }

        /// <summary>
        /// Client identifier
        /// </summary>
        string ClientId { get; }

        /// <summary>
        /// Account currency
        /// </summary>
        string CurrencyIsoCode { get; }

        /// <summary>
        /// Account currency symbol
        /// </summary>
        string CurrencySymbol { get; }

        /// <summary>
        /// Active account identifier
        /// </summary>
        string CurrentAccountId { get; }

        /// <summary>
        /// Whether the account is enabled for placing trading orders
        /// </summary>
        bool DealingEnabled { get; }

        /// <summary>
        /// Flag indicating if the request was marked as being encrypted
        /// </summary>
        bool Encrypted { get; }

        /// <summary>
        /// Collection of form details
        /// </summary>
        IEnumerable<IFormDetails> FormDetails { get; }

        /// <summary>
        /// Whether the Client has active demo accounts
        /// </summary>
        bool HasActiveDemoAccounts { get; }

        /// <summary>
        /// Whether the Client has active live accounts
        /// </summary>
        bool HasActiveLiveAccounts { get; }

        /// <summary>
        /// The IG company that this client belongs to
        /// </summary>
        string IGCompany { get; }

        /// <summary>
        /// Lightstreamer endpoint for subscribing to account and price updates
        /// </summary>
        string LightstreamerEndpoint { get; }

        /// <summary>
        /// Describes the environment to be used as the rerouting destination
        /// </summary>
        ReroutingEnvironment? ReroutingEnvironment { get; }

        /// <summary>
        /// Client account timezone offset relative to UTC, expressed in hours
        /// </summary>
        float TimezoneOffset { get; }

        /// <summary>
        /// Whether the account is allowed to set trailing stops on his trades
        /// </summary>
        bool TrailingStopsEnabled { get; }
    }
}
