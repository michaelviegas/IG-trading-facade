using Alldigit.IG.TradingFacade.Messages;
using Alldigit.IG.TradingFacade.Messages.Interfaces;
using Alldigit.IG.TradingFacade.Tests.Examples;
using Moq;
using NUnit.Framework;

namespace Alldigit.IG.TradingFacade.Tests.MessageTests
{
    [TestFixture]
    public class UserCredentialsTests : RequestMessageTestBase<IUserCredentials, UserCredentials>
    {
        private const string Username = "dummyUsername";
        private const string Password = "dummyPassword";
        private const bool EncryptedPassword = true;

        [Test]
        public void UserCredentialsRequestRoundTrip()
        {
            var mockMessage = new Mock<IUserCredentials>();
            mockMessage.SetupGet(p => p.Username).Returns(Username);
            mockMessage.SetupGet(p => p.Password).Returns(Password);
            mockMessage.SetupGet(p => p.EncryptedPassword).Returns(EncryptedPassword);

            var request = RequestRoundTrip(mockMessage.Object, ExampleMessages.UserCredentials);

            Assert.AreEqual(Username, request.Username);
            Assert.AreEqual(Password, request.Password);
            Assert.AreEqual(EncryptedPassword, request.EncryptedPassword);
        }

        [Test]
        public void ClientCredentialsMinimumRequest()
        {
            var request = MinimumRequest();

            Assert.AreEqual(default(string), request.Username);
            Assert.AreEqual(default(string), request.Password);
            Assert.AreEqual(default(bool), request.EncryptedPassword);
        }

        [Test]
        public void ClientCredentialsEmptyRequest()
        {
            DeserialiseEmptyRequest();
        }
    }
}