using Alldigit.IG.TradingFacade.Logic;
using Alldigit.IG.TradingFacade.Logic.Http;
using Alldigit.IG.TradingFacade.Logic.Messages;
using Alldigit.IG.TradingFacade.Tests.Support;
using Alldigit.IG.TradingFacade.Tests.Support.Stubs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Linq;
using FluentAssertions;
using Alldigit.IG.TradingFacade.Contracts.Enums;

namespace Alldigit.IG.TradingFacade.Tests.RestClientTests.SessionRestClientTests
{
    [TestFixture]
    public class LoginTests
    {
        private const string Endpoint = "http://localhost";
        private const string ApiKey = "dummy_api_hey";

        private const string ClientSessionToken = "dummy_client_session_token";
        private const string ActiveAccountSessionToken = "dummy_active_account_session_token";

        public class Sut : SessionRestClient
        {
            public Sut(HttpMessageHandler messageHandler) : base(Endpoint, messageHandler) { }
        }

        [Test]
        public void TryToLoginWithNullCredentials()
        {
            var sut = new Sut(null);
            Assert.ThrowsAsync<ArgumentNullException>(() => sut.Login(ApiKey, null));
        }

        [Test]
        public void SuccessfulLogin()
        {
            var responseHeaders = new Dictionary<string, string>();
            responseHeaders.Add(Constants.ClientSessionTokenHeaderName, ClientSessionToken);
            responseHeaders.Add(Constants.ActiveAccountSessionTokenHeaderName, ActiveAccountSessionToken);

            var responseContent = CreateUserAccountStub();
            var response = SuccessMessageResponseWithHeadersAndBody(responseHeaders, responseContent);

            var messageHandler = new HttpMessageHandlerMock<UserCredentials>(response);
            var sut = new Sut(messageHandler);

            var result = sut.Login(ApiKey, new UserCredentialsStub()).Result;

            messageHandler.ValidateJsonRequest(HttpMethod.Post, Endpoint, "gateway/deal/session", ApiKey, 2);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Session);
            Assert.AreEqual(ClientSessionToken, result.Session.ClientToken);
            Assert.AreEqual(ActiveAccountSessionToken, result.Session.ActiveAccountToken);

            Assert.IsNotNull(result.UserAccount);
            result.UserAccount.ShouldBeEquivalentTo(responseContent);
        }

        protected static HttpResponseMessage SuccessMessageResponseWithHeadersAndBody<TContent>(IDictionary<string, string> headers, TContent content)
        {
            var httpHesponseMessage = new HttpResponseMessage(HttpStatusCode.OK);

            httpHesponseMessage.Content = HttpContentConverter.ToJsonStringContent(content);
            foreach (var header in headers)
            {
                httpHesponseMessage.Headers.Add(header.Key, header.Value);
            }

            return httpHesponseMessage;
        }

        protected static UserAccount CreateUserAccountStub()
        {
            return new UserAccount
            {
                AccountInfo = new AccountInfo
                {
                    Available = 111,
                    Balance = 222,
                    Deposit = 333,
                    ProfitLoss = 444
                },
                AccountType = AccountType.CFD,
                Accounts = (new[] { 1, 2, 3 })
                    .Select(i => new Account
                    {
                        AccountId = "DummyAccountId" + i,
                        AccountName = "DummyAccountName" + i,
                        AccountType = AccountType.Physical,
                        Preferred = i == 1
                    }),
                ClientId = "DummyClientId",
                CurrencyIsoCode = "DummyCurrencyIsoCode",
                CurrentAccountId = "DummyCurrentAccountId",
                LightstreamerEndpoint = "DummyLightstreamerEndpoint"
            };
        }
    }
}
