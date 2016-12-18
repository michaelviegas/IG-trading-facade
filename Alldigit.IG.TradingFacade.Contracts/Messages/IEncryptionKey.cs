namespace Alldigit.IG.TradingFacade.Contracts.Messages
{
    public interface IEncryptionKey
    {
        string EncryptionKey { get; }

        long TimeStamp { get; }
    }
}
