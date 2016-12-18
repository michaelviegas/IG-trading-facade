namespace Alldigit.IG.TradingFacade.Logic.Http.Interfaces
{
    public interface IHttpClientAction
    {
        IHttpClientAction ForApplication(string apiKey);

        IHttpClientAction OnVersion(int version);

        IHttpClientActionNoBody Get();

        IHttpClientActionWithBody Post<TRequest>(TRequest request);
    }
}
