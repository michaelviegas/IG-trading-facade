using Alldigit.IG.TradingFacade.Contracts.Enums;

namespace Alldigit.IG.TradingFacade.Contracts.Messages
{
    /// <summary>
    /// Form details
    /// </summary>
    public interface IFormDetails
    {
        /// <summary>
        /// Indicates if a user can dismiss the form
        /// </summary>
        bool FormDismissible { get; }

        /// <summary>
        /// Form title
        /// </summary>
        string FormTitle { get; }

        /// <summary>
        /// Types of Form
        /// </summary>
        FormType FormType { get; }

        /// <summary>
        /// Form access url
        /// </summary>
        string FormUrl { get; }
    }
}