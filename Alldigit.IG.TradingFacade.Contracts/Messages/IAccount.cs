namespace Alldigit.IG.TradingFacade.Contracts.Messages
{
    public interface IAccount
    {
        string AccountId { get; }

        string AccountName { get; }

        bool Preferred { get; }

        string AccountType { get; }
    }
}