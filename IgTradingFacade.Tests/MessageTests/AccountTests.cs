using IgTradingFacade.Messages;
using IgTradingFacade.Messages.Interfaces;
using IgTradingFacade.Tests.Examples;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IgTradingFacade.Tests.MessageTests
{
    [TestClass]
    public class AccountTests : ResponseMessageTestBase<IAccount, Account>
    {
        private const string AccountId = "dummyAccountId";
        private const string AccountName = "dummyAccountName";
        private const bool Preferred = true;
        private const string AccountType = "dummyAccountType";

        [TestMethod]
        public void ExternalSystemResponseRoundTrip()
        {
            var message = new Account
            {
                AccountId = AccountId,
                AccountName = AccountName,
                Preferred = Preferred,
                AccountType = AccountType
            };

            var response = ResponseRoundTrip(message, ExampleMessages.Account);

            Assert.AreEqual(AccountId, response.AccountId);
            Assert.AreEqual(AccountName, response.AccountName);
            Assert.AreEqual(Preferred, response.Preferred);
            Assert.AreEqual(AccountType, response.AccountType);
        }

    }
}
