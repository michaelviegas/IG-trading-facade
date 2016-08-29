namespace Alldigit.IG.TradingFacade.Http.Interfaces
{
    public interface IHttpClientActionWithBody
    {
        IHttpClientActionWithBodyAndResponse To(string url);
    }
}
