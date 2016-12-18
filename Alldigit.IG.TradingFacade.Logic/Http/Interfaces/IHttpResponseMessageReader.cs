using System.Threading.Tasks;

namespace Alldigit.IG.TradingFacade.Logic.Http.Interfaces
{
    public interface IHttpResponseMessageReader
    {
        Task<TResponse> ReadContent<TResponse>();

        string ReadHeaderValue(string headerName);
    }
}
