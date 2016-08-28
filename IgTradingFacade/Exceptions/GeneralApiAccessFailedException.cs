using System;

namespace IgTradingFacade.Exceptions
{
    public class GeneralApiAccessFailedException : Exception
    {
        public GeneralApiAccessFailedException(string message)
            : base(message)
        {}
    }
}
