namespace IgTradingFacade.Http.Interfaces
{
    public interface IHttpClientActionWithBody
    {
        IHttpClientActionWithBodyAndResponse To(string url);
    }
}
