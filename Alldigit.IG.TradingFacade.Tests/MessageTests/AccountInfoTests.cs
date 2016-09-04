using Alldigit.IG.TradingFacade.Contracts.Messages;
using Alldigit.IG.TradingFacade.Logic.Messages;
using Alldigit.IG.TradingFacade.Tests.Support;
using NUnit.Framework;

namespace Alldigit.IG.TradingFacade.Tests.MessageTests
{
    [TestFixture]
    public class AccountInfoTests : ResponseMessageTestBase<IAccountInfo, AccountInfo>
    {
        private const double Balance = 11.11;
        private const double Deposit = 22.22;
        private const double ProfitLoss = 33.33;
        private const double Available = 44.44;

        [Test]
        public void ExternalSystemResponseRoundTrip()
        {
            var message = new AccountInfo
            {
                Balance = Balance,
                Deposit = Deposit,
                ProfitLoss = ProfitLoss,
                Available = Available
            };

            var response = ResponseRoundTrip(message, ExampleMessages.AccountInfo);

            Assert.AreEqual(Balance, response.Balance);
            Assert.AreEqual(Deposit, response.Deposit);
            Assert.AreEqual(ProfitLoss, response.ProfitLoss);
            Assert.AreEqual(Available, response.Available);
        }

    }
}
