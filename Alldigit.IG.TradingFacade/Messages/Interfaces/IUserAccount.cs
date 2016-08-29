using System.Collections.Generic;

namespace Alldigit.IG.TradingFacade.Messages.Interfaces
{
    public interface IUserAccount
    {
        string AccountType { get; }

        IAccountInfo AccountInfo { get; }

        string CurrencyIsoCode { get; }

        string CurrentAccountId { get; }

        string LightstreamerEndpoint { get; }

        IEnumerable<IAccount> Accounts { get; }

        string ClientId { get; }
    }
}
