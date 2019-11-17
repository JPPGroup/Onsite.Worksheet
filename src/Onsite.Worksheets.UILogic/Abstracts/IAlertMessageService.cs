using Onsite.Worksheets.UILogic.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Onsite.Worksheets.UILogic.Abstracts
{
    //TODO: add xml comments
    public interface IAlertMessageService
    {
        Task ShowAsync(string message, string title);
        Task ShowAsync(string message, string title, IEnumerable<DialogCommand> dialogCommands);
    }
}
