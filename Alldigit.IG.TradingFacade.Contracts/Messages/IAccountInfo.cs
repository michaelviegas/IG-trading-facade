namespace Alldigit.IG.TradingFacade.Contracts.Messages
{
    /// <summary>
    /// Account financial data
    /// </summary>
    public interface IAccountInfo
    {
        /// <summary>
        /// Account funds available for trading amount
        /// </summary>
        double Available { get; }

        /// <summary>
        /// Balance of funds in the account
        /// </summary>
        double Balance { get; }

        /// <summary>
        /// Minimum deposit amount required for margins
        /// </summary>
        double Deposit { get; }

        /// <summary>
        /// Account profit and loss amount
        /// </summary>
        double ProfitLoss { get; }
    }
}