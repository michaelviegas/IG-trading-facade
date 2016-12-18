using Alldigit.IG.TradingFacade.Logic;
using Alldigit.IG.TradingFacade.Logic.Messages;
using NUnit.Framework;
using System.Net.Http;
using Alldigit.IG.TradingFacade.Logic.Http;
using Alldigit.IG.TradingFacade.Tests.Support;
using System.Net;
using FluentAssertions;

namespace Alldigit.IG.TradingFacade.Tests.RestClientTests.SessionRestClientTests
{
    [TestFixture]
    public class GetEncryptionKeyTests
    {
        private const string Endpoint = "http://localhost";
        private const string ApiKey = "dummy_api_hey";

        public class Sut : SessionRestClient
        {
            public Sut(HttpMessageHandler messageHandler) : base(Endpoint, messageHandler) { }
        }

        [Test]
        public void SuccessfullyGetEncryptionKey()
        {
            var responseContent = CreateEncryptionKeyStub();
            var response = SuccessMessageResponseWithBody(responseContent);

            var messageHandler = new HttpMessageHandlerMock<EncryptionKeyMessage>(response);
            var sut = new Sut(messageHandler);

            var result = sut.GetEncryptionKey(ApiKey).Result;

            messageHandler.ValidateJsonRequest(HttpMethod.Get, Endpoint, "gateway/deal/session/encryptionKey", null, null);

            Assert.IsNotNull(result);
            result.ShouldBeEquivalentTo(responseContent);

        }

        protected static HttpResponseMessage SuccessMessageResponseWithBody<TContent>(TContent content)
        {
            var httpHesponseMessage = new HttpResponseMessage(HttpStatusCode.OK);

            httpHesponseMessage.Content = HttpContentConverter.ToJsonStringContent(content);

            return httpHesponseMessage;
        }

        protected static EncryptionKeyMessage CreateEncryptionKeyStub()
        {
            return new EncryptionKeyMessage
            {
                EncryptionKey = "DummyEncryptionKey",
                TimeStamp = 9876
            };
        }
    }
}
