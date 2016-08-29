using Newtonsoft.Json;
using NUnit.Framework;

namespace IgTradingFacade.Tests.MessageTests
{
    public abstract class ResponseMessageTestBase<TInterface, TClass> where TClass : TInterface
    {

        protected TInterface ResponseRoundTripIgnoringSerialisation(TClass message)
        {
            return ResponseRoundTripInternal(message, null);
        }

        protected TInterface ResponseRoundTrip(TClass message, string serialisationExpected)
        {
            Assert.IsNotNull(serialisationExpected);
            return ResponseRoundTripInternal(message, serialisationExpected);
        }

        private static TInterface ResponseRoundTripInternal(TClass message, string serialisationExpected)
        {
            // verify that service will output contract in correct format
            var output = JsonConvert.SerializeObject(message);
            if (serialisationExpected != null)
            {
                Assert.AreEqual(serialisationExpected, output);
            }

            // and that the facade can deserialise this and pass it on in an immutable form
            return JsonConvert.DeserializeObject<TClass>(output);
        }

    }
}
