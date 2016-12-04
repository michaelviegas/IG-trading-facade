using Alldigit.IG.TradingFacade.Contracts.Enums;
using Alldigit.IG.TradingFacade.Contracts.Messages;
using Alldigit.IG.TradingFacade.Logic.Messages;
using Alldigit.IG.TradingFacade.Tests.Support;
using NUnit.Framework;

namespace Alldigit.IG.TradingFacade.Tests.MessageTests
{
    [TestFixture]
    public class FormDetailsTests : ResponseMessageTestBase<IFormDetails, FormDetails>
    {
        private const bool FormDismissible = true;
        private const string FormTitle = "dummyFormTitle";
        private static FormType FormType = FormType.KnowYourClient;
        private const string FormUrl = "dummyFormUrl";

        [Test]
        public void ExternalSystemResponseRoundTrip()
        {
            var message = new FormDetails
            {
                FormDismissible = FormDismissible,
                FormTitle = FormTitle,
                FormType = FormType,
                FormUrl = FormUrl
            };

            var response = ResponseRoundTrip(message, ExampleMessages.FormDetails);

            Assert.AreEqual(FormDismissible, response.FormDismissible);
            Assert.AreEqual(FormTitle, response.FormTitle);
            Assert.AreEqual(FormType, response.FormType);
            Assert.AreEqual(FormUrl, response.FormUrl);
        }

    }
}
