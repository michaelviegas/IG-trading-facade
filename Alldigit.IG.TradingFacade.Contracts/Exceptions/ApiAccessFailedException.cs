using System;

namespace Alldigit.IG.TradingFacade.Contracts.Exceptions
{
    public class ApiAccessFailedException : Exception
    {
        public string ErrorCode { get; private set; }

        public ApiAccessFailedException(string errorCode, string reasonPhrase)
            : base(reasonPhrase)
        {
            ErrorCode = errorCode;
        }
    }
}
