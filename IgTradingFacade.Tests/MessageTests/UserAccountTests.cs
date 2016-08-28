using IgTradingFacade.Messages;
using IgTradingFacade.Messages.Interfaces;
using IgTradingFacade.Tests.Examples;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace IgTradingFacade.Tests.MessageTests
{
    [TestClass]
    public class UserAccountTests : ResponseMessageTestBase<IUserAccount, UserAccount>
    {
        private const string CurrencyIsoCode = "dummyCurrencyIsoCode";
        private const string LightstreamerEndpoint = "dummyLightstreamerEndpoint";
        private const string ClientId = "dummyClientId";

        private const string AccountId = "dummyAccountId";
        private const string AccountName = "dummyAccountName";
        private const bool Preferred = true;
        private const string AccountType = "dummyAccountType";

        private const double Balance = 11.11;
        private const double Deposit = 22.22;
        private const double ProfitLoss = 33.33;
        private const double Available = 44.44;

        private const int TotalAccounts = 3;

        [TestMethod]
        public void ExternalSystemResponseRoundTrip()
        {
            var message = StubMessage();

            var response = ResponseRoundTrip(message, ExampleMessages.UserAccount);

            AssertResponse(response);
        }

        private static UserAccount StubMessage()
        {
            var message = new UserAccount
            {
                AccountType = AccountType,
                AccountInfo = new AccountInfo
                {
                    Balance = Balance,
                    Deposit = Deposit,
                    ProfitLoss = ProfitLoss,
                    Available = Available
                },
                CurrencyIsoCode = CurrencyIsoCode,
                CurrentAccountId = AccountId,
                LightstreamerEndpoint = LightstreamerEndpoint,
                Accounts = StubAccounts(),
                ClientId = ClientId
            };

            return message;
        }

        private static IEnumerable<Account> StubAccounts()
        {
            var accounts = new List<Account>();

            for (int i = 0; i < TotalAccounts; i++)
            {
                var isFirstAccount = i == 0; ;
                accounts.Add(new Account
                {
                    AccountId = AccountId + i,
                    AccountName = AccountName + i,
                    Preferred = isFirstAccount,
                    AccountType = AccountType + i
                });
            }

            return accounts;
        }

        private static void AssertResponse(IUserAccount response)
        {
            Assert.AreEqual(AccountType, response.AccountType);
            Assert.AreEqual(CurrencyIsoCode, response.CurrencyIsoCode);
            Assert.AreEqual(AccountId, response.CurrentAccountId);
            Assert.AreEqual(LightstreamerEndpoint, response.LightstreamerEndpoint);
            Assert.AreEqual(ClientId, response.ClientId);

            Assert.IsNotNull(response.AccountInfo);
            Assert.AreEqual(Balance, response.AccountInfo.Balance);
            Assert.AreEqual(Deposit, response.AccountInfo.Deposit);
            Assert.AreEqual(ProfitLoss, response.AccountInfo.ProfitLoss);
            Assert.AreEqual(Available, response.AccountInfo.Available);

            Assert.IsNotNull(response.Accounts);
            var expectedAccounts = StubAccounts();
            Assert.AreEqual(expectedAccounts.Count(), response.Accounts.Count());
            foreach (var expectedAccount in expectedAccounts)
            {
                var account = response.Accounts.FirstOrDefault(t => t.AccountId == expectedAccount.AccountId);
                Assert.IsNotNull(account);
                Assert.AreEqual(expectedAccount.AccountName, account.AccountName);
                Assert.AreEqual(expectedAccount.Preferred, account.Preferred);
                Assert.AreEqual(expectedAccount.AccountType, account.AccountType);
            }
        }

    }
}
