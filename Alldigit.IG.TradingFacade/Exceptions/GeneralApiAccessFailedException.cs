using System;

namespace Alldigit.IG.TradingFacade.Exceptions
{
    public class GeneralApiAccessFailedException : Exception
    {
        public GeneralApiAccessFailedException(string message)
            : base(message)
        {}
    }
}
