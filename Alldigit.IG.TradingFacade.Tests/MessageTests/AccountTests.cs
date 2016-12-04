using Alldigit.IG.TradingFacade.Contracts.Enums;
using Alldigit.IG.TradingFacade.Contracts.Messages;
using Alldigit.IG.TradingFacade.Logic.Messages;
using Alldigit.IG.TradingFacade.Tests.Support;
using NUnit.Framework;

namespace Alldigit.IG.TradingFacade.Tests.MessageTests
{
    [TestFixture]
    public class AccountTests : ResponseMessageTestBase<IAccount, Account>
    {
        private const string AccountId = "dummyAccountId";
        private const string AccountName = "dummyAccountName";
        private const bool Preferred = true;
        private static AccountType AccountType = AccountType.Physical;

        [Test]
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
