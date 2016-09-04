namespace Alldigit.IG.TradingFacade.Contracts.Messages
{
    public interface IAccountInfo
    {
        double Balance { get; }

        double Deposit { get; }

        double ProfitLoss { get; }

        double Available { get; }
    }
}