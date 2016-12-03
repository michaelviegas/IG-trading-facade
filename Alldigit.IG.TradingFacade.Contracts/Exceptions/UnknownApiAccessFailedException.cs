using System;

namespace Alldigit.IG.TradingFacade.Contracts.Exceptions
{
    public class UnknownApiAccessFailedException : Exception
    {
        public UnknownApiAccessFailedException(string message)
            : base(message)
        {}
    }
}
