using IgTradingFacade.Messages.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;

namespace IgTradingFacade.Tests.MessageTests
{
    public abstract class RequestMessageTestBase<TInterface, TClass> 
        where TClass : class, TInterface, IMessage<TInterface, TClass>, new()
    {
        public TInterface RequestRoundTripIgnoringSerialisation(TInterface mock)
        {
            return RequestRoundTripInternal(mock, null);
        }

        public TInterface RequestRoundTrip(TInterface mock, string serialisationExpected)
        {
            Assert.IsNotNull(serialisationExpected);
            return RequestRoundTripInternal(mock, serialisationExpected);
        }

        private static TInterface RequestRoundTripInternal(TInterface mock, string serialisationExpected)
        {
            // verify cloning of message
            var message = new TClass().CopyFrom(mock);

            // verify that facade will output contract in correct format
            var output = JsonConvert.SerializeObject(message);
            if (serialisationExpected != null)
            {
                Assert.AreEqual(serialisationExpected, output);
            }

            // and that the service can deserialise this and pass it on in an immutable form
            return JsonConvert.DeserializeObject<TClass>(output);
        }

        public TInterface MinimumRequest()
        {
            return JsonConvert.DeserializeObject<TClass>("{}");
        }

        public void DeserialiseEmptyRequest()
        {
            Assert.IsNull(JsonConvert.DeserializeObject<TClass>(String.Empty));
        }
    }
}
