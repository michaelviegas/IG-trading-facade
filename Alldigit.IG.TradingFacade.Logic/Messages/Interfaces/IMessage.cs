namespace Alldigit.IG.TradingFacade.Logic.Messages.Interfaces
{
    /// <summary>
    /// Represents a message abstracted with a readonly interface
    /// </summary>
    /// <typeparam name="TInterface"></typeparam>
    /// <typeparam name="TClass"></typeparam>
    public interface IMessage<in TInterface, out TClass> where TClass : TInterface
    {
        /// <summary>
        /// Update this message contents from another and return the concrete instance
        /// </summary>
        /// <param name="source">Readonly message to copy from</param>
        /// <returns>Concrete instance of mutated message</returns>
        TClass CopyFrom(TInterface source);
    }
}
