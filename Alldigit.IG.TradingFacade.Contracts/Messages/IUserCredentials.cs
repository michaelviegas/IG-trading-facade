namespace Alldigit.IG.TradingFacade.Contracts.Messages
{
    public interface IUserCredentials
    {
        string Username { get; }

        string Password { get; }

        bool EncryptedPassword { get; }
    }
}