using IgTradingFacade.Messages;
using IgTradingFacade.Messages.Interfaces;
using IgTradingFacade.Tests.Examples;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IgTradingFacade.Tests.MessageTests
{
    [TestClass]
    public class UserCredentialsTests : RequestMessageTestBase<IUserCredentials, UserCredentials>
    {
        private const string Username = "dummyUsername";
        private const string Password = "dummyPassword";
        private const bool EncryptedPassword = true;

        [TestMethod]
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

        [TestMethod]
        public void ClientCredentialsMinimumRequest()
        {
            var request = MinimumRequest();

            Assert.AreEqual(default(string), request.Username);
            Assert.AreEqual(default(string), request.Password);
            Assert.AreEqual(default(bool), request.EncryptedPassword);
        }

        [TestMethod]
        public void ClientCredentialsEmptyRequest()
        {
            DeserialiseEmptyRequest();
        }
    }
}