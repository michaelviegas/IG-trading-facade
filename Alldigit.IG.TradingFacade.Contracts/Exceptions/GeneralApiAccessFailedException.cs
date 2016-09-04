using System;

namespace Alldigit.IG.TradingFacade.Contracts.Exceptions
{
    public class GeneralApiAccessFailedException : Exception
    {
        public GeneralApiAccessFailedException(string message)
            : base(message)
        {}
    }
}
