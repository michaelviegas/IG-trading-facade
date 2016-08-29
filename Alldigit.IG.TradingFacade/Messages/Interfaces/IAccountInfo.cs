namespace Alldigit.IG.TradingFacade.Messages.Interfaces
{
    public interface IAccountInfo
    {
        double Balance { get; }

        double Deposit { get; }

        double ProfitLoss { get; }

        double Available { get; }
    }
}