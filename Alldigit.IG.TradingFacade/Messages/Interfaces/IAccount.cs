namespace Alldigit.IG.TradingFacade.Messages.Interfaces
{
    public interface IAccount
    {
        string AccountId { get; }

        string AccountName { get; }

        bool Preferred { get; }

        string AccountType { get; }
    }
}