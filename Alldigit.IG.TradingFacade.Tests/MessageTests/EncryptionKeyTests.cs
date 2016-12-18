using Alldigit.IG.TradingFacade.Contracts.Messages;
using Alldigit.IG.TradingFacade.Logic.Messages;
using Alldigit.IG.TradingFacade.Tests.Support;
using NUnit.Framework;

namespace Alldigit.IG.TradingFacade.Tests.MessageTests
{
    [TestFixture]
    public class EncryptionKeyTests : ResponseMessageTestBase<IEncryptionKey, EncryptionKeyMessage>
    {
        private const string EncryptionKey = "dummyEncryptionKey";
        private const int TimeStamp = 9876;

        [Test]
        public void ExternalSystemResponseRoundTrip()
        {
            var message = new EncryptionKeyMessage
            {
                EncryptionKey = EncryptionKey,
                TimeStamp = TimeStamp
            };

            var response = ResponseRoundTrip(message, ExampleMessages.EncryptionKey);

            Assert.AreEqual(EncryptionKey, response.EncryptionKey);
            Assert.AreEqual(TimeStamp, response.TimeStamp);
        }

    }
}
