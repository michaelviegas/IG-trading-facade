using Alldigit.IG.TradingFacade.Messages.Interfaces;

namespace Alldigit.IG.TradingFacade.Assemblers
{
    public static class MessageAssembler
    {
        public static TClass ToMessage<TInterface, TClass>(TInterface model)
            where TClass : class, TInterface, IMessage<TInterface, TClass>, new()
        {
            return (model as TClass) ?? new TClass().CopyFrom(model);
        }

    }
}
