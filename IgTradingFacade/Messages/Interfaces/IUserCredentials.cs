namespace IgTradingFacade.Messages.Interfaces
{
    public interface IUserCredentials
    {
        string Username { get; }

        string Password { get; }

        bool EncryptedPassword { get; }
    }
}